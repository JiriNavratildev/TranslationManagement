using Microsoft.EntityFrameworkCore;
using TranslationManagerClean.Domain.TranslationJobs;
using TranslationManagerClean.Domain.Translators;

namespace TranslationManagement.Infrastructure.Database;

// dotnet ef migrations add Init -o Database/Migrations --startup-project ../TranslationManagement.Api
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
    {
        
    }
    
    public DbSet<TranslationJob> TranslationJobs => Set<TranslationJob>();
    public DbSet<Translator> Translators => Set<Translator>();
}