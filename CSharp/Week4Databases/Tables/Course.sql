-- Course table
CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL
);
