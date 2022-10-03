using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Services.BL.Interfaces;

public interface IInvoiceService
{
    Task<List<Invoice>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

    Task<Invoice> GetEntityAsync(int id, CancellationToken token = default);

    Task<Invoice> CreateEntityAsync(Invoice item, CancellationToken token = default);

    Task<Invoice> UpdateEntityAsync(Invoice item, CancellationToken token = default);

    Task<bool> DeleteEntityAsync(int id, CancellationToken token = default);
}
