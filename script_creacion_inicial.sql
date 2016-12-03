USE GD2C2016
GO



-- Verifico si existe el schema, si no existe lo creo


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'ANOTHER_CAT')
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA [ANOTHER_CAT] AUTHORIZATION [gd]'
		PRINT 'Schema correctamente creado'

	END
GO


-- Verificacion secuencias


CREATE SEQUENCE ANOTHER_CAT.Afi As int START WITH 100 INCREMENT BY 100;
CREATE SEQUENCE ANOTHER_CAT.Mat As int START WITH 1 INCREMENT BY 1;
GO


-- Verificacion de tablas. Si existen las dropeo.


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



-- Creacion de tablas


CREATE TABLE ANOTHER_CAT.tl_Usuario (
	ID_Usuario BIGINT IDENTITY(1,1) NOT NULL,
	Username NVARCHAR(255) NULL,
	Password varbinary(255) NULL,
	Login_Fallidos TINYINT NOT NULL DEFAULT 0,
	Nombre VARCHAR(255) NULL,
	Apellido VARCHAR(255) NULL,
	Direccion VARCHAR(255) NULL,
	Telefono NUMERIC(18,0) NULL,
	Mail VARCHAR(255) NULL,
	Fecha_Nacimiento DATETIME NULL,
	Tipo_Documento VARCHAR(20) NOT NULL DEFAULT 'DNI',
	Nro_Documento NUMERIC(18,0) NULL,
	Sexo CHAR(1) NULL,
	Habilitado BIT NOT NULL DEFAULT 1,
		PRIMARY KEY (ID_Usuario)
)
GO

CREATE TABLE ANOTHER_CAT.tl_Profesional (
	ID_Profesional BIGINT NOT NULL,
	Matricula BIGINT NOT NULL DEFAULT 0,
	Horas_Acumuladas INT NOT NULL DEFAULT 0,
		PRIMARY KEY (ID_Profesional)
)
GO



CREATE TABLE ANOTHER_CAT.tl_Tipo_Especialidad (
	ID_Tipo_Especialidad NUMERIC(18,0) NOT NULL,
	Detalle VARCHAR(255), --ej: quirurgica
		PRIMARY KEY(ID_Tipo_Especialidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Especialidad (
	ID_Especialidad NUMERIC(18,0) NOT NULL,
	Descripcion VARCHAR(255) NULL, -- ej: cirugia cardiovascular
	ID_Tipo_Especialidad NUMERIC(18,0) NOT NULL,
		PRIMARY KEY(ID_Especialidad)
)
GO

CREATE TABLE ANOTHER_CAT.tl_Agenda (
	ID_Profesional BIGINT NOT NULL,
	Fecha DATETIME NOT NULL,
	ID_Especialidad NUMERIC (18,0),
	Inicio DATE NOT NULL,
	Fin DATE NOT NULL,
		PRIMARY KEY(ID_Profesional, Fecha, ID_Especialidad, Inicio, Fin)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Plan_Medico (
	ID_Plan_Medico NUMERIC(18,0) NOT NULL,
	Descripcion VARCHAR(255) NULL,
	Precio_Bono_Consulta NUMERIC(18,0) NULL,
	Precio_Bono_Farmacia NUMERIC(18,0) NULL,
	Cuota NUMERIC(18,2) NULL,
		PRIMARY KEY(ID_Plan_Medico)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Afiliado (
	ID_Afiliado BIGINT NOT NULL,
	ID_Plan_Medico NUMERIC(18,0) NOT NULL,
	Numero_Afiliado BIGINT NOT NULL,
	Estado_Civil VARCHAR(50) NOT NULL DEFAULT 'SOLTERO/A',
	Habilitado BIT NOT NULL DEFAULT 1,
	Cant_Hijos BIGINT NOT NULL DEFAULT 0,
	Numero_Consulta_Medica BIGINT NOT NULL DEFAULT 0,
		PRIMARY KEY (ID_Afiliado)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Compra_Bono (
	ID_Operacion BIGINT IDENTITY(1,1) NOT NULL,
	ID_Afiliado BIGINT NOT NULL, --El que lo compro, que puede ser diferente al que lo uso
	Cantidad_Bonos BIGINT,
	Fecha_Compra DATETIME NOT NULL,
	Fecha_Impresion DATETIME NOT NULL,
	Importe NUMERIC(18,2),
		PRIMARY KEY (ID_Operacion)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Bono (
	ID_Bono BIGINT IDENTITY(1,1) NOT NULL,
	Nro_Bono NUMERIC (18,0) NULL,
	ID_Operacion BIGINT NOT NULL,
	ID_Plan_Medico NUMERIC(18,0) NOT NULL,
	Nro_afiliado BIGINT NULL,
		PRIMARY KEY (ID_Bono)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Cambio_Plan (
	ID_Cambio BIGINT IDENTITY(1,1) NOT NULL,
	ID_Afiliado BIGINT NOT NULL,
	Fecha_Modificacion DATE, 
	Motivo VARCHAR(255),
	ID_Plan_Medico_Anterior NUMERIC(18,0) NOT NULL,
		PRIMARY KEY (ID_Cambio)
)
GO




CREATE TABLE ANOTHER_CAT.tl_Especialidad_Profesional (
	ID_Profesional BIGINT NOT NULL,
	ID_Especialidad NUMERIC(18,0) NOT NULL,
		PRIMARY KEY(ID_Profesional, ID_Especialidad)
)
GO



CREATE TABLE ANOTHER_CAT.tl_Turno (
	ID_Turno NUMERIC(18,0) NOT NULL,
	Fecha DATETIME NOT NULL,
	ID_Profesional BIGINT NOT NULL,
	ID_Afiliado BIGINT NOT NULL,
	ID_Especialidad NUMERIC(18,0) NOT NULL,
		PRIMARY KEY (ID_Turno)
)
GO

CREATE TABLE ANOTHER_CAT.tl_Tipo_Cancelacion (
	ID_Tipo_Cancelacion BIGINT IDENTITY (1,1) NOT NULL,
	Descripcion VARCHAR(255) NULL,
		PRIMARY KEY (ID_Tipo_Cancelacion)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Turno_Cancelacion (
	ID_Turno_Cancelado NUMERIC(18,0) NOT NULL,
	Motivo_Cancelacion VARCHAR(255) NOT NULL DEFAULT 'CANCELADO',
	Tipo_Cancelacion BIGINT NOT NULL, 
		PRIMARY KEY (ID_Turno_Cancelado)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Consulta_Medica (
	ID_Consulta BIGINT IDENTITY(1,1) NOT NULL,
	ID_Turno NUMERIC(18,0) NOT NULL,
	ID_Bono BIGINT  NOT NULL,
	Nro_Bono NUMERIC(18,0) NOT NULL,
	Sintomas VARCHAR(255) NULL,
	Diagnostico VARCHAR(255) NULL,
	Registro_Llegada DATETIME NOT NULL,
	Registro_Atencion DATETIME NULL,
		PRIMARY KEY (ID_Consulta)
)
GO



CREATE TABLE ANOTHER_CAT.tl_Funcionalidad (
	ID_Funcionalidad BIGINT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(255),
		PRIMARY KEY (ID_Funcionalidad)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Rol (
	ID_Rol BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(255) NULL,
	Habilitado BIT NOT NULL, 
		PRIMARY KEY (ID_Rol)
)
GO




CREATE TABLE ANOTHER_CAT.tl_Usuario_Rol (
	ID_Rol BIGINT NOT NULL,
	ID_Usuario BIGINT NOT NULL,
		PRIMARY KEY(ID_Rol, ID_Usuario)
)
GO


CREATE TABLE ANOTHER_CAT.tl_Rol_Funcionalidad (
	ID_Rol BIGINT NOT NULL,
	ID_Funcionalidad BIGINT NOT NULL,
		PRIMARY KEY(ID_Rol, ID_Funcionalidad),
	FuncionalidadXRol_activo bit NOT NULL default(1)
)

go



-- Asignacion FK

--OK
ALTER TABLE ANOTHER_CAT.tl_Profesional WITH CHECK ADD
	CONSTRAINT FK_Profesional_Usuario FOREIGN KEY (ID_Profesional)
	REFERENCES ANOTHER_CAT.tl_Usuario (ID_Usuario)


--OK
ALTER TABLE ANOTHER_CAT.tl_Especialidad WITH CHECK ADD
	CONSTRAINT FK_Especialidad_Tipo_Especialidad FOREIGN KEY (ID_Tipo_Especialidad)
	REFERENCES ANOTHER_CAT.tl_Tipo_Especialidad (ID_Tipo_Especialidad)

--OK
ALTER TABLE ANOTHER_CAT.tl_Agenda WITH CHECK ADD	
	CONSTRAINT FK_Agenda_Especialidad FOREIGN KEY (ID_Especialidad)
	REFERENCES ANOTHER_CAT.tl_Especialidad (ID_Especialidad)
--OK
ALTER TABLE ANOTHER_CAT.tl_Agenda WITH CHECK ADD
	CONSTRAINT FK_Agenda_Profesional FOREIGN KEY (ID_Profesional)
	REFERENCES ANOTHER_CAT.tl_Profesional (ID_Profesional)

--OK
ALTER TABLE ANOTHER_CAT.tl_Afiliado WITH CHECK ADD
	CONSTRAINT FK_Afiliado_Plan_Medico FOREIGN KEY (ID_Plan_Medico)
	REFERENCES ANOTHER_CAT.tl_Plan_Medico (ID_Plan_Medico)

--OK
ALTER TABLE ANOTHER_CAT.tl_Afiliado WITH CHECK ADD
	CONSTRAINT FK_Afiliado_Usuario FOREIGN KEY (ID_Afiliado) 
	REFERENCES ANOTHER_CAT.tl_Usuario (ID_Usuario)

--OK
ALTER TABLE ANOTHER_CAT.tl_Compra_Bono WITH CHECK ADD
	CONSTRAINT FK_Compra_Bono_Afiliado FOREIGN KEY (ID_Afiliado)
	REFERENCES ANOTHER_CAT.tl_Afiliado (ID_Afiliado)


--OK
ALTER TABLE ANOTHER_CAT.tl_Bono WITH CHECK ADD
	CONSTRAINT FK_Bono_Compra_Bono FOREIGN KEY (ID_Operacion)
	REFERENCES ANOTHER_CAT.tl_Compra_Bono (ID_Operacion)

--OK

ALTER TABLE ANOTHER_CAT.tl_Bono WITH CHECK ADD
	CONSTRAINT FK_Bono_Plan_Medico FOREIGN KEY (ID_Plan_Medico)
	REFERENCES ANOTHER_CAT.tl_Plan_Medico (ID_Plan_Medico)

--OK
ALTER TABLE ANOTHER_CAT.tl_Cambio_Plan WITH CHECK ADD
	CONSTRAINT FK_Cambio_Plan_Afiliado FOREIGN KEY (ID_Afiliado)
	REFERENCES ANOTHER_CAT.tl_Afiliado (ID_Afiliado)


--ok
ALTER TABLE ANOTHER_CAT.tl_Cambio_Plan WITH CHECK ADD
	CONSTRAINT FK_Cambio_Plan_Medico FOREIGN KEY (ID_Plan_Medico_Anterior)
	REFERENCES ANOTHER_CAT.tl_Plan_Medico (ID_Plan_Medico)

--OK
ALTER TABLE ANOTHER_CAT.tl_Especialidad_Profesional WITH CHECK ADD
	CONSTRAINT FK_Especialidad_Profesional_Especialidad FOREIGN KEY (ID_Especialidad)
	REFERENCES ANOTHER_CAT.tl_Especialidad (ID_Especialidad)

--OK
ALTER TABLE ANOTHER_CAT.tl_Especialidad_Profesional WITH CHECK ADD
	CONSTRAINT FK_Especialidad_Profesional_Profesional FOREIGN KEY (ID_Profesional)
	REFERENCES ANOTHER_CAT.tl_Profesional (ID_Profesional)

--OK
ALTER TABLE ANOTHER_CAT.tl_Turno WITH CHECK ADD	
	CONSTRAINT FK_Turno_Especialidad FOREIGN KEY (ID_Especialidad)
	REFERENCES ANOTHER_CAT.tl_Especialidad (ID_Especialidad)

--OK
ALTER TABLE ANOTHER_CAT.tl_Turno WITH CHECK ADD
	CONSTRAINT FK_Turno_Profesional FOREIGN KEY (ID_Profesional)
	REFERENCES ANOTHER_CAT.tl_Profesional (ID_Profesional)

--OK
ALTER TABLE ANOTHER_CAT.tl_Turno WITH CHECK ADD
	CONSTRAINT FK_Turno_Afiliado FOREIGN KEY (ID_Afiliado)
	REFERENCES ANOTHER_CAT.tl_Afiliado (ID_Afiliado)

--OK
ALTER TABLE ANOTHER_CAT.tl_Turno_Cancelacion WITH CHECK ADD
	CONSTRAINT FK_Cancelacion_Turno FOREIGN KEY (ID_Turno_Cancelado)
	REFERENCES ANOTHER_CAT.tl_Turno (ID_Turno)


--OK
ALTER TABLE ANOTHER_CAT.tl_Turno_Cancelacion WITH CHECK ADD
	CONSTRAINT FK_Cancelacion_Tipo_Cancelacion FOREIGN KEY (Tipo_Cancelacion)
	REFERENCES ANOTHER_CAT.tl_Tipo_Cancelacion (ID_Tipo_Cancelacion)


--ok
ALTER TABLE ANOTHER_CAT.tl_Consulta_Medica WITH CHECK ADD
	CONSTRAINT FK_Consulta_Medica_Bono FOREIGN KEY (ID_Bono)
	REFERENCES ANOTHER_CAT.tl_Bono (ID_Bono)


--ok
ALTER TABLE ANOTHER_CAT.tl_Consulta_Medica WITH CHECK ADD
	CONSTRAINT FK_Consulta_Medica_Turno FOREIGN KEY (ID_Turno)
	REFERENCES ANOTHER_CAT.tl_Turno (ID_Turno)


--OK
ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol WITH CHECK ADD
	CONSTRAINT FK_Usuario_Rol_Usuario FOREIGN KEY (ID_Usuario)
	REFERENCES ANOTHER_CAT.tl_Usuario (ID_Usuario)


--OK
ALTER TABLE ANOTHER_CAT.tl_Usuario_Rol WITH CHECK ADD
	CONSTRAINT FK_Usuario_Rol_Rol FOREIGN KEY (ID_Rol)
	REFERENCES ANOTHER_CAT.tl_Rol (ID_Rol)


--ok
ALTER TABLE ANOTHER_CAT.tl_Rol_Funcionalidad WITH CHECK ADD
	CONSTRAINT FK_Rol_Funcionaloidad_Rol FOREIGN KEY (ID_Rol)
	REFERENCES ANOTHER_CAT.tl_Rol (ID_Rol)


--ok
ALTER TABLE ANOTHER_CAT.tl_Rol_Funcionalidad WITH CHECK ADD
	CONSTRAINT FK_Rol_Funcionalidad_Funcionalidad FOREIGN KEY (ID_Funcionalidad)
	REFERENCES ANOTHER_CAT.tl_Funcionalidad (ID_Funcionalidad)




GO


-- Empiezo Migracion

INSERT INTO ANOTHER_CAT.tl_Rol(Nombre, Habilitado)
VALUES
('ADMINISTRATIVO', 1),
('PROFESIONAL', 1),
('AFILIADO', 1),
('ADMINISTRADOR',1);

INSERT INTO ANOTHER_CAT.tl_Funcionalidad(Descripcion)
VALUES
('ABM DE AFILIADO'),
('ABM ESPECIALIDAD MEDICA'),
('ABM PLANES MEDICOS'),
('ABM DE PROFESIONAL'),
('ABM DE ROL'),
('CANCELAR ATENCION MEDICA'),
('COMPRAR BONOS'),
('LISTADO ESTADISTICO'),
('PEDIR TURNO'),
('REGISTRAR AGENDA DE PROFESIONAL'),
('REGISTRO DE LLEGADA'),
('REGISTRO DE RESULTADO DE ATENCION');


DECLARE @ID_ROL BIGINT;
DECLARE @ID_USUARIO BIGINT;

--Funcionalidad para administrativo

SELECT @ID_ROL = ID_Rol FROM ANOTHER_CAT.tl_Rol WHERE Nombre = 'ADMINISTRATIVO';
INSERT INTO ANOTHER_CAT.tl_Rol_Funcionalidad(ID_Rol, ID_Funcionalidad)
VALUES
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE AFILIADO')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM ESPECIALIDAD MEDICA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM PLANES MEDICOS')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE PROFESIONAL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE ROL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRO DE LLEGADA'));

-- Funcionalidades para el afiliado

SELECT @ID_ROL = ID_Rol FROM ANOTHER_CAT.tl_Rol WHERE Nombre = 'AFILIADO';
INSERT INTO ANOTHER_CAT.tl_Rol_Funcionalidad(ID_Rol, ID_Funcionalidad)
VALUES
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'CANCELAR ATENCION MEDICA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'COMPRAR BONOS')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'PEDIR TURNO'));


--Funcionalidades para el profesional

SELECT @ID_ROL = ID_Rol FROM ANOTHER_CAT.tl_Rol WHERE Nombre = 'PROFESIONAL';
INSERT INTO ANOTHER_CAT.tl_Rol_Funcionalidad(ID_Rol, ID_Funcionalidad)
VALUES
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRAR AGENDA DE PROFESIONAL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'CANCELAR ATENCION MEDICA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRO DE RESULTADO DE ATENCION'));


-- Funcionalidad para el administrador

SELECT @ID_ROL = ID_Rol FROM ANOTHER_CAT.tl_Rol WHERE Nombre = 'ADMINISTRADOR';
INSERT INTO ANOTHER_CAT.tl_Rol_Funcionalidad(ID_Rol, ID_Funcionalidad)
VALUES
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE AFILIADO')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM ESPECIALIDAD MEDICA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM PLANES MEDICOS')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE PROFESIONAL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'ABM DE ROL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRO DE LLEGADA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'CANCELAR ATENCION MEDICA')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'COMPRAR BONOS')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'PEDIR TURNO')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRAR AGENDA DE PROFESIONAL')),
(@ID_ROL, (SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Funcionalidad WHERE Descripcion = 'REGISTRO DE RESULTADO DE ATENCION'));

--Tipo cancelacion 

INSERT INTO ANOTHER_CAT.tl_Tipo_Cancelacion (descripcion)
VALUES 
('CANCELADO POR EL PACIENTE'),
('CANCELADO POR EL PROFESIONAL');

--Ejemplo usuario administrativo

DECLARE @input as NVARCHAR(max) = 'w23e';

INSERT INTO ANOTHER_CAT.tl_Usuario (Nombre, Nro_Documento, Username, Password)
VALUES ('ADMINISTRATIVO 1', 32173648, 'SEBASTIAN', HASHBYTES('SHA2_256', @input));


SELECT @ID_USUARIO = ID_USUARIO
FROM ANOTHER_CAT.tl_Usuario
WHERE Username = 'SEBASTIAN';

INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
VALUES (@ID_USUARIO, 1);

--Ejemplo para usuario administrador

INSERT INTO ANOTHER_CAT.tl_Usuario(Nombre, Username, Password)
VALUES ('ADMINISTRADOR', 'ADMIN' , HASHBYTES('SHA2_256', @input));

SELECT @ID_USUARIO = ID_USUARIO
FROM ANOTHER_CAT.tl_Usuario
WHERE Username = 'ADMIN';


INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
VALUES (@ID_USUARIO, @ID_ROL);


DECLARE @MIGRACION_AFILIADO TABLE
	(
			Nro_Documento NUMERIC(18,0) NULL,
			Nombre VARCHAR(255) NULL,
			Apellido VARCHAR(255) NULL,
			Direccion VARCHAR(255) NULL,
			Telefono NUMERIC(18,0) NULL,
			Mail VARCHAR(255) NULL,
			Fecha_Nacimiento DATETIME NULL,
			Tipo_Documento VARCHAR(20) NOT NULL DEFAULT 'DNI',
			ID_Plan_Medico NUMERIC(18,0) NULL,
			Descripcion VARCHAR(255) NULL,
			Cuota NUMERIC(18,2) NULL,
			Precio_Bono_Consulta NUMERIC(18,0) NULL,
			Precio_Bono_Farmacia NUMERIC(18,0) NULL
);

INSERT INTO @MIGRACION_AFILIADO (Nro_Documento, Nombre, Apellido, Direccion, Telefono, Mail, Fecha_Nacimiento, ID_Plan_Medico, Descripcion, Precio_Bono_Consulta,Precio_Bono_Farmacia)
SELECT DISTINCT (Paciente_Dni), Paciente_Nombre, Paciente_Apellido, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra
WHERE Paciente_Dni IS NOT NULL;

INSERT INTO ANOTHER_CAT.tl_Plan_Medico (ID_Plan_Medico, Descripcion, Precio_Bono_Consulta, Precio_Bono_Farmacia)
SELECT DISTINCT (ID_Plan_Medico), Descripcion, Precio_Bono_Consulta, Precio_Bono_Farmacia
FROM @MIGRACION_AFILIADO;

INSERT INTO ANOTHER_CAT.tl_Usuario (Username,Password,Nombre, Apellido, Direccion, Telefono, Mail, Fecha_Nacimiento, Nro_Documento)
SELECT Nombre+Apellido, HASHBYTES('SHA2_256', @input),Nombre, Apellido, Direccion, Telefono, Mail, Fecha_Nacimiento, Nro_Documento
FROM @MIGRACION_AFILIADO;


INSERT INTO ANOTHER_CAT.tl_Afiliado (Numero_Afiliado, ID_Plan_Medico, ID_Afiliado)
SELECT ((NEXT VALUE FOR ANOTHER_CAT.Afi)+1), ID_Plan_Medico, (SELECT ID_Usuario FROM ANOTHER_CAT.tl_Usuario AS P WHERE P.Nro_Documento = MA.Nro_Documento)
FROM @MIGRACION_AFILIADO AS MA;


INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
SELECT ID_Usuario, 3
FROM ANOTHER_CAT.tl_Usuario
WHERE Username = Nombre+Apellido


DECLARE @MIGRACION_PROFESIONAL TABLE (
	Nombre VARCHAR(255),
	Apellido VARCHAR(255),
	Nro_Documento NUMERIC(18,0),
	Direccion VARCHAR(255),
	Telefono NUMERIC(18,0),
	Mail VARCHAR(255),
	Fecha_Nacimiento DATETIME
);



INSERT INTO @MIGRACION_PROFESIONAL (Nro_Documento,Nombre, Apellido, Direccion, Telefono, Mail, Fecha_Nacimiento)
SELECT DISTINCT (Medico_Dni), Medico_Nombre, Medico_Apellido, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL;



INSERT INTO ANOTHER_CAT.tl_Usuario (Username, Password,Nombre, Apellido, Direccion, Nro_Documento, Telefono, Mail, Fecha_Nacimiento)
SELECT Nombre+Apellido, HASHBYTES('SHA2_256', @input), Nombre, Apellido, Direccion, Nro_Documento, Telefono, Mail, Fecha_Nacimiento
FROM @MIGRACION_PROFESIONAL;



INSERT INTO ANOTHER_CAT.tl_Profesional (ID_Profesional, Matricula, Horas_Acumuladas)
SELECT (SELECT ID_Usuario FROM ANOTHER_CAT.tl_Usuario AS P WHERE P.Nro_Documento = M.Nro_Documento), (NEXT VALUE FOR ANOTHER_CAT.Mat), 0
FROM @MIGRACION_PROFESIONAL AS M;



INSERT INTO ANOTHER_CAT.tl_Usuario_Rol(ID_Usuario, ID_Rol)
SELECT ID_Usuario, 2
FROM ANOTHER_CAT.tl_Usuario
WHERE Username = Nombre+Apellido


DECLARE @MIGRACION_ESPECIALIDAD TABLE (
	ID_Especialidad NUMERIC(18,0),
	Detalle VARCHAR(255),
	ID_Tipo_Especialidad NUMERIC(18,0),
	Tipo_Especialidad_Detalle VARCHAR(255)
);

INSERT INTO @MIGRACION_ESPECIALIDAD (ID_Especialidad, Detalle, ID_Tipo_Especialidad, Tipo_Especialidad_Detalle)
SELECT DISTINCT (Especialidad_Codigo), Especialidad_Descripcion, Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra;

INSERT INTO ANOTHER_CAT.tl_Tipo_Especialidad(ID_Tipo_Especialidad, Detalle)
SELECT DISTINCT (ID_Tipo_Especialidad), Tipo_Especialidad_Detalle
FROM @MIGRACION_ESPECIALIDAD
WHERE ID_Tipo_Especialidad IS NOT NULL;

INSERT INTO ANOTHER_CAT.tl_Especialidad (ID_Especialidad, ID_Tipo_Especialidad, Descripcion)
SELECT DISTINCT (ID_Especialidad), ID_Tipo_Especialidad, Tipo_Especialidad_Detalle
FROM @MIGRACION_ESPECIALIDAD
WHERE ID_Tipo_Especialidad IS NOT NULL;


INSERT INTO ANOTHER_CAT.tl_Especialidad_Profesional(ID_Profesional, ID_Especialidad)
SELECT DISTINCT PR.ID_Profesional, M.Especialidad_Codigo
FROM ANOTHER_CAT.tl_Usuario U JOIN ANOTHER_CAT.tl_Profesional PR ON (U.ID_Usuario = PR.ID_Profesional) JOIN gd_esquema.Maestra M ON (U.Nro_Documento = M.Medico_Dni);


DECLARE @MIGRACION_CONSULTA TABLE (
	ID_Afiliado BIGINT,
	ID_Profesional BIGINT,
	ID_Especialidad NUMERIC(18,0),
	Fecha_Turno DATETIME, 
	Nro_Turno NUMERIC(18,0),
	Fecha_Compra DATETIME,
	Fecha_Impresion DATETIME,
	Bono_Numero NUMERIC(18,0),
	Sintomas VARCHAR(255),
	Diagnostico VARCHAR(255),
	Importe NUMERIC(18,2)
);

	DECLARE @COMPRA_BONO TABLE (
	ID_Compra_Bono BIGINT IDENTITY(1,1),
	ID_Afiliado BIGINT,
	Nro_Bono NUMERIC(18,0),
	Fecha_Compra DATETIME,
	Fecha_Impresion DATETIME,
	Cantidad_Bonos BIGINT,
	Importe NUMERIC(18,2)
);

	DECLARE @CANTIDAD_CONSULTAS TABLE (
	Afiliado NUMERIC(18,0),
	Cantidad BIGINT
);


INSERT INTO @MIGRACION_CONSULTA(ID_Afiliado, ID_Profesional, ID_Especialidad, Fecha_Turno, Nro_Turno, Fecha_Compra, Fecha_Impresion, Bono_Numero, Sintomas, Diagnostico, Importe)
SELECT (SELECT ID_Usuario FROM ANOTHER_CAT.tl_Usuario AS P WHERE P.Nro_Documento = M.Paciente_Dni),
	   (SELECT ID_Usuario FROM ANOTHER_CAT.tl_Usuario AS P2 WHERE P2.Nro_Documento = M.Medico_Dni),
	   Especialidad_Codigo, Turno_Fecha, Turno_Numero, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion, Bono_Consulta_Numero,Consulta_Sintomas, Consulta_Enfermedades, Plan_Med_Precio_Bono_Consulta
FROM gd_esquema.Maestra M;

INSERT INTO ANOTHER_CAT.tl_Turno (ID_Turno, Fecha, ID_Profesional, ID_Afiliado, ID_Especialidad)
SELECT Nro_Turno, Fecha_Turno, ID_Profesional, ID_Afiliado, ID_Especialidad
FROM @MIGRACION_CONSULTA
WHERE (Sintomas IS NULL AND Fecha_Compra IS NULL AND Nro_Turno IS NOT NULL);

INSERT INTO @COMPRA_BONO (ID_Afiliado, Nro_Bono, Fecha_Compra, Fecha_Impresion, Cantidad_Bonos, Importe)
SELECT ID_Afiliado, Bono_Numero, Fecha_Compra, Fecha_Impresion, count(*), (COUNT(*)*Importe)
FROM @MIGRACION_CONSULTA AS MC
WHERE MC.Fecha_Turno IS NULL
GROUP BY ID_Afiliado, Bono_Numero, Fecha_Compra, Fecha_Impresion, Importe;

INSERT INTO ANOTHER_CAT.tl_Compra_Bono (ID_Afiliado, Fecha_Compra, Fecha_Impresion, Cantidad_Bonos, Importe)
SELECT ID_Afiliado, Fecha_Compra, Fecha_Impresion, Cantidad_Bonos, Importe
FROM @COMPRA_BONO;

INSERT INTO ANOTHER_CAT.tl_Bono (ID_Operacion, ID_Plan_Medico, Nro_afiliado, Nro_Bono)
SELECT ID_Compra_Bono, ID_Plan_Medico, Numero_Afiliado, Nro_Bono
FROM @COMPRA_BONO AS CB JOIN ANOTHER_CAT.tl_Afiliado AS A ON (CB.ID_Afiliado = A.ID_Afiliado);


INSERT INTO ANOTHER_CAT.tl_Consulta_Medica (ID_Bono, ID_Turno, Nro_Bono, Sintomas, Diagnostico, Registro_Llegada, Registro_Atencion)
SELECT (SELECT ID_Bono FROM ANOTHER_CAT.tl_Bono B WHERE MC.Bono_Numero = B.Nro_Bono), Nro_Turno, Bono_Numero, Sintomas, Diagnostico, Fecha_Turno, Fecha_Turno
FROM @MIGRACION_CONSULTA AS MC
WHERE Fecha_Compra IS  NULL AND Fecha_Impresion IS NOT NULL;

INSERT INTO @CANTIDAD_CONSULTAS (Afiliado, Cantidad)
SELECT DISTINCT (ID_Afiliado), COUNT(C.ID_Turno)
FROM ANOTHER_CAT.tl_Consulta_Medica AS C JOIN ANOTHER_CAT.tl_Turno AS T ON (C.ID_Turno = T.ID_Turno)
GROUP BY (ID_Afiliado);

UPDATE ANOTHER_CAT.tl_Afiliado
SET Numero_Consulta_Medica = (SELECT Cantidad FROM @CANTIDAD_CONSULTAS WHERE ID_Afiliado = Afiliado);


INSERT INTO ANOTHER_CAT.tl_Agenda (ID_Profesional, Fecha, ID_Especialidad, Inicio, Fin)
SELECT DISTINCT P.ID_Profesional, Fecha, EP.ID_Especialidad, '2015-01-01', '2015-12-30'
FROM ANOTHER_CAT.tl_Profesional AS P JOIN ANOTHER_CAT.tl_Especialidad_Profesional AS EP ON (P.ID_Profesional = EP.ID_Profesional) JOIN
     ANOTHER_CAT.tl_Turno AS T ON (EP.ID_Profesional = T.ID_Profesional);

GO

--Procedimientos de listado estadistico

--Especialidades con mas cancelaciones de afiliados y profesionales (punto 1)
--En principio no va a aparecer nada, porque se supone que todos los turnos fueron atendidos.

IF OBJECT_ID('[ANOTHER_CAT].[SP_Especialidades_Mas_Canceladas]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Especialidades_Mas_Canceladas
GO


CREATE PROCEDURE ANOTHER_CAT.SP_Especialidades_Mas_Canceladas
@ANIO INT,
@SEMESTRE INT,
@MES INT

AS
BEGIN

SELECT TOP 5 COUNT(DISTINCT T.ID_Turno) 'Cantidad Turnos',
(SELECT E.Descripcion FROM ANOTHER_CAT.tl_Especialidad E WHERE E.ID_Especialidad = T.ID_Especialidad) 'Especialidad'

FROM ANOTHER_CAT.tl_Turno T INNER JOIN ANOTHER_CAT.tl_Turno_Cancelacion C ON T.ID_Turno = C.ID_Turno_Cancelado
WHERE (
((@SEMESTRE = 1) AND (@MES = 0) AND YEAR(T.Fecha) = @ANIO AND MONTH(T.Fecha) < 7 AND T.Fecha < GETDATE())
OR
((@SEMESTRE = 1) AND (@MES <> 0) AND YEAR(T.Fecha) = @ANIO AND MONTH(T.Fecha) = @MES AND T.Fecha < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES = 0) AND YEAR(T.Fecha) = @ANIO AND MONTH(T.Fecha) >= 7 AND T.Fecha < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES <> 0) AND YEAR(T.Fecha) = @ANIO AND MONTH(T.Fecha) = @MES AND T.Fecha < GETDATE())
)
GROUP BY T.ID_Especialidad
ORDER BY 'Cantidad Turnos' DESC

END;
GO


-- Profesional mas consultado por plan (2do punto en enunciado)

IF OBJECT_ID('[ANOTHER_CAT].[SP_Profesional_Mas_Consultas_Plan]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Profesional_Mas_Consultas_Plan
GO


CREATE PROCEDURE ANOTHER_CAT.SP_Profesional_Mas_Consultas_Plan
@PLAN NUMERIC(18,0),
@ANIO INT,
@SEMESTRE INT,
@MES INT

AS 
BEGIN

SELECT TOP 5 COUNT(T.ID_Turno) 'Cantidad Turnos',
(SELECT PM.Descripcion FROM ANOTHER_CAT.tl_Plan_Medico PM WHERE PM.ID_Plan_Medico = A.ID_Plan_Medico) 'Plan Medico',
(SELECT PR.Matricula FROM ANOTHER_CAT.tl_Profesional PR WHERE PR.ID_Profesional = T.ID_Profesional) 'Matricula Profesional',
(SELECT ES.Descripcion FROM ANOTHER_CAT.tl_Especialidad ES WHERE ES.ID_Especialidad = T.ID_Especialidad) 'Especialidad'

FROM ANOTHER_CAT.tl_Consulta_Medica CM LEFT JOIN ANOTHER_CAT.tl_Turno T ON T.ID_Turno = CM.ID_Turno
INNER JOIN ANOTHER_CAT.tl_Afiliado A ON T.ID_Afiliado = A.ID_Afiliado
WHERE (
((@SEMESTRE = 1) AND (@MES = 0) AND YEAR(T.Fecha)=@ANIO AND MONTH(T.Fecha) < 7 AND
T.Fecha < GETDATE() AND CM.Registro_Atencion IS NOT NULL AND A.ID_Plan_Medico = @PLAN)
OR
((@SEMESTRE = 1) AND (@MES <> 0) AND YEAR(T.Fecha)=@ANIO AND MONTH(T.Fecha) = @MES AND
T.Fecha < GETDATE() AND CM.Registro_Atencion IS NOT NULL AND A.ID_Plan_Medico = @PLAN)
OR
((@SEMESTRE = 2) AND (@MES = 0) AND YEAR(T.Fecha)=@ANIO AND MONTH(T.Fecha) >= 7 AND
T.Fecha < GETDATE() AND CM.Registro_Atencion IS NOT NULL AND A.ID_Plan_Medico = @PLAN)
OR
((@SEMESTRE = 2) AND (@MES <> 0) AND YEAR(T.Fecha)=@ANIO AND MONTH(T.Fecha) = @MES AND
T.Fecha < GETDATE() AND CM.Registro_Atencion IS NOT NULL AND A.ID_Plan_Medico = @PLAN)
)
GROUP BY A.ID_Plan_Medico, T.ID_Profesional, T.ID_Especialidad
ORDER BY 'Cantidad Turnos' DESC

END;
GO


-- Profesinonal con menos horas trabajadas (punto 3 en el ununciado)

IF OBJECT_ID('[ANOTHER_CAT].[SP_Profesional_Menos_Trabajo]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Profesional_Menos_Trabajo
GO


CREATE PROCEDURE ANOTHER_CAT.SP_Profesional_Menos_Trabajo
@ESPECIALIDAD NUMERIC(18,0),
@ANIO INT,
@SEMESTRE INT,
@MES INT

AS
BEGIN

SELECT TOP 5 COUNT(DISTINCT AG.Fecha)*0.5 'Horas Trabajadas',
(SELECT PR.Matricula FROM ANOTHER_CAT.tl_Profesional PR WHERE PR.ID_Profesional = AG.ID_Profesional) 'Matricula Profesional'

FROM ANOTHER_CAT.tl_Agenda AG
WHERE (
((@SEMESTRE = 1) AND (@MES = 0) AND YEAR(AG.Fecha) = @ANIO AND MONTH(AG.Fecha) < 7 AND AG.Fecha < GETDATE() AND AG.ID_Especialidad=@ESPECIALIDAD)
OR
((@SEMESTRE = 1) AND (@MES <> 0) AND YEAR(AG.Fecha) = @ANIO AND MONTH(AG.Fecha) = @MES AND AG.Fecha < GETDATE() AND AG.ID_Especialidad=@ESPECIALIDAD)
OR
((@SEMESTRE = 2) AND (@MES = 0) AND YEAR(AG.Fecha) = @ANIO AND MONTH(AG.Fecha) >= 7 AND AG.Fecha < GETDATE() AND AG.ID_Especialidad=@ESPECIALIDAD)
OR
((@SEMESTRE = 2) AND (@MES <> 0) AND YEAR(AG.Fecha) = @ANIO AND MONTH(AG.Fecha) = @MES AND AG.Fecha < GETDATE() AND AG.ID_Especialidad=@ESPECIALIDAD)
)
GROUP BY AG.ID_Profesional
ORDER BY 'Horas Trabajadas' ASC


END;
GO


-- TOP 5 de especilaidad con mas bonos consulta (5to en el enunciado)

IF OBJECT_ID('[ANOTHER_CAT].[SP_Especilidad_Mas_Bonos]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Especilidad_Mas_Bonos
GO


CREATE PROCEDURE ANOTHER_CAT.SP_Especilidad_Mas_Bonos
@ANIO INT,
@SEMESTRE INT,
@MES INT

AS
BEGIN

SELECT TOP 5 COUNT(cm.ID_Bono) 'Cantidad Bonos',
(SELECT es.Descripcion FROM ANOTHER_CAT.tl_Especialidad es WHERE es.ID_Especialidad = tu.ID_Especialidad) 'Especialidad'

FROM ANOTHER_CAT.tl_Consulta_Medica cm LEFT JOIN ANOTHER_CAT.tl_Turno tu ON(cm.ID_Turno = tu.ID_Turno)
WHERE (
((@SEMESTRE = 1) AND (@MES = 0) AND YEAR(CM.Registro_Llegada) = @ANIO AND MONTH(CM.Registro_Llegada) < 7 AND CM.Registro_Llegada < GETDATE())
OR
((@SEMESTRE = 1) AND (@MES <> 0) AND YEAR(CM.Registro_Llegada) = @ANIO AND MONTH(CM.Registro_Llegada) = @MES AND CM.Registro_Llegada < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES = 0) AND YEAR(CM.Registro_Llegada) = @ANIO AND MONTH(CM.Registro_Llegada) >= 7 AND CM.Registro_Llegada < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES <> 0) AND YEAR(CM.Registro_Llegada) = @ANIO AND MONTH(CM.Registro_Llegada) = @MES AND CM.Registro_Llegada < GETDATE())
)
GROUP BY tu.ID_Especialidad
ORDER BY 'Cantidad Bonos' DESC;

END;
GO

--TOP 5 de afiliado con mayor cantidad de bonos comprados (4ta en el enunciado)

IF OBJECT_ID('[ANOTHER_CAT].[SP_Afiliados_Mas_Bonos]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Afiliados_Mas_Bonos
GO


CREATE PROCEDURE ANOTHER_CAT.SP_Afiliados_Mas_Bonos
@ANIO INT,
@SEMESTRE INT,
@MES INT

AS
BEGIN

SELECT TOP 5 SUM(B.Cantidad_Bonos) 'Bonos Comprados', A.Numero_Afiliado,
(CASE WHEN RIGHT(CONVERT(VARCHAR(20), A.Numero_Afiliado), 2) = '01' THEN 'Afiliado Raiz'
ELSE 'Grupo Familiar' END) 'Tipo Afiliado'

FROM ANOTHER_CAT.tl_Compra_Bono B INNER JOIN ANOTHER_CAT.tl_Afiliado A ON B.ID_Afiliado = A.ID_Afiliado
WHERE (
((@SEMESTRE = 1) AND (@MES = 0) AND YEAR(B.Fecha_Compra) = @ANIO AND MONTH(B.Fecha_Compra) < 7 AND B.Fecha_Compra < GETDATE())
OR
((@SEMESTRE = 1) AND (@MES <> 0) AND YEAR(B.Fecha_Compra) = @ANIO AND MONTH(B.Fecha_Compra) = @MES AND B.Fecha_Compra < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES = 0) AND YEAR(B.Fecha_Compra) = @ANIO AND MONTH(B.Fecha_Compra) >= 7 AND B.Fecha_Compra < GETDATE())
OR
((@SEMESTRE = 2) AND (@MES <> 0) AND YEAR(B.Fecha_Compra) = @ANIO AND MONTH(B.Fecha_Compra) = @MES AND B.Fecha_Compra < GETDATE())
)
GROUP BY B.ID_Afiliado, A.Numero_Afiliado
ORDER BY 'Bonos Comprados' DESC;

END;
GO

-- Procedimientos con update, insert y delete

--Resgistra la atencion medica, el diagnostico

IF OBJECT_ID('[ANOTHER_CAT].[SP_Registrar_Atencion_Medica]') IS NOT NULL
	DROP PROCEDURE ANOTHER_CAT.SP_Registrar_Atencion_Medica
GO



CREATE PROCEDURE ANOTHER_CAT.SP_Registrar_Atencion_Medica
@ID_Consulta INT,
@SINTOMA VARCHAR(255),
@DIAGNOSTICO VARCHAR(255),
@HORA_ATENCION DATETIME

AS
BEGIN

UPDATE ANOTHER_CAT.tl_Consulta_Medica
SET Sintomas = @SINTOMA, Diagnostico = @DIAGNOSTICO, Registro_Atencion = @HORA_ATENCION
WHERE ID_Consulta = @ID_Consulta;

END;
GO

















