using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

// Dependency Injection Example with AutoMapper
// Demonstrates constructor injection and registering dependencies
namespace Week5ApiDesign
{
    // Source and destination classes for mapping
    public class StudentDto
    {
        public string Name { get; set; }
    }
    public class Student
    {
        public string Name { get; set; }
    }

    // Service that uses AutoMapper via constructor injection
    public class StudentService
    {
        private readonly IMapper _mapper;
        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Student ConvertDtoToStudent(StudentDto dto)
        {
            return _mapper.Map<Student>(dto);
        }
    }

    public static class DependencyInjectionDemoWithMapper
    {
        public static void RunDemo()
        {
            // Setup DI container
            var services = new ServiceCollection();

            // Register AutoMapper and mapping profile
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<StudentDto, Student>();
            });

            // Register StudentService
            services.AddTransient<StudentService>();

            // Build service provider
            var provider = services.BuildServiceProvider();

            // Resolve StudentService from DI
            var service = provider.GetRequiredService<StudentService>();

            // Use the service
            var dto = new StudentDto { Name = "Alice" };
            var student = service.ConvertDtoToStudent(dto);
            Console.WriteLine($"Mapped Student Name: {student.Name}");
        }
    }
}
