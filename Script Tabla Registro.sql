USE HorasConferenciaDB
GO

CREATE TABLE Registro(
Id int identity (1,1),
TipoHoraConferencia varchar(30),
Id_Estudiante int FOREIGN KEY REFERENCES Estudiante(Id),
Id_Actividad int FOREIGN KEY REFERENCES Actividad(Id),
Id_Pelicula int FOREIGN KEY REFERENCES Pelicula(Id),
FechaRegistro datetime,
Archivo varchar(200),
Minutos int,
TemaCentral varchar(50),
Descripcion varchar(150),
Estado varchar(12),
Retroalimentacion varchar(150)

CONSTRAINT PK_Registro PRIMARY KEY CLUSTERED
(
	Id ASC
)
)

GO