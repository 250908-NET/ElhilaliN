using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services;

public interface IProjectService : IService<Project>
{
    Task AddUserAsync(int projectId, int userId);
    Task RemoveUserAsync(int projectId, int userId);
    Task<Project?> GetProjectWithIssuesAsync(int projectId);
    Task<List<Project>> SearchProjectsAsync(string? keyword);
    Task<List<User>> GetMembersAsync(int projectId);
}
