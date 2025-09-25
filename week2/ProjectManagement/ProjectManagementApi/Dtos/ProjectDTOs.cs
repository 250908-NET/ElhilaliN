namespace ProjectManagementApi.DTOs
{
    public class ProjectCreateDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ManagerId { get; set; }
    }

    public class ProjectReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ManagerId { get; set; }
        public List<int> IssueIds { get; set; } = new();
    }
}
