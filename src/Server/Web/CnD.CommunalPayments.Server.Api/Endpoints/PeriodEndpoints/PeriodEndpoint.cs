using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Periods.Request;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Periods;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.PeriodEndpoints;

public class PeriodEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPeriodService, PeriodService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/periods/get-periods", GetAll);
        app.MapGet("/api/periods/get-period/{id:int}", GetById);
        app.MapPost("/api/periods/create-period", CreateNew);
        app.MapPut("/api/periods/update-period", Update);
        app.MapDelete("/api/periods/delete-period/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<PeriodResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> GetAll([FromServices] IPeriodService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<PeriodResponse>> { Result = new List<PeriodResponse>() });

        var response = mapper.Map<List<PeriodResponse>>(result);

        return Results.Ok(new ResponseResult<List<PeriodResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<PeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> GetById([FromServices] IPeriodService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<PeriodResponse>(result);

        return Results.Ok(new ResponseResult<PeriodResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreatePeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> CreateNew([FromServices] IPeriodService service, [FromServices] IMapper mapper, [FromBody] CreatePeriodRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<Period>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreatePeriodResponse>(result);

        return Results.Ok(new ResponseResult<CreatePeriodResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdatePeriodResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> Update([FromServices] IPeriodService service, [FromServices] IMapper mapper, [FromBody] UpdatePeriodRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<Period>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdatePeriodResponse>(result);

        return Results.Ok(new ResponseResult<UpdatePeriodResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Periods")]
    private async Task<IResult> Delete([FromServices] IPeriodService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}
