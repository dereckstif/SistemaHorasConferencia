USE HorasConferenciaDB
GO

CREATE TABLE Actividad(
Id int identity (1,1),
Nombre varchar(150),
Fecha datetime,
HoraInicio datetime,
HoraFinal datetime,
Organizador varchar(150),
Expositor varchar(150),
Lugar varchar(150),
Descripcion varchar(500),
DuracionMinutos int,
AgregadoPorEstudiante int FOREIGN KEY REFERENCES Estudiante(Id),

CONSTRAINT PK_Actividad PRIMARY KEY CLUSTERED
(
	Id ASC
)
)

GO