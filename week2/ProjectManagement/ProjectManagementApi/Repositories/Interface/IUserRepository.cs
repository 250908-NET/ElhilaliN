using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<List<Issue>> GetUserIssues(int UserId);
    public Task AssignIssueAsync(int userId, int IssueId);

    public Task RemoveIssueAsync(int userId, int IssueId);
    public Task<List<Project>> GetProjectsAsync(int UserId);
}