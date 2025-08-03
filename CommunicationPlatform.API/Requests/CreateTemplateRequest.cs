using CommunicationPlatform.Shared;

namespace CommunicationPlatform.API.Requests;

public class CreateTemplateRequest
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public BodyDto Body { get; set; }
}