/*
CREATE DATABASE hospital_db;
GO
USE hospital_db;
GO

CREATE TABLE [Hospitales] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(150) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
);

CREATE TABLE [Pacientes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [FechaNacimiento] SMALLDATETIME NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Direccion] NVARCHAR(150) NOT NULL,
);

CREATE TABLE [Sectores] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(50) NOT NULL,
    [Piso] INT NOT NULL,
    [Descripcion] NVARCHAR(200) NOT NULL,
    [Hospital] INT NOT NULL REFERENCES [Hospitales]([Id]),
);

CREATE TABLE [Medicos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Especialidad] NVARCHAR(50) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Sector] INT NOT NULL REFERENCES [Sectores]([Id]),
);

CREATE TABLE [Turnos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Jornada] NVARCHAR(20) NOT NULL,
    [HoraInicio] SMALLDATETIME NOT NULL,
    [HoraFinal] SMALLDATETIME NOT NULL,
    [Medico] INT NOT NULL REFERENCES [Medicos]([Id]),
);

CREATE TABLE [Consultorios] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Estado] NVARCHAR(20) NOT NULL,
    [Equipamiento] NVARCHAR(200) NOT NULL,
    [Sector] INT NOT NULL REFERENCES [Sectores]([Id]),
    [Medico] INT NOT NULL REFERENCES [Medicos]([Id]),
);

CREATE TABLE [Habitaciones] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Tipo] NVARCHAR(50) NOT NULL,
    [Disponibilidad] BIT NOT NULL,
    [Sector] INT NOT NULL REFERENCES [Sectores]([Id]),
    [Paciente] INT NOT NULL REFERENCES [Pacientes]([Id]),
);

CREATE TABLE [Historiales] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [FechaApertura] SMALLDATETIME NOT NULL,
    [Antecedente] NVARCHAR(500) NOT NULL,
    [Paciente] INT NOT NULL REFERENCES [Pacientes]([Id]),
);

CREATE TABLE [Solicitudes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Fecha] SMALLDATETIME NOT NULL,
    [NivelUrgencia] NVARCHAR(20) NOT NULL,
    [Motivo] NVARCHAR(200) NOT NULL,
    [Paciente] INT NOT NULL REFERENCES [Pacientes]([Id]),
);

CREATE TABLE [Seguros] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [FechaVencimiento] SMALLDATETIME NOT NULL,
    [Cobertura] NVARCHAR(100) NOT NULL,
    [Solicitud] INT NOT NULL REFERENCES [Solicitudes]([Id]),
);

CREATE TABLE [Citas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Fecha] SMALLDATETIME NOT NULL,
    [Estado] NVARCHAR(20) NOT NULL,
    [Solicitud] INT NOT NULL REFERENCES [Solicitudes]([Id]),
    [Paciente] INT NOT NULL REFERENCES [Pacientes]([Id]),
);

CREATE TABLE [Consultas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Observacion] NVARCHAR(500) NOT NULL,
    [SignosVitales] NVARCHAR(200) NOT NULL,
    [CostoConsulta] DECIMAL(10, 2) NOT NULL,
    [Cita] INT NOT NULL REFERENCES [Citas]([Id]),
);

CREATE TABLE [Enfermedades] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Categoria] NVARCHAR(50) NOT NULL,
    [NivelContagio] NVARCHAR(20) NOT NULL,
    [Consulta] INT NOT NULL REFERENCES [Consultas]([Id]),
);

CREATE TABLE [Formulas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Fecha] SMALLDATETIME NOT NULL,
    [Indicacion] NVARCHAR(500) NOT NULL,
    [Vigencia] NVARCHAR(50) NOT NULL,
    [Consulta] INT NOT NULL REFERENCES [Consultas]([Id]),
);

CREATE TABLE [Examenes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Tipo] NVARCHAR(50) NOT NULL,
    [Resultado] NVARCHAR(500) NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    [Formula] INT NOT NULL REFERENCES [Formulas]([Id]),
);

CREATE TABLE [Procedimientos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Proceso] NVARCHAR(200) NOT NULL,
    [Duracion] NVARCHAR(50) NOT NULL,
    [Costo] DECIMAL(10, 2) NOT NULL,
    [Examen] INT NOT NULL REFERENCES [Examenes]([Id]),
);

CREATE TABLE [Medicamentos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [NombreComercial] NVARCHAR(100) NOT NULL,
    [Dosis] NVARCHAR(50) NOT NULL,
    [Disponibilidad] INT NOT NULL,
);

CREATE TABLE [Administrativos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Cargo] NVARCHAR(50) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Hospital] INT NOT NULL REFERENCES [Hospitales]([Id]),
);

CREATE TABLE [Facturas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [FechaEmision] SMALLDATETIME NOT NULL,
    [Subtotal] DECIMAL(10, 2) NOT NULL,
    [Impuesto] DECIMAL(10, 2) NOT NULL,
    [Medicamento] INT NOT NULL REFERENCES [Medicamentos]([Id]),
    [Procedimiento] INT NOT NULL REFERENCES [Procedimientos]([Id]),
    [Administrativo] INT NOT NULL REFERENCES [Administrativos]([Id]),
);

CREATE TABLE [Pagos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Metodo] NVARCHAR(30) NOT NULL,
    [Monto] DECIMAL(10, 2) NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    [Factura] INT NOT NULL REFERENCES [Facturas]([Id]),
);

-- Datos de prueba: una fila por tabla (las pruebas unitarias las necesitan)
INSERT INTO [Hospitales] ([Nombre], [Direccion], [Telefono], [Correo]) VALUES ('Hospital General', 'Calle 10 # 20-30', '6044441234', 'contacto@hospital.com');
INSERT INTO [Pacientes] ([Nombre], [FechaNacimiento], [Telefono], [Direccion]) VALUES ('Maria Gomez', '19950314', '3001234567', 'Carrera 45 # 12-80');
INSERT INTO [Sectores] ([Nombre], [Piso], [Descripcion], [Hospital]) VALUES ('Urgencias', 1, 'Atencion inmediata', 1);
INSERT INTO [Medicos] ([Nombre], [Especialidad], [Telefono], [Sector]) VALUES ('Carlos Ruiz', 'Medicina general', '3015556677', 1);
INSERT INTO [Turnos] ([Jornada], [HoraInicio], [HoraFinal], [Medico]) VALUES ('Manana', '20260901 06:00', '20260901 14:00', 1);
INSERT INTO [Consultorios] ([Estado], [Equipamiento], [Sector], [Medico]) VALUES ('Libre', 'Camilla, tensiometro', 1, 1);
INSERT INTO [Habitaciones] ([Tipo], [Disponibilidad], [Sector], [Paciente]) VALUES ('Individual', 1, 1, 1);
INSERT INTO [Historiales] ([FechaApertura], [Antecedente], [Paciente]) VALUES ('20260115', 'Ninguno', 1);
INSERT INTO [Solicitudes] ([Fecha], [NivelUrgencia], [Motivo], [Paciente]) VALUES ('20260901', 'Media', 'Dolor de cabeza', 1);
INSERT INTO [Seguros] ([Nombre], [FechaVencimiento], [Cobertura], [Solicitud]) VALUES ('Sura', '20271231', 'Total', 1);
INSERT INTO [Citas] ([Fecha], [Estado], [Solicitud], [Paciente]) VALUES ('20260902 08:00', 'Pendiente', 1, 1);
INSERT INTO [Consultas] ([Observacion], [SignosVitales], [CostoConsulta], [Cita]) VALUES ('Paciente estable', 'Presion 120/80', 45000.00, 1);
INSERT INTO [Enfermedades] ([Nombre], [Categoria], [NivelContagio], [Consulta]) VALUES ('Gripa', 'Respiratoria', 'Alto', 1);
INSERT INTO [Formulas] ([Fecha], [Indicacion], [Vigencia], [Consulta]) VALUES ('20260902', 'Acetaminofen cada 8 horas', '30 dias', 1);
INSERT INTO [Examenes] ([Tipo], [Resultado], [Fecha], [Formula]) VALUES ('Sangre', 'Normal', '20260903', 1);
INSERT INTO [Procedimientos] ([Proceso], [Duracion], [Costo], [Examen]) VALUES ('Radiografia', '30 minutos', 120000.00, 1);
INSERT INTO [Medicamentos] ([NombreComercial], [Dosis], [Disponibilidad]) VALUES ('Dolex', '500 mg', 100);
INSERT INTO [Administrativos] ([Nombre], [Cargo], [Telefono], [Hospital]) VALUES ('Ana Torres', 'Facturacion', '3027778899', 1);
INSERT INTO [Facturas] ([FechaEmision], [Subtotal], [Impuesto], [Medicamento], [Procedimiento], [Administrativo]) VALUES ('20260903', 100000.00, 19000.00, 1, 1, 1);
INSERT INTO [Pagos] ([Metodo], [Monto], [Fecha], [Factura]) VALUES ('Efectivo', 119000.00, '20260903', 1);

-- ===== Actualizacion final (como Horarios) =====
-- Columna para la foto del medico (se guarda en base64)
ALTER TABLE [Medicos] ADD [Imagen] NVARCHAR(MAX) NULL;

-- ===== Seguridad: Roles, Usuarios y Permisos =====
CREATE TABLE [Roles] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(50) NOT NULL,
    [Descripcion] NVARCHAR(200) NOT NULL,
);

CREATE TABLE [Usuarios] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL UNIQUE,
    [Contrasena] NVARCHAR(64) NOT NULL,
    [Activo] BIT NOT NULL,
    [Rol] INT NOT NULL REFERENCES [Roles]([Id]),
);

CREATE TABLE [Permisos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Ventana] NVARCHAR(50) NOT NULL,
    [Rol] INT NOT NULL REFERENCES [Roles]([Id]),
);

-- ===== Auditorias: guarda quien cambio que (una fila por cada Insertar, Actualizar o Borrar) =====
CREATE TABLE [Auditorias] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Entidad] NVARCHAR(50) NOT NULL,
    [Operacion] NVARCHAR(20) NOT NULL,
    [Registro] INT NOT NULL,
    [Fecha] DATETIME NOT NULL,
);

-- La contrasena se guarda cifrada con SHA256. Este valor es "123" cifrado.
INSERT INTO [Roles] ([Nombre], [Descripcion]) VALUES ('Administrador', 'Puede usar todas las ventanas');
INSERT INTO [Roles] ([Nombre], [Descripcion]) VALUES ('Recepcion', 'Solo pacientes, solicitudes, citas e historiales');
INSERT INTO [Usuarios] ([Nombre], [Correo], [Contrasena], [Activo], [Rol]) VALUES ('Administrador', 'admin', 'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 1, 1);
INSERT INTO [Usuarios] ([Nombre], [Correo], [Contrasena], [Activo], [Rol]) VALUES ('Recepcionista', 'recepcion', 'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 1, 2);
INSERT INTO [Permisos] ([Ventana], [Rol]) VALUES ('Pacientes', 2);
INSERT INTO [Permisos] ([Ventana], [Rol]) VALUES ('Solicitudes', 2);
INSERT INTO [Permisos] ([Ventana], [Rol]) VALUES ('Citas', 2);
INSERT INTO [Permisos] ([Ventana], [Rol]) VALUES ('Historiales', 2);
INSERT INTO [Auditorias] ([Entidad], [Operacion], [Registro], [Fecha]) VALUES ('Script', 'Insertar', 0, GETDATE());
*/
