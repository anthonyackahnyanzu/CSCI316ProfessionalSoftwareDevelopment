using Microsoft.Extensions.Options;
using StudentEnrollment.Repository.Implementations;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Service.Services;
using StudentEnrollment.Service.Mapping;
using StudentEnrollment.Api.Settings;
using AutoMapper;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Bind DatabaseSettings from appsettings.json
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));

// Register AutoMapper
// Replace this line:
// builder.Services.AddAutoMapper(typeof(MappingProfile));

// With this line:
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// Register Dapper IDbConnection using IOptions
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var dbSettings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    return new SqlConnection(dbSettings.DefaultConnection);
});

// Register repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ICourseDepartmentRepository, CourseDepartmentRepository>();
builder.Services.AddTransient<IEnrollmentOfferingSemesterRepository, EnrollmentOfferingSemesterRepository>();
builder.Services.AddScoped<StudentService>();

// Register services
builder.Services.AddScoped<ICourseDepartmentService, CourseDepartmentService>();
builder.Services.AddTransient<IEnrollmentOfferingSemesterService, EnrollmentOfferingSemesterService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
