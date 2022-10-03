using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.InvoiceEndpoints;

public class InvoceEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInvoiceService, InvoiceService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/invoices/get-invoices", GetAll);
        app.MapGet("/api/invoices/get-invoice/{id:int}", GetById);
        app.MapPost("/api/invoices/create-invoice", CreateNew);
        app.MapPut("/api/invoices/update-invoice", Update);
        app.MapDelete("/api/invoices/delete-invoice/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<InvoiceResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> GetAll([FromServices] IInvoiceService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if(result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<InvoiceResponse>> { Result = new List<InvoiceResponse>() });

        var response = mapper.Map<List<InvoiceResponse>>(result);

        return Results.Ok(new ResponseResult<List<InvoiceResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<InvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> GetById([FromServices] IInvoiceService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<InvoiceResponse>(result);

        return Results.Ok(new ResponseResult<InvoiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateInvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> CreateNew([FromServices] IInvoiceService service, [FromServices] IMapper mapper, [FromBody] CreateInvoiceRequest newInvoice)
    {
        if (newInvoice is null)
            return Results.Ok(ErrorResponseResult("Invoice пустой"));
        
        var invoice = mapper.Map<Invoice>(newInvoice);

        var result = await service.CreateEntityAsync(invoice);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateInvoiceResponse>(result);

        return Results.Ok( new ResponseResult<CreateInvoiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateInvoiceResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> Update([FromServices] IInvoiceService service, [FromServices] IMapper mapper, [FromBody] UpdateInvoiceRequest updateInvoice)
    {
        if(updateInvoice is null)
            return Results.Ok(ErrorResponseResult("Invoice пустой"));

        var invoice = mapper.Map<Invoice>(updateInvoice);

        var result = await service.UpdateEntityAsync(invoice);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateInvoiceResponse>(result);

        return Results.Ok( new ResponseResult<UpdateInvoiceResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("Invoices")]
    private async Task<IResult> Delete([FromServices] IInvoiceService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}