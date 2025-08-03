namespace CommunicationPlatform.Services.Interfaces;

public interface IPlaceholderValidator
{
    void ValidatePlaceholders(string body, Dictionary<string, string> placeholderValues);
}