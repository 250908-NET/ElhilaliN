using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services;

public interface IUserService 
{
     Task<List<Issue>> GetUserIssues(int id);
     Task<List<Project>> GetUserProjects(int id);
}
