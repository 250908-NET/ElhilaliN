using ProjectManagementApi.Models;

public interface IIssueRepository
{
    public Task<List<Issue>> SearchIssuesAsync(string? keyword, IssueStatus? status, IssuePriority? priority, int? assignedUserId, int? projectId, IssueType? type);
    
}