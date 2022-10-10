using CnD.CommunalPayments.Front.Configure.ServerOptions;
using Microsoft.Extensions.Options;

namespace CnD.CommunalPayments.Front.ApiClient.Base;

public abstract class BaseHttpClient : IBaseHttpClient
{
    protected readonly ServerOptions _options;
    readonly HttpClient _httpClient;

	public BaseHttpClient(IOptionsMonitor<ServerOptions> options, HttpClient httpClient)
	{
        _options = options.CurrentValue ?? throw new ArgumentNullException(nameof(options));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<HttpResponseMessage> CreateAsync(HttpContent content, string url, CancellationToken cancel = default) => await _httpClient.PostAsync(url, content, cancel);


    public async Task<HttpResponseMessage> UpdateAsync(HttpContent content, string url, CancellationToken cancel = default) => await _httpClient.PutAsync(url, content, cancel);


    public async Task<HttpResponseMessage> GetAsync(string url, CancellationToken cancel = default) => await _httpClient.GetAsync(url, cancel);


    public async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancel = default) => await _httpClient.DeleteAsync(url, cancel);
}
