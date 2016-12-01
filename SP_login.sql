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


if OBJECT_ID(N'[ANOTHER_CAT].[alta_usuario]') is not null
	drop proc [ANOTHER_CAT].[alta_usuario]
GO

create PROC[ANOTHER_CAT].[alta_usuario]
(@nom varchar(255), @ape varchar (255),@direc varchar (255),@tel numeric (18),@mail varchar(255),@fechaN datetime,@tipoDoc varchar (20),
@nrodoc numeric(18), @sexo char (1),@hijos  )  
as
BEGIN

● Estado civil
▪ Soltero/a
▪ Casado/a
▪ Viudo/a
▪ Concubinato
▪ Divorciado/a
● Cantidad de hijos o familiares a cargo
● Plan Médico
● Nro. de afiliado (asignado por el sistema)