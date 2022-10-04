using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models.Base;

namespace CnD.CommunalPayments.Server.Services.BL.Base;

public interface IBaseService<TModel> where TModel : IDomenModel
{
    Task<List<TModel>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

    Task<TModel> GetEntityAsync(int id, CancellationToken token = default);

    Task<TModel> CreateEntityAsync(TModel item, CancellationToken token = default);

    Task<TModel> UpdateEntityAsync(TModel item, CancellationToken token = default);

    Task<bool> DeleteEntityAsync(int id, CancellationToken token = default);
}