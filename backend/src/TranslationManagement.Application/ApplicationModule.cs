using Microsoft.Extensions.DependencyInjection;
using TranslationManagement.Application.Files;
using TranslationManagement.Application.TranslationJobs;
using TranslationManagement.Application.Translators;

namespace TranslationManagement.Application;

public abstract class ApplicationModule
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ITranslatorService, TranslatorService>();
        services.AddScoped<ITranslationJobService, TranslationJobService>();
        services.AddSingleton<IFileParserContext, FileParserContext>();
    }
}