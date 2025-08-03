using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunicationPlatform.Repository;

public class DatabaseContext(IConfigurationService configurationService) : DbContext
{
    public DbSet<TemplateModel> Templates { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<BodyModel> Bodies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = configurationService.GetDatabaseConnection();

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}