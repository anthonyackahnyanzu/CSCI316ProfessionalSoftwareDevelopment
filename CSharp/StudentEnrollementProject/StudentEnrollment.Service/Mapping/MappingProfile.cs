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
        }
    }
}