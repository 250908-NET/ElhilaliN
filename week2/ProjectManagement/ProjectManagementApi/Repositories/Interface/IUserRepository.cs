using ProjectManagementApi.Models;

public interface IUserRepository
{
    public Task<List<Issue>> GetUserIssues(int UserId);
    public Task AssignIssueAsync(int userId, int IssueId);

    public Task RemoveIssueAsync(int userId, int IssueId);
    public Task<List<Project>> GetProjectsAsync(int UserId);
}