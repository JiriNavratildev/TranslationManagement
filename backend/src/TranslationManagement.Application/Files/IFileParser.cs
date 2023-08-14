using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.Files;

public interface IFileParser
{
    CreateTranslationJobDto Parse(string fileContent, string? customerName);
}