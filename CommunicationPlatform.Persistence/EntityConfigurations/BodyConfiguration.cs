using CommunicationPlatform.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunicationPlatform.Persistence.EntityConfigurations;

public class BodyConfiguration : IEntityTypeConfiguration<BodyModel>
{
    public void Configure(EntityTypeBuilder<BodyModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}