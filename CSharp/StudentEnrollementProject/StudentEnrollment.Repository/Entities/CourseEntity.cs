namespace StudentEnrollment.Repository.Entities
{
    public class CourseEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public int Credits { get; set; }
    }
}