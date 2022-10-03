using CnD.CommunalPayments.Contracts.Models.Response;

namespace CnD.CommunalPayments.Server.Api.Endpoints.Base;

/// <summary>
/// Microservice endpoint interface implementation
/// </summary>
public abstract class EndpointDefinition : IEndpointDefinition
{
    /// <summary>
    /// Microservice configuration setup
    /// </summary>
    /// <param name="app"></param>
    public virtual void ConfigureApplication(WebApplication app) { }


    /// <summary>
    /// Microservice dependency injection configuration setup
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }

    protected virtual ResponseResult ErrorResponseResult(string message)
    {
        return new ResponseResult
        {
            ErrorCode = 1,
            ErrorMessage = message,
        };
    }
}