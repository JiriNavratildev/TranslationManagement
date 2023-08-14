using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.Files;

public interface IFileParserContext
{
    void SetParser(IFileParser fileParser);
    CreateTranslationJobDto Parse(string fileContent, string? customerName);
}