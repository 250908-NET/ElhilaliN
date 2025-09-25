using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{

    public ProjectRepository(AppDbContext _context) : base(_context)
    {
    }

    public async Task AddUserAsync(int projectId, int userId)
    {
        var project = await _context.Projects.FindAsync(projectId);
        var user = await _context.Users.FindAsync(userId);

        if (project == null)
            throw new KeyNotFoundException($"Project with ID {projectId} not found.");
        if (user == null)
            throw new KeyNotFoundException($"User with ID {userId} not found.");

        await _context.SaveChangesAsync();
    }

    public async Task<Project?> GetProjectWithIssuesAsync(int projectId)
    {

        return await _context.Projects
                 .Include(P => P.Issues)
                     .ThenInclude(i => i.AssignedUser)
                 .FirstOrDefaultAsync(p => p.Id == projectId);

    }

    public async Task RemoveUserAsync(int projectId, int userId)
    {
        Project? project = await _context.Projects.FindAsync(projectId);

        if (project == null)
            throw new KeyNotFoundException($"Project with ID {projectId} cannot be found.");

        if (project.ManagerId == userId)
        {
            project.ManagerId = null;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Project>> SearchProjectsAsync(
    string? keyword)
    {
        var query = _context.Projects.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(p => p.Name.Contains(keyword)
                                  || (p.Description != null && p.Description.Contains(keyword)));
        }
        query = query.Include(p => p.Issues);

        return await query.ToListAsync();
    }

    public async Task<List<User>> GetMembersAsync(int projectId)
    {
        var project = await _context.Projects
            .Include(p => p.Issues)
                .ThenInclude(i => i.AssignedUser)
            .Include(p => p.Manager)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project == null)
            throw new KeyNotFoundException($"Project with ID {projectId} not found.");

        // Members = Manager + Assigned Users
        var members = new List<User>();
        if (project.Manager != null)
            members.Add(project.Manager);

        members.AddRange(project.Issues
            .Where(i => i.AssignedUser != null)
            .Select(i => i.AssignedUser!)
            .Distinct());

        return members;
    }

}