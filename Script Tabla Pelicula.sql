USE HorasConferenciaDB
GO

CREATE TABLE Pelicula(
Id int identity (1,1),
Pais varchar(30),
SegundoPais varchar(30),
Titulo varchar(100),
Director varchar(100),
AnioEstreno int,
Genero varchar(20),
DuracionMinutos int,
Descripcion varchar(300)

CONSTRAINT PK_Pelicula PRIMARY KEY CLUSTERED
(
	Id ASC
)
)

GO