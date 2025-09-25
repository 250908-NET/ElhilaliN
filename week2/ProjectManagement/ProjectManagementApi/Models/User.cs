namespace ProjectManagementApi.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Project> Projects { get; set; } = new();
    public List<Issue> AssignedIssues { get; set; } = new();

}