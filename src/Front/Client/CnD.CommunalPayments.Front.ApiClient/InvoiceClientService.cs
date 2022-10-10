using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CnD.CommunalPayments.Front.ApiClient;

public class InvoiceClientService : BaseHttpClient, IInvoiceClientService
{
    public InvoiceClientService(IOptionsMonitor<ServerOptions> options, HttpClient httpClient) : base(options, httpClient)
    {
    }

    public async Task<IEnumerable<InvoiceResponse>> GetAllAsync(CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/invoices/get-invoices";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync(cancel);

        var result = JsonConvert.DeserializeObject<ResponseResult<List<InvoiceResponse>>>(responseString);

        return result!.IsSuccess ? result.Result : null!;
    }
}

public interface IInvoiceClientService
{
    Task<IEnumerable<InvoiceResponse>> GetAllAsync(CancellationToken cancel = default);
}