CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    ClassOfferingId INT NOT NULL,
    EnrollmentDate DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (ClassOfferingId) REFERENCES ClassOffering(ClassOfferingId)
);
