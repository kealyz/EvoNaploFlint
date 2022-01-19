using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.Services;
using EvoNaplo.UserDomain.Facades;
using EvoNaplo.UserDomain.Models;
using EvoNaplo.UserDomain.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<EvoNaploContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<SemesterService>();
builder.Services.AddScoped<MentorService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserHelper>();
builder.Services.AddScoped<IUserFacade, UserFacade>();

builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<ProjectStudentService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<AttendanceSheetService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MySite", builder =>
    {
        builder.WithOrigins("http://localhost:3000","http://127.0.0.1:3000", "https://localhost:3000", "https://127.0.0.1:3000")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

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

app.UseCors("MySite");

app.Run();
