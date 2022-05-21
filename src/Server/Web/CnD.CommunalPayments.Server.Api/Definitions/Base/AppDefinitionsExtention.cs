namespace CnD.CommunalPayments.Server.Api.Definitions.Base;

public static class AppDefinitionsExtention
{
    public static void AddAppDefinitions(this IServiceCollection source, WebApplicationBuilder builder, params Type[] entryPointsAssembly)
    {
        var definitions = new List<IAppDefinitions>();

        foreach (var entryPoint in entryPointsAssembly)
        {
            var types = entryPoint.Assembly.ExportedTypes.Where(x => !x.IsAbstract && typeof(IAppDefinitions).IsAssignableFrom(x));
            var instances = types.Select(Activator.CreateInstance).Cast<IAppDefinitions>();
            definitions.AddRange(instances);
        }

        definitions.ForEach(service => service.ConfigureServices(source, builder.Configuration));
        source.AddSingleton(definitions as IReadOnlyCollection<IAppDefinitions>);
    }

    public static void UseAppDefinitions(this WebApplication source)
    {
        var definitions = source.Services.GetRequiredService<IReadOnlyCollection<IAppDefinitions>>();
        var environment = source.Services.GetRequiredService<IWebHostEnvironment>();

        foreach (var endpoint in definitions)
        {
            endpoint.ConfigureApplication(source, environment);
        }
    }
}
