
using Microsoft.SemanticKernel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddKernel();
builder.Services.AddScoped<Kernel>();
builder.Services.AddOpenAIChatCompletion("gpt-4o", builder.Configuration["OpenAI:ApiKey"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();