using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using CnD.CommunalPayments.Front.ViewModels.Providers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CnD.CommunalPayments.Front.ApiClient;

public class ProviderClientService : BaseHttpClient, IProviderClientService
{
    private readonly IMapper _mapper;

    public ProviderClientService(IMapper mapper, IOptionsMonitor<ServerOptions> options, HttpClient httpClient) : base(options, httpClient)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<Provider>> GetAllAsync(CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/providers/get-all";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ResponseResult<List<ProviderResponse>>>(responseString);

        if (result!.IsSuccess)
            return _mapper.Map<IEnumerable<Provider>>(result.Result);

        return null!;
    }
}

public interface IProviderClientService
{
    Task<IEnumerable<Provider>> GetAllAsync(CancellationToken cancel = default);
}