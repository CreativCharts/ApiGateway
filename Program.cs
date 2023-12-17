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
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .WithOrigins("http://localhost:5173")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();

await app.UseOcelot();


app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs"; //swagger endpoint for upstream services
    opt.DownstreamSwaggerEndPointBasePath = "/swagger/docs"; //swagger endpoint for downstream services
    opt.ServerOcelot = "/";
}, swaggerUiOptions => {
 swaggerUiOptions.SwaggerEndpoint(
 "/swagger/docs/v1/swagger.json", "My API V1");
  }); //swagger endpoint for ocelot itself

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.Run();
