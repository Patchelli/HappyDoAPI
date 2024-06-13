using HappyDo.API.Settings.Handlers;
using HappyDo.API.Settings;
using HappyDo.ApplicationService.AutoMapperSettings.Settings;
using HappyDo.IoC;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

AutoMapperFactoryConfiguration.Initialize();

builder.Services.AddSignalR();
builder.Services.AddDependencyInjectionHandler(configuration);
builder.Services.AddSettingsConfigurations();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DfPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.Run();
