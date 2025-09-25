namespace ProjectManagementApi.DTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class UserReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<int> AssignedIssueIds { get; set; } = new();
    }
}
