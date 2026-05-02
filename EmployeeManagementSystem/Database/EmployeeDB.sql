-- =============================================
-- Employee Management System - Database Script
-- =============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'EmployeeManagementDB')
    DROP DATABASE EmployeeManagementDB;
GO

CREATE DATABASE EmployeeManagementDB;
GO

USE EmployeeManagementDB;
GO

-- Departments Table
CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

-- Designations Table
CREATE TABLE Designations (
    DesignationId INT PRIMARY KEY IDENTITY(1,1),
    DesignationName NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);
GO

-- Employees Table
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    DepartmentId INT NOT NULL,
    DesignationId INT NOT NULL,
    Address NVARCHAR(250) NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (DesignationId) REFERENCES Designations(DesignationId)
);
GO

-- Seed Departments
INSERT INTO Departments (DepartmentName) VALUES ('IT'), ('HR'), ('Sales');
GO

-- Seed Designations
INSERT INTO Designations (DesignationName, DepartmentId) VALUES
('Developer', 1), ('Tester', 1), ('DevOps', 1),
('Recruiter', 2), ('HR Manager', 2),
('Sales Executive', 3), ('Sales Manager', 3);
GO

SELECT * FROM Departments;
SELECT * FROM Designations;
