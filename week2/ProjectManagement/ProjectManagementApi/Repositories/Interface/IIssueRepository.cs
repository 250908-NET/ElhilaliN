using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public interface IIssueRepository : IRepository<Issue>
{
    public Task<List<Issue>> SearchIssuesAsync(string? keyword, IssueStatus? status, IssuePriority? priority, int? assignedUserId, int? projectId, IssueType? type);
    
}