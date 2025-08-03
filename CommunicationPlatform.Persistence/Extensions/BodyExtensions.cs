using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Extensions;

public static class BodyExtensions
{
    public static BodyEntity ToDto(this BodyModel bodyModel)
    {
        var bodyDto = new BodyEntity();
        bodyDto.Id = bodyModel.Id;
        bodyDto.Text = bodyModel.Text;

        return bodyDto;
    }
}