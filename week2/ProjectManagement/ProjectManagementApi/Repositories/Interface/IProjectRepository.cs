using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public interface IProjectRepository
{
    Task<Project> GetProjectWithIssuesAsync(int projectId);
    Task AddUserAsync(int projectId, int userId);
    Task RemoveUserAsync(int projectId, int userId);

    Task<List<Project>> SearchProjectsAsync(string? keyword);
}