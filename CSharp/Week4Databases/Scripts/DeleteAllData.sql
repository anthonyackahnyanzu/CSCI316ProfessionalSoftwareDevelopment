-- Delete all data from tables (in correct order to avoid FK conflicts)
DELETE FROM Enrollment;
DELETE FROM Classroom;
DELETE FROM Course;
DELETE FROM Student;
