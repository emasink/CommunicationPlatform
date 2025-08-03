using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Mappers;

public class BodyMapper : IBodyMapper
{
    public BodyModel Map(BodyDto dto)
    {
        var body = new BodyModel();
        body.Id = dto.Id;
        body.Text = dto.Text;

        return body;
    }
}