using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.Files;

public class TxtFileParser : IFileParser
{
    public CreateTranslationJobDto Parse(string fileContent, string? customerName)
    {
        var result = new CreateTranslationJobDto
        {
            CustomerName = customerName ?? throw new Exception(),
            OriginalContent = fileContent
        };

        return result;
    }
}