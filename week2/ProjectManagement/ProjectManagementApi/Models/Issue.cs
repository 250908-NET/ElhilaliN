namespace ProjectManagementApi.Models;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public IssueType Type { get; set; }
    public IssueStatus Status { get; set; } = IssueStatus.ToDo;
    public IssuePriority Priority { get; set; } = IssuePriority.Medium;

    public int ProjectId { get; set; }    // Foreign key
    public Project Project { get; set; } = null!; // Navigation property

    public int? AssignedUserId { get; set; } // Optional
    public User? AssignedUser { get; set; }
}