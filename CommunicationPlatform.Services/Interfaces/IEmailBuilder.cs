namespace CommunicationPlatform.Services.Services;

public interface IEmailBuilder
{
    Task<string> BuildEmailContentAsync(string body, Dictionary<string, string> placeholderValues);
}