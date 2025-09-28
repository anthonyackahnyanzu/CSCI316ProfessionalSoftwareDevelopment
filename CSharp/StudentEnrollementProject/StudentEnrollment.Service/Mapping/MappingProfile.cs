using AutoMapper;
using StudentEnrollment.Repository.Entities;
using StudentEnrollment.Service.Models;

namespace StudentEnrollment.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentEntity, StudentModel>().ReverseMap();
            CreateMap<EnrollmentEntity, EnrollmentModel>().ReverseMap();
            CreateMap<CourseEntity, CourseModel>().ReverseMap();
            CreateMap<DepartmentEntity, DepartmentModel>().ReverseMap();
            CreateMap<ClassOfferingEntity, ClassOfferingModel>().ReverseMap();
            CreateMap<SemesterEntity, SemesterModel>().ReverseMap();
        }
    }
}