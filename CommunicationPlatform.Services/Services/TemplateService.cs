using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;

namespace CommunicationPlatform.Services;

internal class TemplateService(ITemplateRepository templateRepository)
    : ITemplateService
{
    public async Task<IEnumerable<TemplateEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await templateRepository.GetTemplatesAsync();
    }

    public async Task AddTemplate(TemplateEntity template, CancellationToken cancellationToken = default)
    {
        await templateRepository.AddTemplateAsync(template);
    }

    public async Task UpdateTemplateAsync(TemplateEntity template, CancellationToken cancellationToken = default)
    {
        await templateRepository.UpdateTemplateAsync(template);
    }

    public async Task DeleteTemplate(int id, CancellationToken cancellationToken = default)
    {
        await templateRepository.DeleteTemplateAsync(id);
    }

    public async Task<TemplateEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await templateRepository.GetTemplateByIdAsync(id);
    }
}