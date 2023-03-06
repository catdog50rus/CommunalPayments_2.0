using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Response;
using CnD.CommunalPayments.Front.ApiClient.Base;
using CnD.CommunalPayments.Front.Configure.ServerOptions;
using CnD.CommunalPayments.Front.ViewModels.Periods;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CnD.CommunalPayments.Front.ApiClient;

public class PeriodClientService : BaseHttpClient, IPeriodClientService
{
    private readonly IMapper _mapper;

    public PeriodClientService(IMapper mapper, IOptionsMonitor<ServerOptions> options, HttpClient httpClient) : base(options, httpClient)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<Period>> GetAllAsync(CancellationToken cancel = default)
    {
        var url = $"{_options.BasePath}/{_options.ApiPath}/periods/get-periods";
        var response = await GetAsync(url, cancel);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ResponseResult<List<PeriodResponse>>>(responseString);

        if (result!.IsSuccess)
            return _mapper.Map<IEnumerable<Period>>(result.Result);

        return null!;
    }
}

public interface IPeriodClientService
{
    Task<IEnumerable<Period>> GetAllAsync(CancellationToken cancel = default);
}