namespace StudentEnrollment.Repository.Sql
{
    public class SutudentSql
    {
        public const string GetAllStudents = @"
            SELECT StudentId, FirstName, LastName, DateOfBirth, Email
            FROM Students";
    }
}
