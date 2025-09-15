-- Insert sample students
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Alice', 'Smith', 'alice.smith@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Bob', 'Johnson', 'bob.johnson@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Carol', 'Williams', 'carol.williams@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('David', 'Brown', 'david.brown@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Eve', 'Jones', 'eve.jones@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Frank', 'Garcia', 'frank.garcia@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Grace', 'Martinez', 'grace.martinez@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Hank', 'Rodriguez', 'hank.rodriguez@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Ivy', 'Lee', 'ivy.lee@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Jack', 'Walker', 'jack.walker@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Kathy', 'Hall', 'kathy.hall@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Leo', 'Allen', 'leo.allen@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Mona', 'Young', 'mona.young@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Nina', 'Hernandez', 'nina.hernandez@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Oscar', 'King', 'oscar.king@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Paul', 'Wright', 'paul.wright@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Quinn', 'Lopez', 'quinn.lopez@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Rita', 'Hill', 'rita.hill@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Sam', 'Scott', 'sam.scott@email.com');
INSERT INTO Student (FirstName, LastName, Email) VALUES ('Tina', 'Green', 'tina.green@email.com');

-- Insert sample courses
INSERT INTO Course (CourseName, Credits) VALUES ('Mathematics', 3);
INSERT INTO Course (CourseName, Credits) VALUES ('History', 2);
INSERT INTO Course (CourseName, Credits) VALUES ('Physics', 4);
INSERT INTO Course (CourseName, Credits) VALUES ('Chemistry', 3);
INSERT INTO Course (CourseName, Credits) VALUES ('Literature', 2);

-- Insert sample classrooms
INSERT INTO Classroom (RoomNumber, Capacity) VALUES ('A101', 30);
INSERT INTO Classroom (RoomNumber, Capacity) VALUES ('B202', 25);
INSERT INTO Classroom (RoomNumber, Capacity) VALUES ('C303', 20);
INSERT INTO Classroom (RoomNumber, Capacity) VALUES ('D404', 35);
INSERT INTO Classroom (RoomNumber, Capacity) VALUES ('E505', 40);

-- Insert sample enrollments (some students enrolled in multiple courses)
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (1, 1, 1, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (1, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (2, 1, 1, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (2, 3, 3, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (3, 4, 4, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (3, 5, 5, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (4, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (5, 1, 1, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (6, 3, 3, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (7, 4, 4, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (8, 5, 5, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (9, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (10, 1, 1, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (11, 3, 3, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (12, 4, 4, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (13, 5, 5, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (14, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (15, 1, 1, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (16, 3, 3, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (17, 4, 4, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (18, 5, 5, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (19, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (20, 1, 1, '2024-09-01');
-- Additional enrollments for students in multiple courses
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (5, 2, 2, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (5, 3, 3, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (10, 4, 4, '2024-09-01');
INSERT INTO Enrollment (StudentId, CourseId, ClassroomId, EnrollmentDate) VALUES (10, 5, 5, '2024-09-01');
