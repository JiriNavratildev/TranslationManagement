using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranslationManagement.Application.Notifications;
using TranslationManagement.Application.UnitOfWork;
using TranslationManagement.Domain.Common;
using TranslationManagement.Domain.TranslationJobs;
using TranslationManagement.Domain.Translators;
using TranslationManagement.Infrastructure.Database;
using TranslationManagement.Infrastructure.Database.UnitOfWork;
using TranslationManagement.Infrastructure.Domain.TranslationJobs;
using TranslationManagement.Infrastructure.Domain.Translators;
using TranslationManagement.Infrastructure.Notifications;

namespace TranslationManagement.Infrastructure;

public abstract class InfrastructureModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<INotificationService, UNSNotificationService>();
        services.AddScoped<ITranslationJobRepository, TranslationJobRepository>();
        services.AddScoped<ITranslatorRepository, TranslatorRepository>();
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("Default")));
        services.AddScoped<INotificationService, UNSNotificationService>();
    }
}