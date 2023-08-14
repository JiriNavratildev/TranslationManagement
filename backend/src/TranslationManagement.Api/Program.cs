using TranslationManagement.Application;
using TranslationManagement.Infrastructure;
using TranslationManagement.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p =>
    p.AddPolicy("enableAll", policy => { policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

ApplicationModule.ConfigureServices(builder.Services);
InfrastructureModule.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseCors("enableAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();