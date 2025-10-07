namespace StudentEnrollment.Repository.Entities
{
    public class EnrollmentEntity
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassOfferingId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}