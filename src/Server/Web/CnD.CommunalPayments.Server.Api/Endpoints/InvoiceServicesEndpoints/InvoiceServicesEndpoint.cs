using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.InvoiceServices.Request;
using CnD.CommunalPayments.Contracts.Models.InvoiceServices.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Server.Api.Endpoints.Base;
using CnD.CommunalPayments.Server.Api.Extensions;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using CnD.CommunalPayments.Server.Services.BL.InvoiceService;
using Microsoft.AspNetCore.Mvc;

namespace CnD.CommunalPayments.Server.Api.Endpoints.InvoiceServicesEndpoints;

public class InvoiceServicesEndpoint : EndpointDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInvoiceServicesService, InvoiceServicesService>();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/api/invoiceServices/get-all", GetAll);
        app.MapGet("/api/invoiceServices/get/{id:int}", GetById);
        app.MapPost("/api/invoiceServices/create", CreateNew);
        app.MapPut("/api/invoiceServices/update", Update);
        app.MapDelete("/api/invoiceServices/delete/{id:int}", Delete);
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<List<InvoiceServicesResponse>>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("InvoiceServices")]
    private async Task<IResult> GetAll([FromServices] IInvoiceServicesService service, [FromServices] IMapper mapper, HttpContext context)
    {
        var pagedListQueryParams = context.Request.Query.ParseToPages();

        var result = await service.GetAllAsync(pagedListQueryParams, context.RequestAborted);

        if (result is null || !result.Any())
            return Results.Ok(new ResponseResult<List<InvoiceServicesResponse>> { Result = new List<InvoiceServicesResponse>() });

        var response = mapper.Map<List<InvoiceServicesResponse>>(result);

        return Results.Ok(new ResponseResult<List<InvoiceServicesResponse>> { Result = response });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<InvoiceServicesResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("InvoiceServices")]
    private async Task<IResult> GetById([FromServices] IInvoiceServicesService service, [FromServices] IMapper mapper, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.GetEntityAsync(id);

        if (result is null)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        var response = mapper.Map<InvoiceServicesResponse>(result);

        return Results.Ok(new ResponseResult<InvoiceServicesResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<CreateInvoiceServicesResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("InvoiceServices")]
    private async Task<IResult> CreateNew([FromServices] IInvoiceServicesService service, [FromServices] IMapper mapper, [FromBody] CreateInvoiceServicesRequest newItem)
    {
        if (newItem is null)
            return Results.Ok(ErrorResponseResult("Period пустой"));

        var item = mapper.Map<InvoiceServices>(newItem);

        var result = await service.CreateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка создания"));

        var response = mapper.Map<CreateInvoiceServicesResponse>(result);

        return Results.Ok(new ResponseResult<CreateInvoiceServicesResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult<UpdateInvoiceServicesResponse>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("InvoiceServices")]
    private async Task<IResult> Update([FromServices] IInvoiceServicesService service, [FromServices] IMapper mapper, [FromBody] UpdateInvoiceServicesRequest updateItem)
    {
        if (updateItem is null)
            return Results.Ok(ErrorResponseResult("InvoiceService пустой"));

        var item = mapper.Map<InvoiceServices>(updateItem);

        var result = await service.UpdateEntityAsync(item);

        if (result is null)
            return Results.Ok(ErrorResponseResult("Ошибка редактирования"));

        var response = mapper.Map<UpdateInvoiceServicesResponse>(result);

        return Results.Ok(new ResponseResult<UpdateInvoiceServicesResponse>
        {
            Result = response
        });
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ResponseResult), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(ResponseResult), 500)]
    // [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
    [FeatureGroupName("InvoiceServices")]
    private async Task<IResult> Delete([FromServices] IInvoiceServicesService service, int id)
    {
        if (id <= 0)
            return Results.Ok(ErrorResponseResult($"Не валидный ID: {id}"));

        var result = await service.DeleteEntityAsync(id);

        if (!result)
            return Results.Ok(ErrorResponseResult($"Запись с ID: {id} не найдена"));

        return Results.Ok(new ResponseResult());
    }
}