namespace StudentEnrollment.Service.Models
{
    public class EnrollmentModel
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassOfferingId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}