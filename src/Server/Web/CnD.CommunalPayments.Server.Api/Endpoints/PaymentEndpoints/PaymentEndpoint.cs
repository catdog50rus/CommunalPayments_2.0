using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Payments.Request;
using CnD.CommunalPayments.Contracts.Models.Payments.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Payments;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.PaymentEndpoints;

public class PaymentEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPaymentsService, PaymentsService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/payments/get-payments", GetAll);
        app.MapGet("/api/payments/get-payment/{id:int}", GetById);
        app.MapPost("/api/payments/create-payment", CreateNew);
        app.MapPut("/api/payments/update-payment", Update);
        app.MapDelete("/api/payments/delete-payment/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<PaymentResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Payments")]
    private async Task<IResult> GetAll([FromServices] IPaymentsService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<PaymentResponse>> { Result = new List<PaymentResponse>() });

        var response = mapper.Map<List<PaymentResponse>>(result);

        return Results.Ok(new ResponseResult<List<PaymentResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<PaymentResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Payments")]
    private async Task<IResult> GetById([FromServices] IPaymentsService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<PaymentResponse>(result);

        return Results.Ok(new ResponseResult<PaymentResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreatePaymentResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Payments")]
    private async Task<IResult> CreateNew([FromServices] IPaymentsService service, [FromServices] IMapper mapper, [FromBody] CreatePaymentRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Payment пустой"));

        var item = mapper.Map<Payment>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreatePaymentResponse>(result);

        return Results.Ok(new ResponseResult<CreatePaymentResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdatePaymentResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Payments")]
    private async Task<IResult> Update([FromServices] IPaymentsService service, [FromServices] IMapper mapper, [FromBody] UpdatePaymentRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("Payment пустой"));

        var item = mapper.Map<Payment>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdatePaymentResponse>(result);

        return Results.Ok(new ResponseResult<UpdatePaymentResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Payments")]
    private async Task<IResult> Delete([FromServices] IPaymentsService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}