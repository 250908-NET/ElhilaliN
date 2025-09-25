using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services;

public class ProjectService : Service<Project>, IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository) : base(projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task AddUserAsync(int projectId, int userId)
    {
        await _projectRepository.AddUserAsync(projectId, userId);
    }

    public async Task RemoveUserAsync(int projectId, int userId)
    {
        await _projectRepository.RemoveUserAsync(projectId, userId);
    }

    public async Task<Project?> GetProjectWithIssuesAsync(int projectId)
    {
        return await _projectRepository.GetProjectWithIssuesAsync(projectId);
    }

    public async Task<List<Project>> SearchProjectsAsync(string? keyword)
    {
        return await _projectRepository.SearchProjectsAsync(keyword);
    }
    public async Task<List<User>> GetMembersAsync(int projectId)
    {
        return await _projectRepository.GetMembersAsync(projectId);
    }
}
