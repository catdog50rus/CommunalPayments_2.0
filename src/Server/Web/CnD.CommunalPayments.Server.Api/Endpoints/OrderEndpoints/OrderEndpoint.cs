using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Orders.Request;
using CnD.CommunalPayments.Contracts.Models.Orders.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.OrderEndpoints;

public class OrderEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrdersService, OrdersService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/orders/get-all", GetAll);
        app.MapGet("/api/orders/get/{id:int}", GetById);
        app.MapPost("/api/orders/create", CreateNew);
        app.MapPut("/api/orders/update", Update);
        app.MapDelete("/api/orders/delete/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<OrderResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Orders")]
    private async Task<IResult> GetAll([FromServices] IOrdersService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<OrderResponse>> { Result = new List<OrderResponse>() });

        var response = mapper.Map<List<OrderResponse>>(result);

        return Results.Ok(new ResponseResult<List<OrderResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<OrderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Orders")]
    private async Task<IResult> GetById([FromServices] IOrdersService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<OrderResponse>(result);

        return Results.Ok(new ResponseResult<OrderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateOrderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Orders")]
    private async Task<IResult> CreateNew([FromServices] IOrdersService service, [FromServices] IMapper mapper, [FromBody] CreateOrderRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<Order>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateOrderResponse>(result);

        return Results.Ok(new ResponseResult<CreateOrderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateOrderResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Orders")]
    private async Task<IResult> Update([FromServices] IOrdersService service, [FromServices] IMapper mapper, [FromBody] UpdateOrderRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("Order пустой"));

        var item = mapper.Map<Order>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateOrderResponse>(result);

        return Results.Ok(new ResponseResult<UpdateOrderResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Orders")]
    private async Task<IResult> Delete([FromServices] IOrdersService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}