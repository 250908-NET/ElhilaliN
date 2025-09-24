namespace ProjectManagemetApi.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<object> Projects { get; set; } = new();
    public List<object> AssignedIssues { get; set; } = new();

}