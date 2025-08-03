namespace CommunicationPlatform.API.Requests;

public class SendEmailRequest
{
    public int CustomerId { get; set; }
    public int TemplateId { get; set; }
    public Dictionary<string, string> PlaceholderValues { get; set; }
}