using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Repository.Sql
{
    public class SutudentSql
    {
        public const string GetAllStudents = @"
            SELECT StudentId, FirstName, LastName, DateOfBirth, Email
            FROM Students";
    }
}
