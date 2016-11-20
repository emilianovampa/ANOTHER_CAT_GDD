USE [GD2C2016]
GO

-- Verifico si existe el schema, si no existe lo creo


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'ANOTHER_CAT')
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA [ANOTHERCAT] AUTHORIZATION [gd]'
		PRINT 'Schema correctamente creado'

	END
GO


-- Verficicacion de tablas. Si existen las dropeo.


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Agenda'))
	DROP TABLE ANOTHER_CAT.tl_Agenda


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Profesional_Agenda'))
	DROP TABLE ANOTHER_CAT.tl_Profesional_Agenda



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Bono'))
	DROP TABLE ANOTHER_CAT.tl_Bono



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Profesional_Especialidad'))
	DROP TABLE ANOTHER_CAT.tl_Profesional_Especialidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Cambio_Plan_Medico'))
	DROP TABLE ANOTHER_CAT.tl_Cambio_Plan_Medico



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Funcionalidad_Rol'))
	DROP TABLE ANOTHER_CAT.tl_Funcionalidad_Rol


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Usuario_Rol'))
	DROP TABLE ANOTHER_CAT.tl_Usuario_Rol



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Consulta_Medica'))
	DROP TABLE ANOTHER_CAT.tl_Consulta_Medica


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Funcionalidad'))
	DROP TABLE ANOTHER_CAT.tl_Funcionalidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Rol'))
	DROP TABLE ANOTHER_CAT.tl_Rol


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Turno_Cancelado'))
	DROP TABLE ANOTHER_CAT.tl_Turno_Cancelado



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Afiliado'))
	DROP TABLE ANOTHER_CAT.tl_Afiliado



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Plan_Medico'))
	DROP TABLE ANOTHER_CAT.tl_Plan_Medico



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Profesional'))
	DROP TABLE ANOTHER_CAT.tl_Profesional



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Usuario'))
	DROP TABLE ANOTHER_CAT.tl_Usuario


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Especialidad'))
	DROP TABLE ANOTHER_CAT.tl_Especialidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Tipo_Especialidad'))
	DROP TABLE ANOTHER_CAT.tl_Tipo_Especialidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Asistencia'))
	DROP TABLE ANOTHER_CAT.tl_Asistencia


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Turno'))
	DROP TABLE ANOTHER_CAT.tl_Turno



