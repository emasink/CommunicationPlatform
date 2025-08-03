using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Mappers;

public class TemplateMapper(IBodyMapper bodyMapper) 
    : ITemplateMapper
{
    public TemplateModel Map(TemplateEntity entity)
    {
        var template = new TemplateModel();
        template.Id = entity.Id;
        template.Name = entity.Name;
        template.Subject = entity.Subject;
        template.BodyModel = bodyMapper.Map(entity.Body);

        return template;
    }
}