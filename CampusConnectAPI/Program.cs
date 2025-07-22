using System.Text;
using CampusConnectAPI;
using CampusConnectAPI.Repositories.implementation;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.implementation;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
 

builder.Services.AddScoped<IAuthRepository ,AuthRepository>();
builder.Services.AddScoped<IAuthSevices, AuthServices>();
builder.Services.AddScoped<ICourseEnrollmentRepository ,CourseEnrollmentRepository>();
builder.Services.AddScoped<ICourseEnrollmentService ,CourseEnrollmentService>();
builder.Services.AddScoped<ISubjectGradeRepository, SubjectGradeRepository>();
builder.Services.AddScoped<ISubjectGradeService , SubjectGradeService>();
builder.Services.AddScoped<IAttendanceRepository ,AttendanceRepository>();
builder.Services.AddScoped<IAttendanceService ,AttendanceService>();
builder.Services.AddScoped<IFeeTransactionRepository ,FeeTransactionRepository>();
builder.Services.AddScoped<IFeeTransactionService ,FeeTransactionService>();

//Jwt   Related   Code  

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

        };
    });
    
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
