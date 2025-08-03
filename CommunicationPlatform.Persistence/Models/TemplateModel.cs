using CommunicationPlatform.Persistence.Models;

namespace CommunicationPlatform.Persistence.Entities;

public class TemplateModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }

    public BodyModel BodyModel { get; set; }
}