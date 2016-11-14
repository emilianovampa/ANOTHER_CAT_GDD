if OBJECT_ID(N'[ANOTHER_CAT].[login]') is not null
	drop proc [ANOTHER_CAT].[login]
GO

create PROC [ANOTHER_CAT].[login] 

(@auxnombre as char (15), @auxpass as nvarchar(200),  @retorno as INT output, @idUsuario as bigint output ) AS

BEGIN
--OBJETIVO: LOGRAR EL LOGIN DE USUARIO, TAMBIEN DESHABILITARLO SI ES ERRONEO (NO CONSIDERA COMO LOGIN A LA FUNCIONALIDAD
--PARAMETROS: SE INGRESA EL USUARIO, LA PASSWORD, Y EL CODIGO DE ROL, Y RETORNA EL EXITO DE LA PROC 
--PUBL_ESTADO = 0 LOGIN CORRECTO
--PUBL_ESTADO = 1 INGRESO MAL LA CLAVE
--PUBL_ESTADO = 2 USUARIO INHABILITADO, CONTACTAR ADMINISTRADOR 2
--PUBL_ESTADO = 3 USUARIO INHABILITADO POR INGRESAR 3 VECES MAL LA PASSWORD 3

	DECLARE @CONTADORUSU INT;
	declare @contadorrol smallint;
	DECLARE @cantidad_f int;
	declare @estado char(1);
	SET @CONTADORUSU = 0;
	SET @cantidad_f = 0;
	SELECT @estado = Bloqueado FROM tl_Usuario where @auxnombre = Username;
--VERIFICA QUE EL USUARIO ESTE HABILITADO
	if (@estado =0)
	 BEGIN
	  SELECT @CONTADORUSU = COUNT(*) FROM tl_Usuario where @auxnombre = Username and @auxpass = Password ;
-- VERIFICA EL MATCH DEL USUARIO Y EL PASSWORD 
      if (@CONTADORUSU = 0)
       begin
--NO ACERTÓ LA PASSWORD
        SELECT @cantidad_f = Login_Fallidos FROM tl_Usuario WHERE @auxnombre = Username;
        if (@cantidad_f = 2)
         begin
--NO TIENE MAS OPORTUNIDADES (SE BLOQUEA Y SE CUENTA 3)
		  UPDATE tl_Usuario SET Login_Fallidos = 3, Bloqueado = 1 WHERE @auxnombre = Username;
          set @retorno = 3;
         end
        ELSE
         BEGIN
--ACUMULA UN ERROR FALLIDO
          UPDATE tl_Usuario set Login_Fallidos = (@cantidad_f + 1) WHERE @auxnombre = Username;
          set @retorno = 1;
         END
       end
      else
--ACERTÓ. 
          begin
		   UPDATE tl_Usuario SET Login_Fallidos = 0 WHERE @auxnombre = Username;
		   select @idUsuario=ID_usuario from tl_Usuario where Username =@auxnombre;
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