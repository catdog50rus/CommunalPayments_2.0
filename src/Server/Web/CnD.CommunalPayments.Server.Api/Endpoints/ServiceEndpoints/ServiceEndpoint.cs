using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Services.Request;
using CnD.CommunalPayments.Contracts.Models.Services.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.ServiceEndpoints;

public class ServiceEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IServicesService, ServicesService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/services/get-all", GetAll);
        app.MapGet("/api/services/get/{id:int}", GetById);
        app.MapPost("/api/services/create", CreateNew);
        app.MapPut("/api/services/update", Update);
        app.MapDelete("/api/services/delete/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<ServiceResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Services")]
    private async Task<IResult> GetAll([FromServices] IServicesService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<ServiceResponse>> { Result = new List<ServiceResponse>() });

        var response = mapper.Map<List<ServiceResponse>>(result);

        return Results.Ok(new ResponseResult<List<ServiceResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<ServiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Services")]
    private async Task<IResult> GetById([FromServices] IServicesService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<ServiceResponse>(result);

        return Results.Ok(new ResponseResult<ServiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateServiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Services")]
    private async Task<IResult> CreateNew([FromServices] IServicesService service, [FromServices] IMapper mapper, [FromBody] CreateServicesRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<Service>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateServiceResponse>(result);

        return Results.Ok(new ResponseResult<CreateServiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateServiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Services")]
    private async Task<IResult> Update([FromServices] IServicesService service, [FromServices] IMapper mapper, [FromBody] UpdateServiceRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("Service пустой"));

        var item = mapper.Map<Service>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateServiceResponse>(result);

        return Results.Ok(new ResponseResult<UpdateServiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Services")]
    private async Task<IResult> Delete([FromServices] IServicesService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}