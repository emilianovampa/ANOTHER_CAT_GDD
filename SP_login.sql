if OBJECT_ID(N'[ANOTHER_CAT].[login]') is not null
	drop proc [ANOTHER_CAT].[login]
GO

create PROC [ANOTHER_CAT].[login] 

(@auxnombre as nvarchar (255), @auxpass as  nvarchar(255),  
@retorno int output, @idUsuario bigint output, @cantRoles int output ) AS

BEGIN
--OBJETIVO: LOGRAR EL LOGIN DE USUARIO, TAMBIEN DESHABILITARLO SI ES ERRONEO (NO CONSIDERA COMO LOGIN A LA FUNCIONALIDAD
--PARAMETROS: SE INGRESA EL USUARIO, LA PASSWORD, Y EL CODIGO DE ROL, Y RETORNA EL EXITO DE LA PROC 
--PUBL_ESTADO = 0 LOGIN CORRECTO
--PUBL_ESTADO = 1 INGRESO MAL LA CLAVE
--PUBL_ESTADO = 2 USUARIO INHABILITADO, CONTACTAR ADMINISTRADOR 2
--PUBL_ESTADO = 3 USUARIO INHABILITADO POR INGRESAR 3 VECES MAL LA PASSWORD 3
	DECLARE @CONTADORUSU INT;
	DECLARE @cantidad_f int,@estado int;
	SET @CONTADORUSU = 0;
	SET @cantidad_f = 0;
	set @idUsuario=-1
	set @cantRoles = -1;

--declare @test varbinary (255) = convert(varbinary (255),@auxpass);
	declare @hash as varbinary(max) = HASHBYTES('SHA2_256', @auxpass )
	SELECT @estado = Habilitado FROM GD2C2016.ANOTHER_CAT.tl_Usuario where @auxnombre = Username;
--VERIFICA QUE EL USUARIO ESTE HABILITADO
	if (@estado =1)
	 BEGIN
	  SELECT @CONTADORUSU = COUNT(*) FROM GD2C2016.ANOTHER_CAT.tl_Usuario as U where @auxnombre = u.Username and u.Password = @hash;
-- VERIFICA EL MATCH DEL USUARIO Y EL PASSWORD 
      if (@CONTADORUSU = 0)
       begin
--NO ACERTÓ LA PASSWORD
        SELECT @cantidad_f = Login_Fallidos FROM GD2C2016.ANOTHER_CAT.tl_Usuario WHERE @auxnombre = Username;
        if (@cantidad_f = 2)
         begin
--NO TIENE MAS OPORTUNIDADES (SE BLOQUEA Y SE CUENTA 3)
		  UPDATE GD2C2016.ANOTHER_CAT.tl_Usuario SET Login_Fallidos = 3, Habilitado = 0 WHERE @auxnombre = Username;
          set @retorno = 3;
         end
        ELSE
         BEGIN
--ACUMULA UN ERROR FALLIDO
          UPDATE GD2C2016.ANOTHER_CAT.tl_Usuario set Login_Fallidos = (@cantidad_f + 1) WHERE @auxnombre = Username;
          set @retorno = 1;
         END
       end
      else
--ACERTÓ. 
          begin
		   UPDATE GD2C2016.ANOTHER_CAT.tl_Usuario SET Login_Fallidos = 0 WHERE @auxnombre = Username;
		   select @idUsuario=ID_usuario from GD2C2016.ANOTHER_CAT.tl_Usuario where Username =@auxnombre;
		   SELECT @cantRoles=count(ur.ID_Usuario) from [ANOTHER_CAT].tl_Usuario_Rol as ur join [GD2C2016].[ANOTHER_CAT].tl_rol as R on ur.ID_Rol = r.ID_Rol where ur.ID_Usuario=@idUsuario
	        BEGIN
	         set @retorno = 0; 
	        END
          END
       END
    ELSE
     BEGIN
-- USUARIO DESHABILITADO
      SET @retorno = 2;
     END
END


go

IF OBJECT_ID (N'[ANOTHER_CAT].AgregarFuncionalidadAUnRol') is not null DROP PROCEDURE [ANOTHER_CAT].AgregarFuncionalidadAUnRol
GO
CREATE PROC [ANOTHER_CAT].AgregarFuncionalidadAUnRol (@idrol bigint, @idfuncionalidad bigint) 
AS
BEGIN
	insert into  [ANOTHER_CAT].[tl_Rol_Funcionalidad] (ID_ROL,[ID_Funcionalidad] )
	values(@idrol,@idfuncionalidad)
end

go

IF OBJECT_ID (N'[ANOTHER_CAT].QuitarFuncionalidadAUnRol') is not null DROP PROCEDURE [ANOTHER_CAT].QuitarFuncionalidadAUnRol
GO
CREATE PROC [ANOTHER_CAT].QuitarFuncionalidadAUnRol (@idrol bigint, @idfuncionalidad bigint) 
AS
BEGIN
	delete from [ANOTHER_CAT].[tl_Rol_Funcionalidad] where ID_Rol = @idrol and ID_Funcionalidad = @idfuncionalidad
end

GO

IF OBJECT_ID ('ANOTHER_CAT.habilitarRol') is not null DROP PROCEDURE ANOTHER_CAT.habilitarRol
GO
CREATE PROC ANOTHER_CAT.habilitarRol (@idrol bigint) AS
BEGIN
	UPDATE [ANOTHER_CAT].[tl_Rol] SET [Habilitado]=1 WHERE [ID_Rol]=@idrol
END

GO

IF OBJECT_ID ('ANOTHER_CAT.ModificarRol') is not null DROP PROCEDURE ANOTHER_CAT.ModificarRol
GO
CREATE PROC ANOTHER_CAT.ModificarRol (@rol bigint, @nuevo_nombre varchar(255)) AS
	BEGIN
		update [ANOTHER_CAT].[tl_Rol] set  [Nombre]= @nuevo_nombre where [ID_Rol]=@rol

	END
GO

IF OBJECT_ID ('ANOTHER_CAT.InhabilitarRol') is not null DROP PROCEDURE ANOTHER_CAT.InhabilitarRol
GO
CREATE PROC ANOTHER_CAT.InhabilitarRol (@rol bigint) AS
	BEGIN

		update [ANOTHER_CAT].[tl_Rol] set [Habilitado]=0  where [ID_Rol]=@rol
		delete from [ANOTHER_CAT].[tl_Usuario_Rol] where ID_Rol = @rol

	END
GO


IF OBJECT_ID ('ANOTHER_CAT.CrearRol') is not null DROP PROCEDURE ANOTHER_CAT.CrearRol
GO
CREATE PROC ANOTHER_CAT.CrearRol (@rol varchar(255),@idrol bigint output ) AS 
	
	BEGIN
		begin
		insert into  [ANOTHER_CAT].[tl_Rol] (Nombre,[Habilitado] )
		values(@rol,1)
		
		select @idrol=[ID_Rol] from [ANOTHER_CAT].[tl_Rol] where [Nombre]= @rol
		end
	END
GO


  --CREAR AFILIADO

  IF OBJECT_ID ('ANOTHER_CAT.Afiliado_Add') is not null DROP PROCEDURE ANOTHER_CAT.Afiliado_Add

GO

  CREATE PROCEDURE ANOTHER_CAT.Afiliado_Add(@Username nvarchar(255),@nAfiliado bigint, @Nombre varchar(255), @Mail varchar(255),@Telefono numeric(18,0),@Direccion varchar(255),
  @Apellido varchar(255),@Dni numeric(18,0),  @EstadoCivil varchar(50), @Plan numeric(18,0),@Sexo char(1), @CantHijos bigint,
  @Fecha datetime,   @TipoDocumento varchar(20))
  AS
	BEGIN
	DECLARE @input as NVARCHAR(max) = 'w23e',@idusario bigint;
	SET NOCOUNT ON;

	--dar de alta en usuario
INSERT INTO [ANOTHER_CAT].[tl_Usuario] ([Username],[Password],[Login_Fallidos],[Nombre],[Apellido],[Direccion],[Telefono],[Mail],[Fecha_Nacimiento],[Tipo_Documento]
           ,[Nro_Documento],[Sexo],[Habilitado])
     VALUES
           (@Username,HASHBYTES('SHA2_256', @input),0,@Nombre,@Apellido,@Direccion,@Telefono,@Mail,@Fecha,@TipoDocumento ,@Dni,@Sexo,1)

		select @idusario=ID_Usuario from [ANOTHER_CAT].[tl_Usuario] where [Username]= @Username

		--dar de alta en Afiliado
INSERT INTO [ANOTHER_CAT].[tl_Afiliado]([ID_Afiliado],[ID_Plan_Medico],[Numero_Afiliado],[Estado_Civil],[Habilitado],[Cant_Hijos],[Numero_Consulta_Medica])
     VALUES
           (@idusario
           ,@Plan,@nAfiliado,@EstadoCivil,1,@CantHijos,0)

		--dar de alta en uruario x rol
		INSERT INTO [ANOTHER_CAT].[tl_Usuario_Rol]([ID_Rol],[ID_Usuario])
		values (3,@idusario)
		
	END
  GO

  IF OBJECT_ID ('[ANOTHER_CAT].DarDeBajaUnAfiliado') is not null DROP PROCEDURE [ANOTHER_CAT].DarDeBajaUnAfiliado
GO
CREATE PROC [ANOTHER_CAT].DarDeBajaUnAfiliado(@afiliado numeric(18,0), @fecha_sistema datetime, @Resultado int output) AS
BEGIN
	if ( (select count ([ID_Afiliado]) from [ANOTHER_CAT].[tl_Afiliado] where [ID_Afiliado] = @afiliado) > 0 )
	  
		BEGIN
			update [ANOTHER_CAT].[tl_Afiliado] set [Habilitado] = 0, [Fecha_baja] =@fecha_sistema  where  [Numero_Afiliado]= @afiliado
	
				delete from  [ANOTHER_CAT].[tl_Turno] where [ID_Afiliado]=@afiliado
	
			set @Resultado = 1
		END
	ELSE
		Begin
		set @Resultado = 0
		End	

END
GO

select AF.[ID_Plan_Medico], AF.[Estado_Civil],US.[Direccion], US.[Telefono],US.[Mail]
from [ANOTHER_CAT].[tl_Afiliado] as AF
JOIN [ANOTHER_CAT].[tl_Usuario] AS US ON AF.[ID_Afiliado]= US.ID_Usuario
WHERE AF.Numero_Afiliado=101

