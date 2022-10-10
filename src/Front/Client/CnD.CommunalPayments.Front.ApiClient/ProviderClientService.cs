using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CnD.CommunalPayments.Front.ApiClient;

public class ProviderClientService : BaseHttpClient, IProviderClientService
{
    public ProviderClientService(IOptionsMonitor<ServerOptions> options, HttpClient httpClient) : base(options, httpClient)
    {
    }

    public async Task<IEnumerable<ProviderResponse>> GetAllAsync(CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/providers/get-all";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ResponseResult<List<ProviderResponse>>>(responseString);

        if (result.IsSuccess)
            return result.Result;

        return null;
    }
}

public interface IProviderClientService
{
    Task<IEnumerable<ProviderResponse>> GetAllAsync(CancellationToken cancel = default);
}