using FluentAssertions;
using NUnit.Framework;
using TranslationManagement.Application.Files;

namespace TranslationManagement.Application.Tests;

public class FileHelperTests
{
    [Test]
    public void FileHelper_Should_Correctly_Parse_TXT_File()
    {
        var fileName = "sampleFile.txt";

        var parsed = FileHelper.TryParseFileType(fileName, out var fileType);

        parsed.Should().BeTrue();
        fileType.Should().Be(FileType.TXT);
    }

    [Test]
    public void FileHelper_Parse_Is_Case_Insensitive()
    {
        var fileName = "sampleFile.txT";

        var parsed = FileHelper.TryParseFileType(fileName, out var fileType);

        parsed.Should().BeTrue();
        fileType.Should().Be(FileType.TXT);
    }

    [Test]
    public void FileHelper_Try_Parse_Unsupported_File()
    {
        var fileName = "sampleFile.foo";

        var parsed = FileHelper.TryParseFileType(fileName, out var fileType);

        parsed.Should().BeFalse();
        fileType.Should().BeNull();
    }
}