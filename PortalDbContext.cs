using InternalPortal.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternalPortal.Api;

public class PortalDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public PortalDbContext(DbContextOptions<PortalDbContext> options): base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);

    }


}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName)
            .HasColumnName("firstName")
            .HasColumnType("varchar(60)");
        builder.Property(x => x.LastName)
           .HasColumnName("lastName")
           .HasColumnType("varchar(60)");
        builder.Property(x => x.Email)
           .HasColumnName("email")
           .HasColumnType("varchar(120)");
    }
}
