using Microsoft.OpenApi.Models;
using service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<ExternalApiService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Exchange",
        Version = "v1",
        Description = "Endpoints de consulta da web api Exchange Rate, api que consome e faz as conversões de moedas"
    });

    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Exchange",
        Version = "v2",
        Description = "Endpoints de consulta da web api Exchange Rate, api que consome e faz as conversões de moedas"
    });

   
}
);

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
       app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Minha API v2");

        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
    });

     app.UseAuthentication();
    app.UseAuthorization();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();

 