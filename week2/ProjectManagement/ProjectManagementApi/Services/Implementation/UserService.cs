using ProjectManagementApi.Models;
using ProjectManagementApi.Services;

namespace ProjectManagementApi.Services;

public class UserService : Service<User> ,IUserService
{
private readonly IUserRepository _userRepository;

public UserService(IUserRepository userRepository) : base(userRepository)
{
    _userRepository = userRepository;
}

public async Task AssignIssueAsync(int userId, int issueId)
{
    await _userRepository.AssignIssueAsync(userId, issueId);
}

public async Task RemoveIssueAsync(int userId, int issueId)
{
    await _userRepository.RemoveIssueAsync(userId, issueId);
}

public async Task<List<Issue>> GetUserIssuesAsync(int userId)
{
    return await _userRepository.GetUserIssues(userId);
}

public async Task<List<Project>> GetProjectsAsync(int userId)
{
    return await _userRepository.GetProjectsAsync(userId);
}
}