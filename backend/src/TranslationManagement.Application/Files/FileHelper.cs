namespace TranslationManagement.Application.Files;

public class FileHelper
{
    public static bool TryParseFileType(string fileName, out FileType? fileType)
    {
        fileType = null;
        var fileExtension = Path.GetExtension(fileName);

        switch (fileExtension.ToUpper())
        {
            case ".TXT":
                fileType = FileType.TXT;
                return true;
            case ".XML":
                fileType = FileType.XML;
                return true;
            default:
                return false;
        }
    }
}