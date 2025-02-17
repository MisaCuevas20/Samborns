CREATE DATABASE Empresa
GO
USE Empresa
GO
CREATE TABLE Area(
	id INT PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL);
GO
CREATE TABLE Empleados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(30) NOT NULL,
	edad INT NOT NULL,
	idArea INT NOT NULL,
	fechaIngreso DATE NOT NULL,
	FOREIGN KEY (idArea) REFERENCES Area(id) 
	ON DELETE CASCADE
	ON UPDATE CASCADE
	);
GO
INSERT INTO Area (nombre) 
	VALUES ('Recursos Humanos'),
		   ('Finanzas'),
		   ('Desarrollador .NET'),
		   ('Marketing'),
		   ('Ventas');
GO
INSERT INTO Empleados (nombre, edad, idArea, fechaIngreso) 
	VALUES ('Misael Cuevas', 23, 3, '2025-02-15'),
		   ('Manuel Vazquez', 25, 1, '2019-07-22'),
		   ('Manuela López', 35, 2, '2018-01-10'),
		   ('Marisol Obrador', 28, 4, '2021-03-01'),
		   ('Ana Ruiz', 40, 5, '2023-11-05');
GO
SELECT
	e.nombre AS 'Nombre',
	a.nombre AS 'Área',
	e.edad AS 'Edad',
	e.fechaIngreso AS 'Fecha de Ingreso'
FROM Empleados e
INNER JOIN Area a ON a.id = e.idArea

