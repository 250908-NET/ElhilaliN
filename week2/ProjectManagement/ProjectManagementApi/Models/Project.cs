namespace ProjectManagementApi.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int? ManagerId { get; set; }
    public User? Manager{ get; set; }
    public List<object> Issues { get; set; } = new();
}