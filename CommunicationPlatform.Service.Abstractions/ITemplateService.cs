using CommunicationPlatform.Shared;

namespace CommunicationPlatform.ServiceAbstractions;

public interface ITemplateService
{
    Task<IEnumerable<TemplateEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddTemplate(TemplateEntity template, CancellationToken cancellationToken = default);
    Task UpdateTemplateAsync(TemplateEntity template, CancellationToken cancellationToken = default);
    Task DeleteTemplate(int id, CancellationToken cancellationToken = default);
    Task<TemplateEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}