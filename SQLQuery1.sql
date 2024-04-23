CREATE DATABASE Academy
USE Academy

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(255),
Age INT CHECK(Age>0),
Surname NVARCHAR(250)
)
INSERT INTO Students ([Name], Age, Surname) VALUES
('Tehmasib', 20, 'Tagiyev'),
('Emil', 23, 'Abbasov')

SELECT AVG(Age) FROM Students

CREATE TABLE Details
(
Id INT PRIMARY KEY IDENTITY,
StudentId int FOREIGN KEY REFERENCES Students(Id),
[Address] NVARCHAR(255)
)


SELECT s.Name, d.Address FROM Students s 
JOIN Details d ON s.Id=d.StudentId


CREATE VIEW StuInfo
AS
SELECT s.Name, d.Address FROM Students s 
JOIN Details d ON s.Id=d.StudentId

SELECT * FROM StuInfo








