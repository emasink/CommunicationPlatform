using CommunicationPlatform.Persistence.Entities;
using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Extensions;

public static class BodyExtensions
{
    public static BodyDto ToDto(this BodyModel bodyModel)
    {
        var bodyDto = new BodyDto();
        bodyDto.Id = bodyModel.Id;
        bodyDto.Text = bodyModel.Text;

        return bodyDto;
    }
}