using Learn.GraphQL.Infrastructure.EntityConfiguration;
using Learn.GraphQL.Domain;
using Microsoft.EntityFrameworkCore;

namespace Learn.GraphQL.Infrastructure;

internal class DatabaseContext : DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<PersonalDetail> personalDetail { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PersonalDetailEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
