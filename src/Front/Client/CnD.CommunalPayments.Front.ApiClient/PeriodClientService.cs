using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Front.ApiClient;

public class PeriodClientService : BaseHttpClient, IPeriodClientService
{
    public PeriodClientService(IOptionsMonitor<ServerOptions> options, HttpClient httpClient) : base(options, httpClient)
    {
    }

    public async Task<IEnumerable<PeriodResponse>> GetAllAsync(CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/periods/get-periods";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ResponseResult<List<PeriodResponse>>>(responseString);

        if (result.IsSuccess)
            return result.Result;

        return null;
    }
}

public interface IPeriodClientService
{
    Task<IEnumerable<PeriodResponse>> GetAllAsync(CancellationToken cancel = default);
}