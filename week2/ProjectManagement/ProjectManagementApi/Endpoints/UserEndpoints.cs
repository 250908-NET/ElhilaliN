using AutoMapper;
using ProjectManagementApi.DTOs;
using ProjectManagementApi.Models;
using ProjectManagementApi.Services;

namespace ProjectManagementApi.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            var userService = app.Services.GetRequiredService<IUserService>();
            var mapper = app.Services.GetRequiredService<IMapper>();

            app.MapGet("/users", async () =>
            {
                var users = await userService.GetAllAsync();
                return Results.Ok(mapper.Map<List<UserReadDTO>>(users));
            });

            app.MapGet("/users/{id:int}", async (int id) =>
            {
                var user = await userService.GetByIdAsync(id);
                return user is not null ? Results.Ok(mapper.Map<UserReadDTO>(user)) : Results.NotFound();
            });

            app.MapPost("/users", async (UserCreateDTO dto) =>
            {
                var user = mapper.Map<User>(dto);
                var created = await userService.CreateAsync(user);
                return Results.Created($"/users/{created.Id}", mapper.Map<UserReadDTO>(created));
            });

            app.MapPut("/users/{id:int}", async (int id, UserCreateDTO dto) =>
            {
                var user = await userService.GetByIdAsync(id);
                if (user is null) return Results.NotFound();
                mapper.Map(dto, user);
                var updated = await userService.UpdateAsync(user);
                return Results.Ok(mapper.Map<UserReadDTO>(updated));
            });

            app.MapDelete("/users/{id:int}", async (int id) =>
            {
                await userService.DeleteAsync(id);
                return Results.NoContent();
            });

            app.MapPost("/users/{userId:int}/assign/{issueId:int}", async (int userId, int issueId) =>
            {
                await userService.AssignIssueAsync(userId, issueId);
                return Results.Ok();
            });

            app.MapPost("/users/{userId:int}/remove/{issueId:int}", async (int userId, int issueId) =>
            {
                await userService.RemoveIssueAsync(userId, issueId);
                return Results.Ok();
            });

            app.MapGet("/users/{userId:int}/issues", async (int userId) =>
            {
                var issues = await userService.GetUserIssuesAsync(userId);
                return Results.Ok(mapper.Map<List<IssueReadDTO>>(issues));
            });

            app.MapGet("/users/{userId:int}/projects", async (int userId) =>
            {
                var projects = await userService.GetProjectsAsync(userId);
                return Results.Ok(mapper.Map<List<ProjectReadDTO>>(projects));
            });
        }
    }
}
