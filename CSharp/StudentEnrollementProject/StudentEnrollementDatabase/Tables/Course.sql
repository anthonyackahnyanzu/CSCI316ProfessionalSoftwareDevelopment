CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    Credits INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);
