using calculo_cdb.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cálculo CDB - Teste B3",
        Version = "v1",
        Description = "",
        Contact = new OpenApiContact
        {
            Name = "Nicolas Pereira",
            Url = new Uri("https://www.linkedin.com/in/nasp/")
        },
    });

    var xmlFilenameSummary = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameSummary));
});


builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option => option.AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
