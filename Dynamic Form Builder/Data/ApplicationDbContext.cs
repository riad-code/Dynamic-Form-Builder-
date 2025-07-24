using Dynamic_Form_Builder.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<DropdownField> DropdownFields { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.Fields)
            .WithOne(f => f.Form)
            .HasForeignKey(f => f.FormId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

