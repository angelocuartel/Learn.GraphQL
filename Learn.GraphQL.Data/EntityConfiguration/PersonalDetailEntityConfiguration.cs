using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Learn.GraphQL.Data.Entities;

namespace Learn.GraphQL.Data.EntityConfiguration;

public class PersonalDetailEntityConfiguration : IEntityTypeConfiguration<PersonalDetail>
{
    public void Configure(EntityTypeBuilder<PersonalDetail> builder)
    {
        builder.ToTable("PersonalDetail")
               .HasKey(i => i.PersonalDetailId);
    }
}
