-- 1. Create the Database
-- CREATE DATABASE hotelDB;

USE hotelDB;

-- 2. Create the Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(64) NOT NULL
);


-- 3. Create the Rooms Table (Columns inferred/suggested)
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomType VARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    IsAvailable VARCHAR(20) DEFAULT 'Available'
);


-- 4. Create the Customers Table (Columns inferred/suggested)
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    NIC VARCHAR(20)
);

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    RoomID INT NOT NULL,
    DateIn DATETIME NOT NULL,
    DateOut DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    PaymentStatus VARCHAR(20) NOT NULL DEFAULT 'Unpaid', -- 'Unpaid' or 'Paid'
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

-- 6. Payments Table (Used in frmPayment and Income Charts)
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    PaidDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);

-- Insert dummy customers
INSERT INTO Customers (Name, Phone, NIC) VALUES 
('John Doe', '0775555555', '234234234238'),
('Mark Doe', '0775553333', '344234234238'),
('Jane Smith', '0774444444', '46546456469');

-- Insert a test user: Username='admin', Password='password'
INSERT INTO Users (Username, Password) VALUES 
('qwe', '234'),
('admin', '234');

-- Insert dummy rooms data
INSERT INTO Rooms (RoomType, Price) VALUES 
( 'Single', 100.00),
( 'Double', 150.00),
( 'Deluxe', 200.00),
( 'Suite', 300.00);
