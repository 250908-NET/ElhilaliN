using AutoMapper;
using ProjectManagementApi.DTOs;
using ProjectManagementApi.Models;
using ProjectManagementApi.Services;

namespace ProjectManagementApi.Endpoints
{
    public static class IssueEndpoints
    {
        public static void MapIssueEndpoints(this WebApplication app)
        {
            var issueService = app.Services.GetRequiredService<IIssueService>();
            var mapper = app.Services.GetRequiredService<IMapper>();

            app.MapGet("/issues", async () =>
            {
                var issues = await issueService.GetAllAsync();
                return Results.Ok(mapper.Map<List<IssueReadDTO>>(issues));
            });

            app.MapGet("/issues/{id:int}", async (int id) =>
            {
                var issue = await issueService.GetByIdAsync(id);
                return issue is not null ? Results.Ok(mapper.Map<IssueReadDTO>(issue)) : Results.NotFound();
            });

            app.MapPost("/issues", async (IssueCreateDTO dto) =>
            {
                var issue = mapper.Map<Issue>(dto);
                var created = await issueService.CreateAsync(issue);
                return Results.Created($"/issues/{created.Id}", mapper.Map<IssueReadDTO>(created));
            });

            app.MapPut("/issues/{id:int}", async (int id, IssueCreateDTO dto) =>
            {
                var issue = await issueService.GetByIdAsync(id);
                if (issue is null) return Results.NotFound();
                mapper.Map(dto, issue);
                var updated = await issueService.UpdateAsync(issue);
                return Results.Ok(mapper.Map<IssueReadDTO>(updated));
            });

            app.MapDelete("/issues/{id:int}", async (int id) =>
            {
                await issueService.DeleteAsync(id);
                return Results.NoContent();
            });

            app.MapGet("/issues/search", async (
                string? keyword,
                IssueStatus? status,
                IssuePriority? priority,
                int? assignedUserId,
                int? projectId,
                IssueType? type) =>
            {
                var issues = await issueService.SearchIssuesAsync(keyword, status, priority, assignedUserId, projectId, type);
                return Results.Ok(mapper.Map<List<IssueReadDTO>>(issues));
            });
        }
    }
}
