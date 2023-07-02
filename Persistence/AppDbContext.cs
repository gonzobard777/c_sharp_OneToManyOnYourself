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
        modelBuilder.Entity<Component>(b =>
        {
            b.ToTable("Components");
            b.HasKey(x => x.Id).HasName("PK_Components_Id");
        });

        /*
         * One Component - to - Many Components
         */
        modelBuilder.Entity<Component>(b =>
        {
            b.HasIndex(x => x.ParentId, "IX_Components_ParentId").IsUnique(false);

            b
                .HasOne(component => component.Parent)
                .WithMany(component => component.Children)
                .HasForeignKey(component => component.ParentId)
                .HasConstraintName("FK_Components_ParentId")
                .OnDelete(DeleteBehavior.SetNull); // MSSQL не позволяет: удалять каскадно и заNull'ять
        });
    }
}