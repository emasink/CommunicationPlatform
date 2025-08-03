using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Mappers;

public interface ITemplateMapper
{
    TemplateModel Map(TemplateEntity dto);
}