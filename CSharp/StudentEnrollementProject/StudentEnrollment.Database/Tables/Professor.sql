CREATE TABLE Professor (
    ProfessorId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);
