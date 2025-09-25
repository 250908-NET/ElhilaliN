using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AssignIssueAsync(int userId, int IssueId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found.");

        await _context.Entry(user)
                 .Collection(u => u.AssignedIssues)
                 .LoadAsync();

        var issue = await _context.Issues.FindAsync(IssueId);
        if (issue == null)
            throw new KeyNotFoundException($"Issue with ID {IssueId} not found.");

        if (!user.AssignedIssues.Contains(issue))
        {
            user.AssignedIssues.Add(issue);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Project>> GetProjectsAsync(int userId)
    {
        return await _context.Projects
                        .Where(p => p.ManagerId == userId)
                        .ToListAsync();
    }
    public async Task<List<Issue>> GetUserIssues(int userId)
    {
        return await _context.Issues
                        .Where(i => i.AssignedUserId == userId)
                        .ToListAsync();
    }

    public async Task RemoveIssueAsync(int userId, int IssueId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found.");

        await _context.Entry(user)
                 .Collection(u => u.AssignedIssues)
                 .LoadAsync();


        var issue = await _context.Issues.FindAsync(IssueId);
        if (issue == null)
            throw new KeyNotFoundException($"Issue with ID {IssueId} not found.");

        if (!user.AssignedIssues.Contains(issue))
        {
            user.AssignedIssues.Remove(issue);
            await _context.SaveChangesAsync();
        }
    }
}