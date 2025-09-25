using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services;

public interface IUserService 
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(int id);

    Task AssignIssueAsync(int userId, int issueId);
    Task RemoveIssueAsync(int userId, int issueId);

    Task<List<Issue>> GetUserIssuesAsync(int userId);
    Task<List<Project>> GetProjectsAsync(int userId);
}
