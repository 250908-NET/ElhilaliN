using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Models;
using ProjectManagementApi.Repositories;

public class IssueRepository : Repository<Issue>, IIssueRepository
{
    public IssueRepository(AppDbContext _context) : base(_context) { }

    public async Task<List<Issue>> SearchIssuesAsync(string? keyword, IssueStatus? status, IssuePriority? priority, int? assignedUserId, int? projectId, IssueType? type)
    {
       var query = _context.Issues.AsQueryable();

    // Keyword search (Title or Description)
    if (!string.IsNullOrWhiteSpace(keyword))
    {
        query = query.Where(i => i.Title.Contains(keyword) 
                              || (i.Description != null && i.Description.Contains(keyword)));
    }

    // Filter by Status
    if (status.HasValue)
    {
        query = query.Where(i => i.Status == status.Value);
    }

    // Filter by Priority
    if (priority.HasValue)
    {
        query = query.Where(i => i.Priority == priority.Value);
    }

    // Filter by Type (Bug, Feature, etc.)
    if (type.HasValue)
    {
        query = query.Where(i => i.Type == type.Value);
    }

    // Filter by Assigned User
    if (assignedUserId.HasValue)
    {
        query = query.Where(i => i.AssignedUserId == assignedUserId.Value);
    }

    // Filter by Project
    if (projectId.HasValue)
    {
        query = query.Where(i => i.ProjectId == projectId.Value);
    }

    return await query.ToListAsync();
    }
}