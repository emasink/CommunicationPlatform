using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace CommunicationPlatform.Repository;

public class DatabaseConfiguration : DbConfiguration
{
    public DatabaseConfiguration()
    {
        SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
    }
}