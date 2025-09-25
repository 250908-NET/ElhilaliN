using ProjectManagementApi.Models;

namespace ProjectManagementApi.DTOs
{
    public class IssueCreateDTO
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public IssueStatus Status { get; set; }
        public IssuePriority Priority { get; set; }
        public int? AssignedUserId { get; set; }
        public int ProjectId { get; set; }
        public IssueType Type { get; set; }
    }

    public class IssueReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public IssueStatus Status { get; set; }
        public IssuePriority Priority { get; set; }
        public int? AssignedUserId { get; set; }
        public int ProjectId { get; set; }
        public IssueType Type { get; set; }
    }
}
