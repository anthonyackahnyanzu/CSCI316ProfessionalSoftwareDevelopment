using System;

namespace StudentEnrollentReposiotry.Entities
{
    public class StudentEntity
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }

    public class CourseEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public int Credits { get; set; }
    }

    public class DepartmentEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ClassroomEntity
    {
        public int ClassroomId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
    }

    public class ProfessorEntity
    {
        public int ProfessorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }

    public class SemesterEntity
    {
        public int SemesterId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ClassOfferingEntity
    {
        public int ClassOfferingId { get; set; }
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }
        public int ClassroomId { get; set; }
        public int SemesterId { get; set; }
        public string Schedule { get; set; }
    }

    public class EnrollmentEntity
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassOfferingId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
