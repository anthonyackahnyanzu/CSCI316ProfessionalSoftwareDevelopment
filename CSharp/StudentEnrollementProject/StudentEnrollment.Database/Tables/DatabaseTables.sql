-- Student table
CREATE TABLE Student (
    StudentId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

-- Course table
CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    Credits INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

-- Department table
CREATE TABLE Department (
    DepartmentId INT PRIMARY KEY IDENTITY,
    DepartmentName NVARCHAR(100) NOT NULL
);

-- Classroom table
CREATE TABLE Classroom (
    ClassroomId INT PRIMARY KEY IDENTITY,
    RoomNumber NVARCHAR(20) NOT NULL,
    Capacity INT NOT NULL
);

-- Professor table
CREATE TABLE Professor (
    ProfessorId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

-- Semester table
CREATE TABLE Semester (
    SemesterId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

-- ClassOffering table
CREATE TABLE ClassOffering (
    ClassOfferingId INT PRIMARY KEY IDENTITY,
    CourseId INT NOT NULL,
    ProfessorId INT NOT NULL,
    ClassroomId INT NOT NULL,
    SemesterId INT NOT NULL,
    Schedule NVARCHAR(100) NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
    FOREIGN KEY (ProfessorId) REFERENCES Professor(ProfessorId),
    FOREIGN KEY (ClassroomId) REFERENCES Classroom(ClassroomId),
    FOREIGN KEY (SemesterId) REFERENCES Semester(SemesterId)
);

-- Enrollment table
CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    ClassOfferingId INT NOT NULL,
    EnrollmentDate DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (ClassOfferingId) REFERENCES ClassOffering(ClassOfferingId)
);
