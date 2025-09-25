using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services;

public interface IIssueService : IService<Issue>
{
    Task<List<Issue>> SearchIssuesAsync(
        string? keyword = null,
        IssueStatus? status = null,
        IssuePriority? priority = null,
        int? assignedUserId = null,
        int? projectId = null,
        IssueType? type = null);

    public Task<bool> ChangeStatusAsync(int issueId, IssueStatus newStatus);
}
