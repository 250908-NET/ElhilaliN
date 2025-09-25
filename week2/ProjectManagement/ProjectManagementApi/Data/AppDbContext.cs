using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Issue> Issues => Set<Issue>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Project>()
        //     .HasOne(p => p.Manager)
        //     .WithMany(u => u.Projects)
        //     .HasForeignKey(p => p.ManagerId)
        //     .OnDelete(DeleteBehavior.SetNull);

        // modelBuilder.Entity<Issue>()
        //     .HasOne(i => i.AssignedUser)
        //     .WithMany(u => u.AssignedIssues)
        //     .HasForeignKey(i => i.AssignedUserId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}