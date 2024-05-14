using System.Reflection;
using Tetra.Application.Common.Mappings;
using Tetra.Application;
using Tetra.Persistence;
using Tetra.WebApi.Middleware;
using Tetra.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IRequestsDbContext).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(cfg =>
{
    cfg.RoutePrefix = string.Empty;
    cfg.SwaggerEndpoint("swagger/v1/swagger.json", "Tetra API");
});

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var servicesProvider = scope.ServiceProvider;

    try
    {
        var context = servicesProvider.GetRequiredService<ApplicationDbContext>();

        DbInitializer.Initialize(context);
    }
    catch(Exception ex)
    {

    }
}

app.Run();
