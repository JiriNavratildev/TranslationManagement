using System.Xml.Linq;
using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.Files;

public class XmlFileParser : IFileParser
{
    public CreateTranslationJobDto Parse(string fileContent, string? customerName)
    {
        var xdoc = XDocument.Parse(fileContent);

        var result = new CreateTranslationJobDto
        {
            OriginalContent = xdoc.Root?.Element("Content")?.Value ?? throw new Exception(),
            CustomerName = xdoc.Root?.Element("Customer")?.Value.Trim() ?? customerName ?? throw new Exception()
        };

        return result;
    }
}