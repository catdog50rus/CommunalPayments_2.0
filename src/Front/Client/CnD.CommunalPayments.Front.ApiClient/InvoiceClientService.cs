using AutoMapper;
using CnD.CommunalPayments.Contracts.Models;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using CnD.CommunalPayments.Front.ViewModels.Invoices;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace CnD.CommunalPayments.Front.ApiClient;

public class InvoiceClientService : BaseHttpClient, IInvoiceClientService
{
    private readonly IMapper _mapper;

    public InvoiceClientService(
        IMapper mapper,
        IOptionsMonitor<ServerOptions> options, 
        HttpClient httpClient) : base(options, httpClient)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync(PageSet page, CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/invoices/get-invoices?pageIndex={page.PageIndex}&pageSize={page.PageSize}";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync(cancel);

        var result = JsonConvert.DeserializeObject<ResponseResult<List<InvoiceResponse>>>(responseString);

        if (result!.IsSuccess)
            return _mapper.Map<IEnumerable<Invoice>>(result.Result);

        return null!;
    }

    public async Task<Invoice> CreateAsync(InvoiceViewModel viewModel, CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/invoices/create-invoice";

        var request = new CreateInvoiceRequest
        {
            PeriodId = int.Parse(viewModel.IdPeriod),
            ProviderId = int.Parse(viewModel.IdProvider),
            Sum = viewModel.InvoiceSum
        };

        using StringContent content = new(
            JsonConvert.SerializeObject(request),
            Encoding.UTF8,
            "application/json");

        var response = await CreateAsync(content, url, cancel);

        var responseString = await response.Content.ReadAsStringAsync(cancel);

        var result = JsonConvert.DeserializeObject<ResponseResult<List<CreateInvoiceResponse>>>(responseString);

        if (result!.IsSuccess)
            return _mapper.Map<Invoice>(result.Result);

        return null!;
    }
}

public interface IInvoiceClientService
{
    Task<IEnumerable<Invoice>> GetAllAsync(PageSet page, CancellationToken cancel = default);

    Task<Invoice> CreateAsync(InvoiceViewModel viewModel, CancellationToken cancel = default);
}