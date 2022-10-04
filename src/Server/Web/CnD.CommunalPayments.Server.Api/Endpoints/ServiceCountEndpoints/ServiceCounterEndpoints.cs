using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CnD.CommunalPayments.Server.Api;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Contracts.Models.ServiceCounters.Response;
using CnD.CommunalPayments.Contracts.Models.ServiceCounters.Request;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.ServiceCounters;

namespace CnD.CommunalServiceCounters.Server.Api.Endpoints.ServiceCountEndpoints;

public class ServiceCounterEndpoints: EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IServiceCountersService, ServiceCountersService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/serviceCounters/get-serviceCounters", GetAll);
        app.MapGet("/api/serviceCounters/get-serviceCounter/{id:int}", GetById);
        app.MapPost("/api/serviceCounters/create-serviceCounter", CreateNew);
        app.MapPut("/api/serviceCounters/update-serviceCounter", Update);
        app.MapDelete("/api/serviceCounters/delete-serviceCounter/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<ServiceCounterResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("ServiceCounters")]
    private async Task<IResult> GetAll([FromServices] IServiceCountersService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<ServiceCounterResponse>> { Result = new List<ServiceCounterResponse>() });

        var response = mapper.Map<List<ServiceCounterResponse>>(result);

        return Results.Ok(new ResponseResult<List<ServiceCounterResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<ServiceCounterResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("ServiceCounters")]
    private async Task<IResult> GetById([FromServices] IServiceCountersService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<ServiceCounterResponse>(result);

        return Results.Ok(new ResponseResult<ServiceCounterResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateServiceCounterResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("ServiceCounters")]
    private async Task<IResult> CreateNew([FromServices] IServiceCountersService service, [FromServices] IMapper mapper, [FromBody] CreateServiceCounterRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("ServiceCounter пустой"));

        var item = mapper.Map<ServiceCounter>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateServiceCounterResponse>(result);

        return Results.Ok(new ResponseResult<CreateServiceCounterResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateServiceCounterResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("ServiceCounters")]
    private async Task<IResult> Update([FromServices] IServiceCountersService service, [FromServices] IMapper mapper, [FromBody] UpdateServiceCounterRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("ServiceCounter пустой"));

        var item = mapper.Map<ServiceCounter>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateServiceCounterResponse>(result);

        return Results.Ok(new ResponseResult<UpdateServiceCounterResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("ServiceCounters")]
    private async Task<IResult> Delete([FromServices] IServiceCountersService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}