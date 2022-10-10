namespace CnD.CommunalPayments.Front.ApiClient.Base;

public interface IBaseHttpClient
{
    public Task<HttpResponseMessage> CreateAsync(HttpContent content, string url, CancellationToken cancel = default);

    public Task<HttpResponseMessage> UpdateAsync(HttpContent content, string url, CancellationToken cancel = default);

    public Task<HttpResponseMessage> GetAsync(string url, CancellationToken cancel = default);

    public Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancel = default);
}