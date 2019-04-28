CREATE TABLE Lot (id int NOT NULL, name varchar(25) NOT NULL, totalCapacity int NOT NULL);

INSERT INTO Lot (id, name, totalCapacity) VALUES(1, 'Sitin', 15);

INSERT INTO Lot (id, name, totalCapacity) VALUES(2, 'Rest Stop', 25);

INSERT INTO Lot (id, name, totalCapacity) VALUES(3, 'Corners', 45);

UPDATE Lot SET totalCapacity = 40 WHERE name = 'Corners';

DELETE FROM Lot WHERE(name = 'Rest Stop');