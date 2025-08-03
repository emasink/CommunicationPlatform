using System.Text.RegularExpressions;
using CommunicationPlatform.Services.Exceptions;
using CommunicationPlatform.Services.Interfaces;
using CommunicationPlatform.Services.Services;

namespace CommunicationPlatform.Services.Validators;

public class PlaceholderValidator : IPlaceholderValidator
{
    public void ValidatePlaceholders(string body, Dictionary<string, string> placeholderValues)
    {
        var matches = Regex.Matches(body, @"{{\s*(.*?)\s*}}");

        foreach (Match match in matches)
        {
            if (!placeholderValues.ContainsKey(match.Groups[1].Value))
            {
                throw new InsufficientPlaceholdersException();
            }
        }
    }
}