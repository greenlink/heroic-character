using Greenlink.HeroicCharacter.Api;
using Greenlink.HeroicCharacter.Api.Data;
using Greenlink.HeroicCharacter.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IOpenAiCharacterService, OpenAiCharacterService>();
builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi("Heroic Character API");

const string corsPolicyName = "AllowAngular";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var openAiApiKey = builder.Configuration.GetSection("OpenAI:ApiKey").Value;

if (string.IsNullOrWhiteSpace(openAiApiKey))
    throw new Exception("OpenAI__ApiKey environment variable is not set.");

var app = builder.Build();

app.UseExceptionHandler("/*");

app.UseCors(corsPolicyName);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
