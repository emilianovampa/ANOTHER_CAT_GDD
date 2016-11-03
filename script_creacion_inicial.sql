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


/*DROP PROCEDURE MigrarAfiliadosUsuarios
DROP PROCEDURE MigrarAfiliados*/

-- Creacion de tablas


CREATE TABLE ANOTHER_CAT.tl_Afiliado (
	ID_Usuario BIGINT NOT NULL,
	ID_Plan_Medico BIGINT,
	Numero_Afiliado BIGINT NULL,
	Numero_Familiar BIGINT NULL,
	Estado_Civil VARCHAR(20) NULL,
	Habilitado BIT NULL,
	Numero_Consulta_Medica BIGINT NULL,
		PRIMARY KEY (ID_Usuario)

)
GO


CREATE TABLE ANOTHER_CAT.tl_Agenda (
	ID_Agenda BIGINT IDENTITY(1,1) NOT NULL,
	Hora_Inicio TIME NULL,
	Hora_Fin TIME NULL,
	Dia VARCHAR(10),
	Fecha_Inicio DATETIME NULL,
	Fecha_Fin DATETIME,
		PRIMARY KEY(ID_Agenda)
)
GO

CREATE TABLE ANOTHER_CAT.tl_Asistencia (
	ID_Turno BIGINT NOT NULL,
	ID_Asistencia BIGINT IDENTITY(1,1) NOT NULL,
	Fecha DATETIME NULL,
	Bono VARCHAR(50) NULL,
	Atendido BIT NULL,
		PRIMARY KEY(ID_Turno)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Bono (
	ID_Bono BIGINT IDENTITY(1,1) NOT NULL,
	ID_Plan_Medico BIGINT NULL,
	Fecha_Compra DATETIME NULL,
	Afiliado_Compro BIGINT NULL, --Relacion para el que compro
	Afiliado_Utilizo BIGINT NULL,
	Numero_Consulta_Medica BIGINT NULL,
	Fecha_Impresion DATETIME NULL, -- Fecha que se utilizo el bono
		PRIMARY KEY(ID_Bono)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Consulta_Medica (
	ID_Turno BIGINT NOT NULL,
	Fecha DATETIME NULL,
	Sintomas VARCHAR(255) NULL,
	Diagnostico VARCHAR(255) NULL,
		PRIMARY KEY(ID_Turno)
)
GO



CREATE TABLE ANOTHER_CAT.tl_Especialidad (
	ID_Especialidad NUMERIC(18,0) NOT NULL,
	Descripcion VARCHAR(255) NULL, -- ej: cirugia cardiovascular
	ID_Tipo_Especialidad NUMERIC(18,0) NULL,
	Descripcion_Tipo_Especialidad VARCHAR(255) NULL, --ej: quirurgica
		PRIMARY KEY(ID_Especialidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Funcionalidad (
	ID_Funcionalidad BIGINT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(255),
		PRIMARY KEY(ID_Funcionalidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Funcionalidad_Rol (
	ID_Rol BIGINT NOT NULL,
	ID_Funcionalidad BIGINT NOT NULL,
		PRIMARY KEY(ID_Rol, ID_Funcionalidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Plan_Medico (
	ID_Plan_Medico BIGINT,
	Descripcion VARCHAR(255) NULL,
	Precio_Bono_Consulta NUMERIC(18,0) NULL,
	Precio_Bono_Farmacia NUMERIC(18,0) NULL
		PRIMARY KEY(ID_Plan_Medico)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Profesional (
	ID_Usuario BIGINT NOT NULL,
	Matricula BIGINT,
		PRIMARY KEY(ID_Usuario)
)
GO

CREATE TABLE ANOTHER_CAT.tl_Profesional_Agenda (
	ID_Profesional_Agenda BIGINT IDENTITY(1,1) NOT NULL,
	ID_Usuario BIGINT NULL,
	ID_Agenda BIGINT NULL,
		PRIMARY KEY(ID_Profesional_Agenda)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Profesional_Especialidad (
	ID_Profesional_Especialidad BIGINT IDENTITY(1,1) NOT NULL,
	ID_Usuario BIGINT NULL,
	Codigo_Especialidad NUMERIC(18,0) NULL,
		PRIMARY KEY(ID_Profesional_Especialidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Rol (
	ID_Rol BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(255) NOT NULL,
	Habilitado BIT, 
		PRIMARY KEY (ID_Rol)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Turno (
	ID_Turno BIGINT NOT NULL,
	Fecha DATETIME NULL,
	ID_Paciente BIGINT NULL,
	ID_Profesional BIGINT NULL,
	Estado BIT NULL,
		PRIMARY KEY(ID_Turno)
)
GO



CREATE TABLE ANOTHER_CAT.tl_Turno_Cancelado (
	ID_Turno BIGINT NOT NULL,
	Motivo_Cancelacion VARCHAR(255),
	Tipo_Cancelacion VARCHAR(255),
	Fecha_Cancelacion DATETIME, 
		PRIMARY KEY(ID_Turno)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Usuario (
	ID_Usuario BIGINT IDENTITY(1,1) NOT NULL,
	Username VARCHAR(255), 
	Password VARCHAR(255),
	Apellido VARCHAR(255),
	Tipo_Documento VARCHAR(50), -- DNI, LC (libreta civica) y LE (libreta de enrolamiento)
	Nro_Documento NUMERIC(18,0),
	Telefono NUMERIC(18,0),
	Direccion VARCHAR(255),
	Mail VARCHAR(255),
	Fecha_Nacimiento DATETIME,
	Sexo char(1), -- M: Masculino y F: Femenino
	Login_Fallidos TINYINT,
		PRIMARY KEY(ID_Usuario)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Usuario_Rol (
	ID_Rol BIGINT NOT NULL,
	ID_Usuario BIGINT NOT NULL,
		PRIMARY KEY(ID_Rol, ID_Usuario)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Cambio_Plan_Medico (
	ID_Cambio_Plan BIGINT NOT NULL,
	ID_Usuario BIGINT NOT NULL,
	Motivo VARCHAR(255),
	Fecha_Modificacion DATETIME, 
		PRIMARY KEY(ID_Cambio_Plan)
)
GO




-- Asignacion de FK



ALTER TABLE ANOTHER_CAT.tl_Afiliado WITH CHECK ADD
	CONSTRAINT fk_Afiliado_Plan_Medico
	FOREIGN KEY(ID_Plan_Medico)
	REFERENCES ANOTHER_CAT.tl_Plan_Medico(ID_Plan_Medico)


ALTER TABLE ANOTHER_CAT.tl_Afiliado WITH CHECK ADD
	CONSTRAINT fk_Afiliado_Usuario
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Usuario(ID_Usuario)



ALTER TABLE ANOTHER_CAT.tl_Asistencia WITH CHECK ADD
	CONSTRAINT fk_Asistencia_Turno
	FOREIGN KEY(ID_Turno)
	REFERENCES ANOTHER_CAT.tl_Turno(ID_Turno)



ALTER TABLE ANOTHER_CAT.tl_Bono WITH CHECK ADD
	CONSTRAINT fk_Bono_Afiliado_Compro
	FOREIGN KEY(Afiliado_Compro)
	REFERENCES ANOTHER_CAT.tl_Afiliado(ID_Usuario)



ALTER TABLE ANOTHER_CAT.tl_Bono WITH CHECK ADD
	CONSTRAINT fk_Bono_Afiliado_Utilizo
	FOREIGN KEY(Afiliado_Utilizo)
	REFERENCES ANOTHER_CAT.tl_Afiliado(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Bono WITH CHECK ADD
	CONSTRAINT fk_Bono_Plan_Medico
	FOREIGN KEY(ID_Plan_Medico)
	REFERENCES ANOTHER_CAT.tl_Plan_Medico(ID_Plan_Medico)



ALTER TABLE ANOTHER_CAT.tl_Consulta_Medica WITH CHECK ADD
	CONSTRAINT fk_Consulta_Medica_Asistencia
	FOREIGN KEY(ID_Turno)
	REFERENCES ANOTHER_CAT.tl_Asistencia(ID_Turno)


ALTER TABLE ANOTHER_CAT.tl_Profesional WITH CHECK ADD
	CONSTRAINT fk_Profesional_Usuario
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Usuario(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Profesional_Agenda WITH CHECK ADD
	CONSTRAINT fk_Profesional_Agenda_Agenda
	FOREIGN KEY(ID_Agenda)
	REFERENCES ANOTHER_CAT.tl_Agenda(ID_Agenda)

ALTER TABLE ANOTHER_CAT.tl_Profesional_Agenda WITH CHECK ADD
	CONSTRAINT fk_Profesional_Agenda_Profesional
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Profesional(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Profesional_Especialidad WITH CHECK ADD
	CONSTRAINT fk_Profesional_Especialidad_Especialidad
	FOREIGN KEY(Codigo_Especialidad)
	REFERENCES ANOTHER_CAT.tl_Especialidad(ID_Especialidad)



ALTER TABLE ANOTHER_CAT.tl_Profesional_Especialidad WITH CHECK ADD
	CONSTRAINT fk_Profesional_Especialidad_Profesional
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Profesional(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Turno WITH CHECK ADD
	CONSTRAINT fk_Turno_Afiliado
	FOREIGN KEY(ID_Paciente)
	REFERENCES ANOTHER_CAT.tl_Afiliado(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Turno WITH CHECK ADD
	CONSTRAINT fk_Turno_Profesional
	FOREIGN KEY(ID_Profesional)
	REFERENCES ANOTHER_CAT.tl_Profesional(ID_Usuario)


ALTER TABLE ANOTHER_CAT.tl_Turno_Cancelado WITH CHECK ADD
	CONSTRAINT fk_Turno_Cancelado_Turno
	FOREIGN KEY(ID_Turno)
	REFERENCES ANOTHER_CAT.tl_Turno(ID_Turno)



ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol WITH CHECK ADD
	CONSTRAINT fk_Usuario_Rol_Usuario
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Usuario(ID_Usuario)



ALTER TABLE ANOTHER_CAT.tl_Funcionalidad_Rol WITH CHECK ADD
	CONSTRAINT fk_Funcionalidad_Rol_Rol
	FOREIGN KEY(ID_Rol)
	REFERENCES ANOTHER_CAT.tl_Rol(ID_Rol)


ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol WITH CHECK ADD
	CONSTRAINT fk_Usuario_Rol_Rol
	FOREIGN KEY(ID_Rol)
	REFERENCES ANOTHER_CAT.tl_Rol(ID_Rol)


ALTER TABLE ANOTHER_CAT.tl_Funcionalidad_Rol WITH CHECK ADD
	CONSTRAINT fk_Funcionalidad_Rol_Funcionalidad
	FOREIGN KEY(ID_Funcionalidad)
	REFERENCES ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad)

ALTER TABLE ANOTHER_CAT.tl_Cambio_Plan_Medico WITH CHECK ADD
	CONSTRAINT fk_Cambio_Plan_Medico_Afiliado
	FOREIGN KEY(ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Afiliado(ID_Usuario)


-- Iniciar Migracion

-- Inicializacion de Fucnionalidades

SET IDENTITY_INSERT ANOTHER_CAT.tl_Funcionalidad ON;

INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (1,'ABM de Rol')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (2,'Registro de Usuario')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (3,'ABM Afiliado')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (4,'ABM Profesional')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (5,'ABM Especialidad Medica')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (6,'ABM Planes')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (7,'Registrar Agenda')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (8,'Comprar Bonos')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (9,'Pedir Turnos')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (10,'Registro de llegada de paciente')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (11,'Registro de resultado de atencion')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (12,'Cancelar atencion medica')
INSERT INTO ANOTHER_CAT.tl_Funcionalidad(ID_Funcionalidad, Descripcion)
	VALUES (13,'Listado Estadistico')

SET IDENTITY_INSERT ANOTHER_CAT.tl_Funcionalidad OFF;
GO

SET IDENTITY_INSERT ANOTHER_CAT.tl_Rol ON;

DECLARE @Administrativo_ID INT = 1
DECLARE @Afiliado_ID INT = 2
DECLARE @Profesional_ID INT = 3

INSERT INTO ANOTHER_CAT.tl_Rol (ID_Rol, Nombre, Habilitado)
	VALUES (@Administrativo_ID, 'Administrativo', 1)
INSERT INTO ANOTHER_CAT.tl_Rol (ID_Rol, Nombre, Habilitado)
	VALUES (@Afiliado_ID, 'Afiliado', 1)
INSERT INTO ANOTHER_CAT.tl_Rol (ID_Rol, Nombre, Habilitado)
	VALUES (@Profesional_ID, 'Profesional', 1)

--Tengo que asignarle Funcionalidad a los roles

--Para el administrativo
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 1)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 2)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 3)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 4)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 5)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 6)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 7)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 9)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 10)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Administrativo_ID, 13)

--Para los Afiliados

INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Afiliado_ID, 8)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Afiliado_ID, 9)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Afiliado_ID, 12)

--Para los profesionales

INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Profesional_ID, 7)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Profesional_ID, 11)
INSERT INTO ANOTHER_CAT.tl_Funcionalidad_Rol
	VALUES (@Profesional_ID, 12)

SET IDENTITY_INSERT ANOTHER_CAT.tl_Rol OFF;
GO


/*--Asginacion de usuarios al rol

--Administrativo

INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
	VALUES (1, 1)
INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
	VALUES (1, 2)
INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
	VALUES (1, 3)
--Afiliado
INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
	VALUES (2, 2)
--Profesional
INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
	VALUES (3, 3)*/











--Creo el usuario Admin
-- w23e en SHA256 = e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7

SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario ON;

DECLARE @Usuario_ID INT = 1
DECLARE @Administrativo_ID INT = 1

INSERT INTO ANOTHER_CAT.tl_Usuario (ID_Usuario, Username, Password)
	VALUES (@Usuario_ID, 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7')

INSERT INTO ANOTHER_CAT.tl_Usuario_Rol (ID_Rol,ID_Usuario)
	VALUES (@Administrativo_ID,@Usuario_ID)

SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario OFF;
GO


--Migracion de usuarios y afiliados


SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario ON;

INSERT INTO ANOTHER_CAT.tl_Usuario(ID_Usuario, Password, Username, Apellido, Tipo_Documento, Nro_Documento, Telefono, Direccion, Mail, Fecha_Nacimiento, Login_Fallidos)
SELECT DISTINCT Paciente_Dni,HASHBYTES('SHA2_256', 'afiliado'), Paciente_Nombre, Paciente_Apellido,'DNI', Paciente_Dni, Paciente_Telefono, Paciente_Direccion, Paciente_Mail, Paciente_Fecha_Nac, 0
FROM gd_esquema.Maestra

ALTER TABLE ANOTHER_CAT.tl_Afiliado
NOCHECK CONSTRAINT fk_Afiliado_Plan_Medico

INSERT INTO ANOTHER_CAT.tl_Afiliado(ID_Usuario, ID_Plan_Medico, Habilitado, Numero_Consulta_Medica)
SELECT DISTINCT Paciente_Dni, Plan_Med_Codigo, 1, 0
FROM gd_esquema.Maestra

ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol
NOCHECK CONSTRAINT fk_Usuario_Rol_Rol

INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
SELECT DISTINCT Paciente_Dni, 2
FROM gd_esquema.Maestra

SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario OFF;
GO


--Migracion Bono

ALTER TABLE ANOTHER_CAT.tl_Bono
NOCHECK CONSTRAINT fk_Bono_Plan_Medico


INSERT INTO ANOTHER_CAT.tl_Bono(ID_Plan_Medico, Fecha_Compra, Fecha_Impresion, Numero_Consulta_Medica, Afiliado_Compro, Afiliado_Utilizo)
SELECT DISTINCT Plan_Med_Codigo, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion, Bono_Consulta_Numero, (select ID_Usuario from ANOTHER_CAT.tl_Usuario U where U.Nro_Documento = Paciente_Dni), (select ID_Usuario from ANOTHER_CAT.tl_Usuario U where U.Nro_Documento = Paciente_Dni)  
FROM gd_esquema.Maestra
WHERE Compra_Bono_Fecha IS NOT NULL

-- Migracion de especialidad

INSERT INTO ANOTHER_CAT.tl_Especialidad(ID_Especialidad, Descripcion, ID_Tipo_Especialidad, Descripcion_Tipo_Especialidad)
SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL



-- Migracion plan medico

INSERT INTO ANOTHER_CAT.tl_Plan_Medico(ID_Plan_Medico, Descripcion, Precio_Bono_Consulta, Precio_Bono_Farmacia)
SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra



-- Migrar usuarios y profesionales

SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario ON;

INSERT INTO ANOTHER_CAT.tl_Usuario(ID_Usuario, Password, Username, Apellido, Tipo_Documento, Nro_Documento, Telefono, Direccion, Mail, Fecha_Nacimiento, Login_Fallidos)
SELECT DISTINCT Medico_Dni, HASHBYTES('SHA2_256', 'profesional'), Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Telefono, Medico_Direccion, Medico_Mail, Medico_Fecha_Nac, 0
FROM gd_esquema.Maestra 
WHERE Medico_Dni IS NOT NULL

INSERT INTO ANOTHER_CAT.tl_Profesional(ID_Usuario)
SELECT DISTINCT Medico_Dni
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL

ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol
NOCHECK CONSTRAINT fk_Usuario_Rol_Rol

INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
SELECT DISTINCT Medico_Dni, 3
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL

ALTER TABLE ANOTHER_CAT.tl_Profesional_Especialidad
NOCHECK CONSTRAINT fk_Profesional_Especialidad_Profesional

INSERT INTO ANOTHER_CAT.tl_Profesional_Especialidad(ID_Usuario, Codigo_Especialidad)
SELECT DISTINCT Medico_Dni, Especialidad_Codigo
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL

SET IDENTITY_INSERT ANOTHER_CAT.tl_Usuario OFF;
GO


-- Migracion Turno, Asistencia y Consulta Medica

ALTER TABLE ANOTHER_CAT.tl_Turno
NOCHECK CONSTRAINT fk_Turno_Afiliado

ALTER TABLE ANOTHER_CAT.tl_Turno
NOCHECK CONSTRAINT fk_Turno_Profesional

INSERT INTO ANOTHER_CAT.tl_Turno(ID_Turno, Fecha, ID_Paciente, ID_Profesional, Estado)
SELECT DISTINCT Turno_Numero, Turno_Fecha, Paciente_Dni, Medico_Dni, 1
FROM gd_esquema.Maestra
WHERE Turno_Numero IS NOT NULL

INSERT INTO ANOTHER_CAT.tl_Asistencia(ID_Turno, Fecha, Atendido)
SELECT DISTINCT Turno_Numero, Turno_Fecha, 1
FROM gd_esquema.Maestra
WHERE Consulta_Sintomas IS NOT NULL


INSERT INTO ANOTHER_CAT.tl_Consulta_Medica(ID_Turno, Fecha, Sintomas, Diagnostico)
SELECT DISTINCT Turno_Numero, Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades
FROM gd_esquema.Maestra
WHERE Consulta_Sintomas IS NOT NULL






