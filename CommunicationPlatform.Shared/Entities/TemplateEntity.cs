namespace CommunicationPlatform.Shared;

public class TemplateEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public BodyEntity Body { get; set; }
}