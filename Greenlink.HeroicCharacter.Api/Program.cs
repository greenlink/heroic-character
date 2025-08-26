using Greenlink.HeroicCharacter.Api.Data;
using Greenlink.HeroicCharacter.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IOpenAiCharacterService, OpenAiCharacterService>();
builder.Services.AddControllers();
//Add OpenAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi("Heroic Character API");

// Configure CORS
const string corsPolicyName = "AllowAngular";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular dev server
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Use CORS
app.UseCors(corsPolicyName);

// Enable OpenAPI docs in Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); //Use OpenApi
}

// Map controllers
app.MapControllers();

app.Run();
