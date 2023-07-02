using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Component> Components { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
        base.OnModelCreating(modelBuilder);
    }
}