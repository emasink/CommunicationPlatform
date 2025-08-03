using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Mappers;

public class BodyMapper : IBodyMapper
{
    public BodyModel Map(BodyEntity entity)
    {
        var body = new BodyModel();
        body.Id = entity.Id;
        body.Text = entity.Text;

        return body;
    }
}