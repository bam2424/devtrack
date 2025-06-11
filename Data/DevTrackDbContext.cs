using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevTrack.Models;

namespace DevTrack.Data;

public class DevTrackDbContext : IdentityDbContext
{
    public DevTrackDbContext(DbContextOptions<DevTrackDbContext> options) : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<DevTask> Tasks { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure Project entity
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UserId).IsRequired();
            
            // One project has many tasks
            entity.HasMany(e => e.Tasks)
                .WithOne(e => e.Project)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Configure DevTask entity
        modelBuilder.Entity<DevTask>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Tags).HasMaxLength(500);
            
            // One task has many time logs
            entity.HasMany(e => e.TimeLogs)
                .WithOne(e => e.Task)
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Configure TimeLog entity
        modelBuilder.Entity<TimeLog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.UserId).IsRequired();
        });
    }
} 