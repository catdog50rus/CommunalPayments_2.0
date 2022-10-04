using NLog;
using NLog.Web;
using CnD.CommunalPayments.Front.UI.BlazorUI.AppConfig;

var logger = LogManager
    .Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    var configuration = builder.Configuration;


    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    builder.Services.AddApplicationOptions(configuration);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{

}