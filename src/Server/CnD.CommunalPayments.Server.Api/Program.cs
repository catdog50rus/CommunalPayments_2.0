using CnD.CommunalPayments.Server.Api.Definitions.Base;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;

try
{
    // configure logger (NLog)

    // created builder
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddAppDefinitions(builder, typeof(Program));
    builder.Services.AddAppEndpoints(builder, typeof(Program));

    // create application
    var app = builder.Build();

    app.UseAppDefinitions();
    app.UseAppEndpoints();

    // start application
    app.Run();

    return 0;
}
catch (Exception ex)
{
    return 1;
}
finally
{
}