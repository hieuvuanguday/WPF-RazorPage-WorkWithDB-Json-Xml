CREATE DATABASE StudentManagement;
GO

USE StudentManagement;
GO

CREATE TABLE Account (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role int NOT NULL
);
GO

CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Gender NVARCHAR(10),
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Address NVARCHAR(255),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Active'
);
GO

CREATE TABLE Course (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(255) NOT NULL,
    Credits INT NOT NULL CHECK (Credits > 0),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
);
GO

CREATE TABLE Enrollment (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Course(CourseID),
    EnrollmentDate DATETIME NOT NULL DEFAULT GETDATE(),
    Grade NVARCHAR(5),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Enrolled'
);
GO

INSERT INTO Account (Email, Password, Role) VALUES
('admin@fpt.com', '123456', 1),
('manager@fpt.com', '123456', 2),
('staff@fpt.com', '123456', 3);
GO

INSERT INTO Student (FullName, DateOfBirth, Gender, PhoneNumber, Email, Address, Status) VALUES
('Nguyen Van An', '2000-05-10', 'Male', '0901234567', 'nguyenvana@example.com', 'Hanoi', 'Active'),
('Tran Thi Binh', '1999-07-15', 'Female', '0902345678', 'tranthib@example.com', 'Ho Chi Minh City', 'Active'),
('Le Van Chuen', '2001-08-20', 'Male', '0903456789', 'levanc@example.com', 'Da Nang', 'Active'),
('Pham Thi Du g', '2002-09-25', 'Female', '0904567890', 'phamthid@example.com', 'Hue', 'Active'),
('Hoang Van En', '2000-10-30', 'Male', '0905678901', 'hoangvane@example.com', 'Hai Phong', 'Active'),
('Vu Thi Fuong', '2001-11-05', 'Female', '0906789012', 'vuthif@example.com', 'Can Tho', 'Active'),
('Dang Van Giang', '1999-12-12', 'Male', '0907890123', 'dangvang@example.com', 'Quang Ninh', 'Active'),
('Nguyen Thi Hong', '2001-01-18', 'Female', '0908901234', 'nguyenthih@example.com', 'Bac Ninh', 'Active'),
('Bui Van In', '2002-02-22', 'Male', '0909012345', 'buivani@example.com', 'Hai Duong', 'Active'),
('Do Thi Jack', '2000-03-30', 'Female', '0910123456', 'dothij@example.com', 'Thanh Hoa', 'Active');
GO

INSERT INTO Course (CourseName, Credits, StartDate, EndDate) VALUES
('MAD101', 3, '2024-01-15', '2024-05-30'),
('OSG202', 4, '2024-02-01', '2024-06-15'),
('PRO192', 3, '2024-03-01', '2024-07-01'),
('MAS291', 2, '2024-04-01', '2024-08-01'),
('PRJ301', 3, '2024-05-01', '2024-09-01');
GO

INSERT INTO Enrollment (StudentID, CourseID, EnrollmentDate, Grade, Status) VALUES
(1, 1, '2024-01-20', 'A', 'Completed'),
(1, 2, '2024-02-10', 'B+', 'Completed'),
(2, 1, '2024-01-25', 'A-', 'Enrolled'),
(2, 3, '2024-03-05', NULL, 'Enrolled'),
(3, 2, '2024-02-15', 'B', 'Completed'),
(3, 4, '2024-04-10', NULL, 'Enrolled'),
(4, 1, '2024-01-28', 'C+', 'Completed'),
(4, 5, '2024-05-10', NULL, 'Enrolled'),
(5, 3, '2024-03-10', 'B+', 'Completed'),
(5, 2, '2024-02-20', 'A', 'Completed'),
(6, 1, '2024-01-30', 'A-', 'Completed'),
(6, 4, '2024-04-15', NULL, 'Enrolled'),
(7, 2, '2024-02-25', 'C', 'Completed'),
(8, 3, '2024-03-15', NULL, 'Enrolled'),
(9, 5, '2024-05-20', NULL, 'Enrolled');
GO

