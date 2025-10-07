CREATE TABLE Student (
    StudentId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);
