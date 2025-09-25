using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

namespace ProjectManagementApi.Services;

public class IssueService : Service<Issue>, IIssueService
{
    private readonly IIssueRepository _issueRepository;

    public IssueService(IIssueRepository issueRepository) : base(issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<List<Issue>> SearchIssuesAsync(
        string? keyword = null,
        IssueStatus? status = null,
        IssuePriority? priority = null,
        int? assignedUserId = null,
        int? projectId = null,
        IssueType? type = null)
    {
        return await _issueRepository.SearchIssuesAsync(
            keyword, status, priority, assignedUserId, projectId, type);
    }

    public async Task<bool> ChangeStatusAsync(int issueId, IssueStatus newStatus)
{
    var issue = await _issueRepository.GetByIdAsync(issueId);
    if (issue == null) return false;

    var current = issue.Status;

    // Define valid transitions
    var validTransitions = new Dictionary<IssueStatus, List<IssueStatus>>
    {
        { IssueStatus.ToDo,        new List<IssueStatus> { IssueStatus.InProgress, IssueStatus.Blocked } },
        { IssueStatus.InProgress,  new List<IssueStatus> { IssueStatus.Done, IssueStatus.Blocked, IssueStatus.ToDo } },
        { IssueStatus.Blocked,     new List<IssueStatus> { IssueStatus.ToDo, IssueStatus.InProgress } },
        { IssueStatus.Done,        new List<IssueStatus>() } // final state
    };

    // Check if transition is valid
    if (!validTransitions[current].Contains(newStatus))
    {
        return false; // Invalid transition
    }

    issue.Status = newStatus;
    await _issueRepository.UpdateAsync(issue);
    return true;
}

}
