namespace CommunicationPlatform.ServiceAbstractions;

public interface IMessagingService
{
    Task<string> SendMessageAsync(int customerId, int templateId, Dictionary<string, string> placeholderValues);
}