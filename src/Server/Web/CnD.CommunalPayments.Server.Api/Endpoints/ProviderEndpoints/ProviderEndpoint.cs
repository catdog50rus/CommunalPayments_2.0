using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Providers.Request;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Providers;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.ProviderEndpoints;

public class ProviderEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProvidersService, ProvidersService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/providers/get-all", GetAll);
        app.MapGet("/api/providers/get/{id:int}", GetById);
        app.MapPost("/api/providers/create", CreateNew);
        app.MapPut("/api/providers/update", Update);
        app.MapDelete("/api/providers/delete/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<ProviderResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> GetAll([FromServices] IProvidersService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<ProviderResponse>> { Result = new List<ProviderResponse>() });

        var response = mapper.Map<List<ProviderResponse>>(result);

        return Results.Ok(new ResponseResult<List<ProviderResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<ProviderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> GetById([FromServices] IProvidersService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<ProviderResponse>(result);

        return Results.Ok(new ResponseResult<ProviderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateProviderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> CreateNew([FromServices] IProvidersService service, [FromServices] IMapper mapper, [FromBody] CreateProviderRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<Provider>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateProviderResponse>(result);

        return Results.Ok(new ResponseResult<CreateProviderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateProviderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> Update([FromServices] IProvidersService service, [FromServices] IMapper mapper, [FromBody] UpdateProviderRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("Provider пустой"));

        var item = mapper.Map<Provider>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateProviderResponse>(result);

        return Results.Ok(new ResponseResult<UpdateProviderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Providers")]
    private async Task<IResult> Delete([FromServices] IProvidersService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}
