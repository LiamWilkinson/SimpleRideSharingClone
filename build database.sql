CREATE DATABASE UberClone;

USE UberClone;

CREATE TABLE Driver (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(255),
	Status VARCHAR(255),
	Latitude decimal(8,5),
	Longitude decimal(8,5)
);

INSERT INTO Driver(Name, Status, Latitude, Longitude) VALUES ('liam', 'picking up', 45.390830, -75.722735);
INSERT INTO Driver(Name, Status, Latitude, Longitude) VALUES ('Basavaraj', 'idling', 45.411497, -75.6880897);
INSERT INTO Driver(Name, Status, Latitude, Longitude) VALUES ('Brad', 'dropping off', 45.432742, -75.676172);
INSERT INTO Driver(Name, Status, Latitude, Longitude) VALUES ('Tyler', 'picking up', 45.367365, -75.703421);