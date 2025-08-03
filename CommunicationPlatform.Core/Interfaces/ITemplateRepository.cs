using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Core.Interfaces;

public interface ITemplateRepository
{
    Task<List<TemplateEntity>> GetTemplatesAsync();
    Task<TemplateEntity> GetTemplateByIdAsync(int id);
    Task AddTemplateAsync(TemplateEntity template);
    Task DeleteTemplateAsync(int id);
    Task<TemplateEntity?> UpdateTemplateAsync(TemplateEntity template);
}