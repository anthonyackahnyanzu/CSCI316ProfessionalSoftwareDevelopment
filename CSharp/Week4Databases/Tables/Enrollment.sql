-- Enrollment table with foreign key relations
CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    ClassroomId INT NULL,
    EnrollmentDate DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
    FOREIGN KEY (ClassroomId) REFERENCES Classroom(ClassroomId)
);
