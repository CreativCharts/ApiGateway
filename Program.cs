using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMLib.SwaggerForOcelot.DependencyInjection;
using MMLib.SwaggerForOcelot.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();


app.UseCors(builder => builder
    .WithOrigins("http://localhost:5173")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();
await app.UseOcelot();


app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
    opt.DownstreamSwaggerEndPointBasePath = "/swagger/docs";
    opt.ServerOcelot = "/";
}, swaggerUiOptions => { swaggerUiOptions.SwaggerEndpoint("/swagger/docs/v1/swagger.json", "My API V1"); });

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.Run();