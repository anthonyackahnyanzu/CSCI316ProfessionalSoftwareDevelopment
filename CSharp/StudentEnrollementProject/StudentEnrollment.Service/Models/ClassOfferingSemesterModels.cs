using System;

namespace StudentEnrollment.Service.Models
{
    public class ClassOfferingModel
    {
        public int ClassOfferingId { get; set; }
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }
        public int ClassroomId { get; set; }
        public int SemesterId { get; set; }
        public string Schedule { get; set; }
    }

    public class SemesterModel
    {
        public int SemesterId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}