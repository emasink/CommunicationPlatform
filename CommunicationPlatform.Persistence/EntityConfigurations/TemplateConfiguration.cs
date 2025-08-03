using CommunicationPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunicationPlatform.Persistence.EntityConfigurations;

public class TemplateConfiguration : IEntityTypeConfiguration<TemplateModel>
{
    public void Configure(EntityTypeBuilder<TemplateModel> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Name);

        builder.Property(t => t.Subject).IsRequired();
    }
}