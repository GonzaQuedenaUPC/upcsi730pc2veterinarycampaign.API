using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Manager>().ToTable("Managers");
        builder.Entity<Manager>().HasKey(m => m.Id);
        builder.Entity<Manager>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Manager>().Property(m => m.FirstName).IsRequired().HasMaxLength(40);
        builder.Entity<Manager>().Property(m => m.LastName).IsRequired().HasMaxLength(40);
        builder.Entity<Manager>().Property(m => m.ApprovedAt).IsRequired();
        builder.Entity<Manager>().Property(m => m.ReportedAt).IsRequired();
        builder.Entity<Manager>().Property(m => m.ContactedAt).IsRequired();
        builder.Entity<Manager>().Property(m => m.Status).IsRequired(); 

        builder.UseSnakeCaseNamingConvention();
    }
}