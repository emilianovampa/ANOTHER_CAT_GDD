IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Turno'))
	DROP TABLE ANOTHER_CAT.tl_Turno



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Rol_Funcionalidad'))
	DROP TABLE ANOTHER_CAT.tl_Rol_Funcionalidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Especialidad_Profesional'))
	DROP TABLE ANOTHER_CAT.tl_Especialidad_Profesional



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Cambio_Plan'))
	DROP TABLE ANOTHER_CAT.tl_Cambio_Plan


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Agenda'))
	DROP TABLE ANOTHER_CAT.tl_Agenda

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Tipo_Cancelacion'))
	DROP TABLE ANOTHER_CAT.tl_Tipo_Cancelacion



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Turno_Cancelacion'))
	DROP TABLE ANOTHER_CAT.tl_Turno_Cancelacion


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Consulta_Medica'))
	DROP TABLE ANOTHER_CAT.tl_Consulta_Medica


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Funcionalidad'))
	DROP TABLE ANOTHER_CAT.tl_Funcionalidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Usuario_Rol'))
	DROP TABLE ANOTHER_CAT.tl_Usuario_Rol



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Especialidad'))
	DROP TABLE ANOTHER_CAT.tl_Especialidad


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Rol'))
	DROP TABLE ANOTHER_CAT.tl_Rol



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Tipo_Especialidad'))
	DROP TABLE ANOTHER_CAT.tl_Tipo_Especialidad



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Bono'))
	DROP TABLE ANOTHER_CAT.tl_Bono

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Compra_Bono'))
	DROP TABLE ANOTHER_CAT.tl_Compra_Bono

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Afiliado'))
	DROP TABLE ANOTHER_CAT.tl_Afiliado



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Plan_Medico'))
	DROP TABLE ANOTHER_CAT.tl_Plan_Medico


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Profesional'))
	DROP TABLE ANOTHER_CAT.tl_Profesional


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Usuario'))
	DROP TABLE ANOTHER_CAT.tl_Usuario


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ANOTHER_CAT.tl_Persona'))
	DROP TABLE ANOTHER_CAT.tl_Persona



DROP SEQUENCE ANOTHER_CAT.Per
DROP SEQUENCE ANOTHER_CAT.Afi
DROP SEQUENCE ANOTHER_CAT.Mat
DROP SEQUENCE ANOTHER_CAT.Pro
