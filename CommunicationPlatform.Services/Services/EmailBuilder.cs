using CommunicationPlatform.Services.Interfaces;
using CommunicationPlatform.Shared;
using DotLiquid;

namespace CommunicationPlatform.Services.Services;

internal class EmailBuilder(IPlaceholderValidator placeholderValidator) : IEmailBuilder
{
    public async Task<string> BuildEmailContentAsync(string body, Dictionary<string, string> placeholderValues)
    {
        placeholderValidator.ValidatePlaceholders(body, placeholderValues);
        
        var template = Template.Parse(body);
        var dotLiquidDictionary = placeholderValues
            .ToDictionary(
                x => x.Key, 
                x => (object)x.Value);
        var email = template.Render(Hash.FromDictionary(dotLiquidDictionary));

        return email;
    }
}