using CommunicationPlatform.Persistence.Models;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Persistence.Interfaces;

public interface IBodyMapper
{
    BodyModel Map(BodyDto dto);
}