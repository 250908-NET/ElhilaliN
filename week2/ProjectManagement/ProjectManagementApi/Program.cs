using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Services;
using ProjectManagementApi.Mappings;
using ProjectManagementApi.DTOs;
using ProjectManagementApi.Models;
using AutoMapper;
using ProjectManagementApi.Endpoints;


var builder = WebApplication.CreateBuilder(args);

string connectionString = File.ReadAllText("../.env");
Console.WriteLine(connectionString);
//Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Map endpoints
app.MapUserEndpoints();
app.MapProjectEndpoints();
app.MapIssueEndpoints();

app.Run();
