using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.Providers;

public class ProvidersService : BaseService<Provider>, IProvidersService
{
    //private readonly IBaseProviderService<Provider> _providersPorvider;

    //public ProvidersService(IBaseProviderService<Provider> providersPorvider)
    //{
    //    _providersPorvider = providersPorvider ?? throw new ArgumentNullException(nameof(providersPorvider));
    //}

    //public async Task<Provider> CreateEntityAsync(Provider item, CancellationToken token = default)
    //{
    //    return await _providersPorvider.CreateEntityAsync(item, token).ConfigureAwait(false);
    //}

    //public async Task<bool> DeleteEntityAsync(int id, CancellationToken token = default)
    //{
    //    return await _providersPorvider.DeleteEntityAsync(id, token).ConfigureAwait(false);
    //}

    //public async Task<List<Provider>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    //{
    //    return await _providersPorvider.GetEntitiesAsync(token).ConfigureAwait(false);
    //}

    //public async Task<Provider> GetEntityAsync(int id, CancellationToken token = default)
    //{
    //    return await _providersPorvider.GetEntityAsync(id, token).ConfigureAwait(false);
    //}

    //public async Task<Provider> UpdateEntityAsync(Provider item, CancellationToken token = default)
    //{
    //    return await _providersPorvider.UpdateEntityAsync(item, token).ConfigureAwait(false);
    //}
    public ProvidersService(IBaseProviderService<Provider> daoProvider) : base(daoProvider)
    {
    }
}
