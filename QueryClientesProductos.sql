
--EJERCICIO 1----------------------------------------------------------------------------------------------------------

CREATE DATABASE Samborns
GO
USE Samborns
GO
CREATE TABLE Producto (
    key_producto INT PRIMARY KEY);
GO
CREATE TABLE Clientes (
    id_cliente INT NOT NULL,
    key_producto INT NOT NULL,
    FOREIGN KEY (key_producto) REFERENCES Producto(key_producto));
GO
INSERT INTO Producto VALUES (5), (6);
GO
INSERT INTO Clientes VALUES (1, 5), (2, 6), (3, 5), (3, 6), (1, 6);
GO
SELECT c.id_cliente
FROM Clientes c
GROUP BY c.id_cliente
HAVING COUNT(DISTINCT c.key_producto) = (SELECT COUNT(*) FROM Producto);


--EJERCICIO 2----------------------------------------------------------------------------------------------------------

CREATE TABLE Empleados(
	id INT IDENTITY(1,1) NOT NULL,
	salario INT NOT NULL);
GO
INSERT INTO Empleados (salario) VALUES (100),(800),(600),(700),(50),(1000),(9000);
GO
SELECT MAX(salario) AS 'Segundo Salario Mas Alto'
FROM Empleados
WHERE salario < (SELECT MAX(salario) FROM Empleados);

--EJERCICIO 3----------------------------------------------------------------------------------------------------------

CREATE TABLE Aseguradora(
	pid INT IDENTITY(1,1),
	Inv_2015 FLOAT,
	Inv_2016 FLOAT,
	lat FLOAT NOT NULL,
	lon FLOAT NOT NULL);
GO
INSERT INTO Aseguradora (Inv_2015, Inv_2016, lat, lon) 
	VALUES (10, 5, 10, 10), (20, 20, 20, 20), (10, 30, 20, 20), (10, 40, 40 ,40);
GO
SELECT SUM(inv_2016) AS inv_2016
FROM Aseguradora A1
WHERE inv_2015 IN (
    SELECT inv_2015
    FROM Aseguradora
    GROUP BY inv_2015
    HAVING COUNT(*) > 1)
AND lat IN(
	SELECT lat
	FROM Aseguradora
	GROUP BY lat
	HAVING COUNT(*) = 1)
AND lon IN(
	SELECT lon
	FROM Aseguradora
	GROUP BY lon
	HAVING COUNT(*) = 1)


--EJERCICIO 4----------------------------------------------------------------------------------------------------------

CREATE TABLE Fila(
	id_persona INT NOT NULL,
	nombre_persona VARCHAR(50) NOT NULL,
	peso INT NOT NULL,
	turno INT NOT NULL);
GO
INSERT INTO Fila VALUES (5, 'Jose', 250, 1),
						(4, 'Carlos', 175, 5),
						(3, 'Ana', 350, 2),
						(6, 'Karla', 400, 3),
						(1, 'Lucas', 500, 6),
						(2, 'Miguel', 200, 4);
GO
WITH PersonasOrdenadas AS (
    SELECT id_persona, nombre_persona, peso, turno,
           SUM(peso) OVER (ORDER BY turno) AS peso_acumulado
    FROM Fila
)
SELECT TOP 1 nombre_persona
FROM PersonasOrdenadas
WHERE peso_acumulado <= 1000
ORDER BY turno DESC;

--EJERCICIO 5----------------------------------------------------------------------------------------------------------

CREATE TABLE Actividades (
    id_jugador INT,
    id_dispositivo INT,
    fecha_evento DATE,
    partidas_jugadas INT,
    PRIMARY KEY (id_jugador, fecha_evento)
);
GO
INSERT INTO Actividades (id_jugador, id_dispositivo, fecha_evento, partidas_jugadas)
VALUES  (1, 2, '2016-03-01', 5),
		(1, 2, '2016-03-02', 1),
		(2, 3, '2017-06-25', 6),
		(3, 1, '2016-03-02', 0),
		(3, 4, '2018-07-07', 5);

GO
WITH PrimerInicio AS (
    SELECT id_jugador, MIN(fecha_evento) AS primera_fecha
    FROM Actividades
    GROUP BY id_jugador
)
SELECT 
    ROUND(CAST(COUNT(DISTINCT a.id_jugador) AS FLOAT) / 
    CAST((SELECT COUNT(DISTINCT id_jugador) FROM Actividades) AS FLOAT), 2) AS Fracción
FROM PrimerInicio p
INNER JOIN Actividades a 
    ON p.id_jugador = a.id_jugador 
    AND DATEADD(DAY, 1, p.primera_fecha) = a.fecha_evento;




