using AutoMapper;
using ProjectManagementApi.DTOs;
using ProjectManagementApi.Models;
using ProjectManagementApi.Services;

namespace ProjectManagementApi.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this WebApplication app)
        {
            var projectService = app.Services.GetRequiredService<IProjectService>();
            var mapper = app.Services.GetRequiredService<IMapper>();

            app.MapGet("/projects", async () =>
            {
                var projects = await projectService.GetAllAsync();
                return Results.Ok(mapper.Map<List<ProjectReadDTO>>(projects));
            });

            app.MapGet("/projects/{id:int}", async (int id) =>
            {
                var project = await projectService.GetByIdAsync(id);
                return project is not null ? Results.Ok(mapper.Map<ProjectReadDTO>(project)) : Results.NotFound();
            });

            app.MapPost("/projects", async (ProjectCreateDTO dto) =>
            {
                var project = mapper.Map<Project>(dto);
                var created = await projectService.CreateAsync(project);
                return Results.Created($"/projects/{created.Id}", mapper.Map<ProjectReadDTO>(created));
            });

            app.MapPut("/projects/{id:int}", async (int id, ProjectCreateDTO dto) =>
            {
                var project = await projectService.GetByIdAsync(id);
                if (project is null) return Results.NotFound();
                mapper.Map(dto, project);
                var updated = await projectService.UpdateAsync(project);
                return Results.Ok(mapper.Map<ProjectReadDTO>(updated));
            });

            app.MapDelete("/projects/{id:int}", async (int id) =>
            {
                await projectService.DeleteAsync(id);
                return Results.NoContent();
            });

            app.MapPost("/projects/{projectId:int}/addUser/{userId:int}", async (int projectId, int userId) =>
            {
                await projectService.AddUserAsync(projectId, userId);
                return Results.Ok();
            });

            app.MapPost("/projects/{projectId:int}/removeUser/{userId:int}", async (int projectId, int userId) =>
            {
                await projectService.RemoveUserAsync(projectId, userId);
                return Results.Ok();
            });

            app.MapGet("/projects/{projectId:int}/issues", async (int projectId) =>
            {
                var project = await projectService.GetProjectWithIssuesAsync(projectId);
                return project is not null ? Results.Ok(mapper.Map<List<IssueReadDTO>>(project.Issues)) : Results.NotFound();
            });

            app.MapGet("/projects/search", async (string? keyword) =>
            {
                var projects = await projectService.SearchProjectsAsync(keyword);
                return Results.Ok(mapper.Map<List<ProjectReadDTO>>(projects));
            });
            
            //Get all members of a project
            app.MapGet("/projects/{projectId:int}/members", async (int projectId) =>
            {
                var members = await projectService.GetMembersAsync(projectId);
                return Results.Ok(mapper.Map<List<UserReadDTO>>(members));
            });
        }
    }
}
