using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StudentEnrollment.Repository.Implementations;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Service.Implementations;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Mapping;
using StudentEnrollment.Api.Settings;
using Microsoft.Data.SqlClient;
using StudentEnrollment.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind DatabaseSettings from appsettings.json
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));

// Bind JwtSettings from appsettings.json
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

// Register AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

// Register Dapper IDbConnection using IOptions
builder.Services.AddScoped<System.Data.IDbConnection>(sp =>
{
    var dbSettings = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<DatabaseSettings>>().Value;
    return new SqlConnection(dbSettings.DefaultConnection);
});

// Register repositories and services
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseDepartmentRepository, CourseDepartmentRepository>();
builder.Services.AddScoped<IEnrollmentOfferingSemesterRepository, EnrollmentOfferingSemesterRepository>();
builder.Services.AddScoped<IEnrollmentOfferingSemesterService, EnrollmentOfferingSemesterService>();
builder.Services.AddScoped<ICourseDepartmentService, CourseDepartmentService>();
builder.Services.AddScoped<StudentService>();
// Register AuthService and UserRepository for authentication
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// JWT Authentication setup
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSection["Key"];
var issuer = jwtSection["Issuer"];
var audience = jwtSection["Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// Claims-based authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanRegister", policy => policy.RequireClaim("permission", "CanRegister"));
    options.AddPolicy("CanViewSchedule", policy => policy.RequireClaim("permission", "CanViewSchedule"));
    options.AddPolicy("CanManageClasses", policy => policy.RequireClaim("permission", "CanManageClasses"));
    options.AddPolicy("CanManageUsers", policy => policy.RequireClaim("permission", "CanManageUsers"));
    options.AddPolicy("CanEditCourses", policy => policy.RequireClaim("permission", "CanEditCourses"));
    options.AddPolicy("FullAccess", policy => policy.RequireClaim("permission", "FullAccess"));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
