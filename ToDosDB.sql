CREATE DATABASE ToDoLab;

USE ToDoLab;

CREATE TABLE employee(
	EmployeeID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(20),
    -- may not exceed 40 hours
    Hours INT,
    Title VARCHAR(40)
);

CREATE TABLE ToDos(
	ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    AssignedTo INT,
    `Name` VARCHAR(20),
    `Description` VARCHAR(100),
    HoursNeeded INT,
    IsComplete BIT,
     FOREIGN KEY (AssignedTo) REFERENCES employee(EmployeeID)
);