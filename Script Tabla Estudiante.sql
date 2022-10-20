USE HorasConferenciaDB
GO

CREATE TABLE Estudiante(
Id int identity (1,1),
Nombre varchar(150),
Carne varchar(8),
Correo varchar(200),
Enfasis varchar(100),
MinutosRegistrados int,
ActividadesRegistradas int

CONSTRAINT PK_Estudiante PRIMARY KEY CLUSTERED
(
	Id ASC
)
)

GO