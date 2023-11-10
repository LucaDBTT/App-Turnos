CREATE TABLE Usuarios(
idUsuario bigint not null  identity(1,1) primary key, 
dni bigint not null unique,
apellido varchar(50) not null,
nombre varchar(50) not null,
fechaNac  date not null ,
idCobertura bigint not null ,
nroAfiliado bigint not null,
telefono bigint not null,
mail varchar(50) not null unique ,
contraseña varchar(50) not null,
estado bit not null,
foreign key (idCobertura) references Coberturas(IdCoberturas)
)

GO

CREATE TABLE Sede ( 
idSede bigint not null  identity(1,1) primary key,
nombreSede varchar(50) not null,
estado bit not null,
)

GO

CREATE TABLE Especialidades(
idEspecialidad bigint not null   identity(1,1) primary key,
nombreEspecialidad varchar(50) not null,
estado bit not null,
)

GO

CREATE TABLE  Profesionales ( 
legajo bigint not null primary key identity(1,1),
nombre varchar(50) not null ,
apellido varchar(50) not null,
idEspecialidad bigint not null,
idSede bigint not null, 
Contraseña varchar(30) not null,
estado bit not null,
foreign key (idSede) references Sede(idSede),
foreign key (idEspecialidad) references especialidades(idEspecialidad)
)

GO
CREATE TABLE Consultas(
idConsultas  bigint not null  identity(1,1) primary key,
nombreConsultas varchar(50) not null
)
GO

CREATE TABLE Turnos( 
idturno bigint not null  identity(1,1) primary key ,
idUsuario bigint not null, 
Idprofesional bigint not null,
fechaTurno int not null,
idSede bigint not null,
idConsulta bigint not null,
Estado bit not null,
foreign key(idUsuario) references usuarios(idUsuario),
foreign key(Idprofesional) references profesionales(legajo),
foreign key(idSede) references Sede(idSede),
foreign key(idConsulta) references Consultas(idConsultas)
)