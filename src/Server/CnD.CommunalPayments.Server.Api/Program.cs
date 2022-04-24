using CnD.CommunalPayments.Server.Api.Definitions.Base;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using NLog;
using NLog.Web;

// configure logger (NLog)
var logger = LogManager
    .Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{   
    // created builder
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseNLog();

    var env = builder.Environment.EnvironmentName;

    builder.Services.AddAppDefinitions(builder, typeof(Program));
    builder.Services.AddAppEndpoints(builder, typeof(Program));

    // create application
    var app = builder.Build();

    app.UseAppDefinitions();
    app.UseAppEndpoints();

    logger.Debug("API Starting...");
    logger.Debug($"Enviromet: {env}");

    // start application
    app.Run();

    return 0;
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    return 1;
}
finally
{

}