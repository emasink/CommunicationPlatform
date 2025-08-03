using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Extensions;

public static class TemplateExtensions
{
    public static TemplateEntity ToDto(this TemplateModel templateModel) => new()
    {
        Id = templateModel.Id,
        Name = templateModel.Name,
        Subject = templateModel.Subject,
        Body = templateModel.BodyModel.ToDto()
    };
}