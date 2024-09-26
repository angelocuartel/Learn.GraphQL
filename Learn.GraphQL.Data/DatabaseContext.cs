using Learn.GraphQL.Data.Entities;
using Learn.GraphQL.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Learn.GraphQL.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<PersonalDetail> personalDetail { get; set; }
	public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions):base(dbContextOptions)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PersonalDetailEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
