using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.Files;

public class FileParserContext : IFileParserContext
{
    private IFileParser fileParser;
    
    public void SetParser(IFileParser fileParser)
    {
        this.fileParser = fileParser;
    }
    
    public CreateTranslationJobDto Parse(string fileContent, string? customerName)
    {
        return fileParser.Parse(fileContent, customerName);
    }
}