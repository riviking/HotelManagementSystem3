-- 1. Create the Database
-- CREATE DATABASE hotelDB;

USE hotelDB;

-- 2. Create the Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(64) NOT NULL
);


-- 3. Create the Rooms Table (Columns inferred/suggested)
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY AUTO_INCREMENT,
    RoomNumber VARCHAR(10) NOT NULL,
    RoomType VARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Status BIT DEFAULT 1
);


-- 4. Create the Customers Table (Columns inferred/suggested)
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY AUTO_INCREMENT,
    FullName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    NIC VARCHAR(20)
);


-- Insert dummy customers
INSERT INTO Customers (FullName, Phone, NIC) VALUES 
('John Doe', '0775555555', '234234234238'),
('Jane Smith', '0774444444', '46546456469');

-- Insert a test user: Username='admin', Password='password'
INSERT INTO Users (Username, Password) 
VALUES ('admin', '234567890');

-- Insert dummy rooms data
INSERT INTO Rooms (`RoomNumber`, `RoomType`, `Price`, `IsAvailable`) VALUES 
('101', 'Single', 99.99, 1),
('102', 'Double', 149.99, 1),
('201', 'Suite', 299.99, 1);
