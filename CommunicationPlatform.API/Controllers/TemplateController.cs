using CommunicationPlatform.API.Requests;
using CommunicationPlatform.ServiceAbstractions;
using CommunicationPlatform.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemplateController(ITemplateService templateService) : Controller
{
    [HttpGet]
    [Route("template/{id:int}")]
    public async Task<IActionResult> GetTemplateById(int id)
    {
        var template = await templateService.GetByIdAsync(id);

        return template == null
            ? NotFound("TemplateModel is not present in the database. ")
            : Ok(template);
    }

    [HttpGet]
    [Route("templates")]
    public async Task<IActionResult> GetTemplates()
    {
        var templates = await templateService.GetAllAsync();

        return Ok(templates);
    }

    [HttpPost]
    [Route("createTemplate")]
    public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateRequest request)
    {
        var template = new TemplateEntity
        {
            Name = request.Name,
            Subject = request.Subject,
            Body = request.Body
        };
        await templateService.AddTemplate(template);

        return Ok();
    }

    [HttpPost]
    [Route("updateTemplate")]
    public async Task<IActionResult> UpdateTemplate([FromBody] TemplateEntity template)
    {
        await templateService.UpdateTemplateAsync(template);
        return Ok();
    }

    [HttpDelete]
    [Route("deleteTemplate")]
    public async Task<IActionResult> DeleteTemplate([FromBody] int templateId)
    {
        await templateService.DeleteTemplate(templateId);

        return Ok();
    }
}