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
    [Route("{id:int}")]
    public async Task<IActionResult> GetTemplateById(int id)
    {
        var template = await templateService.GetByIdAsync(id);

        return template == null
            ? NotFound("TemplateModel is not present in the database. ")
            : Ok(template);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetTemplates()
    {
        var templates = await templateService.GetAllAsync();

        return Ok(templates);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateRequest request)
    {
        var template = new TemplateEntity
        {
            Name = request.Name,
            Subject = request.Subject,
            Body = new BodyEntity(){Text = request.Body}
        };
        await templateService.AddTemplate(template);

        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateTemplate([FromBody] TemplateEntity template)
    {
        await templateService.UpdateTemplateAsync(template);
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> DeleteTemplate(int id)
    {
        await templateService.DeleteTemplate(id);

        return Ok();
    }
}