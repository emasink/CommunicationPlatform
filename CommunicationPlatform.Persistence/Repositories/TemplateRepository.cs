using CommunicationPlatform.Core.Interfaces;
using CommunicationPlatform.Persistence.Extensions;
using CommunicationPlatform.Persistence.Interfaces;
using CommunicationPlatform.Persistence.Mappers;
using CommunicationPlatform.Repository;
using CommunicationPlatform.Shared;
using Microsoft.EntityFrameworkCore;

namespace CommunicationPlatform.Persistence.Repositories;
public class TemplateRepository(DatabaseContext context,
    ITemplateMapper templateMapper,
    IBodyMapper bodyMapper) 
    : ITemplateRepository
{
    public async Task<List<TemplateEntity>> GetTemplatesAsync()
    {
        var templates = await context.Templates
            .Include(x => x.BodyModel)
            .ToListAsync();

        return templates
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task AddTemplateAsync(TemplateEntity template)
    {
        var entity = templateMapper.Map(template);
        var body = bodyMapper.Map(template.Body);

        var entityEntry = context.Bodies.Add(body);

        entity.BodyModel = entityEntry.Entity;
        context.Templates.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTemplateAsync(int id)
    {
        var template = await context.Templates.FirstOrDefaultAsync(x => x.Id == id);
        if (template != null) context.Templates.Remove(template);
        await context.SaveChangesAsync();
    }

    public async Task<TemplateEntity> UpdateTemplateAsync(TemplateEntity templateEntity)
    {
        var templateModel = templateMapper.Map(templateEntity);          
        var updatedTemplate = context.Templates.Update(templateModel).Entity.ToDto();
        await context.SaveChangesAsync();

        return updatedTemplate;
    }
    
    public async Task<TemplateEntity?> GetTemplateByIdAsync(int id)
    {
        var template = await context.Templates
            .Include(x => x.BodyModel)
            .FirstOrDefaultAsync(x => x.Id == id);
        return template?.ToDto();
    }

}