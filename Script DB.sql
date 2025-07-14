CREATE DATABASE PruebaTecnica;
GO

USE PruebaTecnica;
GO

/* ------------------------------------------------------------------------------*/
CREATE TABLE Empleados (
    Codigo INT PRIMARY KEY IDENTITY(1,1),
    Puesto NVARCHAR(100) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    CodigoJefe INT NULL,
    FOREIGN KEY (CodigoJefe) REFERENCES Empleados(Codigo)
);

GO

/* ------------------------------------------------------------------------------*/
CREATE PROCEDURE InsertarEmpleado
    @Puesto NVARCHAR(100),
    @Nombre NVARCHAR(100),
    @CodigoJefe INT = NULL
AS
BEGIN
    INSERT INTO Empleados (Puesto, Nombre, CodigoJefe)
    VALUES (@Puesto, @Nombre, @CodigoJefe)
END;

GO

/* ------------------------------------------------------------------------------*/
CREATE PROCEDURE ObtenerEmpleados
AS
BEGIN
    SELECT * FROM Empleados
END

GO

/* ------------------------------------------------------------------------------*/
CREATE PROCEDURE ObtenerEmpleadoPorId
    @Codigo INT
AS
BEGIN
    SELECT * FROM Empleados WHERE Codigo = @Codigo
END

GO

/* ------------------------------------------------------------------------------*/
CREATE PROCEDURE ActualizarEmpleado
    @Codigo INT,
    @Puesto NVARCHAR(100),
    @Nombre NVARCHAR(100),
    @CodigoJefe INT = NULL
AS
BEGIN
    UPDATE Empleados
    SET Puesto = @Puesto,
        Nombre = @Nombre,
        CodigoJefe = @CodigoJefe
    WHERE Codigo = @Codigo
END

GO

/* ------------------------------------------------------------------------------*/
CREATE PROCEDURE EliminarEmpleado
    @Codigo INT
AS
BEGIN
    DELETE FROM Empleados WHERE Codigo = @Codigo
END

GO
------------------------------------------------------------------*/