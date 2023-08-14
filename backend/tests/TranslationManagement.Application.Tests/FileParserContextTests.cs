using FluentAssertions;
using NUnit.Framework;
using TranslationManagement.Application.Files;

namespace TranslationManagement.Application.Tests;

public class FileParserContextTests
{
    [Test]
    public void FileParser_Should_Correctly_Parse_TXT_File()
    {
        var fileContent = File.ReadAllText("TestData/job.txt");
        const string customerName = "Jon Doe";
        var fileParserContext = new FileParserContext();
        fileParserContext.SetParser(new TxtFileParser());

        var result = fileParserContext.Parse(fileContent, customerName);

        result.Should().NotBeNull();
        result.OriginalContent.Should().Be(fileContent);
        result.CustomerName.Should().Be(customerName);
    }
}