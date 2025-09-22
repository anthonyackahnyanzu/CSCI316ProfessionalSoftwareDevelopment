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
