using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;
using System.Linq;

namespace CnD.CommunalPayments.Server.Services.BL.Invoices;

public class InvoiceService : IInvoiceService
{
    private readonly IBaseProviderService<Invoice> _invoicePorvider;

    public InvoiceService(IBaseProviderService<Invoice> invoicePorvider)
    {
        _invoicePorvider = invoicePorvider ?? throw new ArgumentNullException(nameof(invoicePorvider));
    }

    public async Task<List<Invoice>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    {
        var result = await _invoicePorvider.GetEntitiesAsync(token).ConfigureAwait(false);
        return result.ToList();
    }

    public async Task<Invoice> GetEntityAsync(int id, CancellationToken token = default)
    {
        return await _invoicePorvider.GetEntityAsync(id, token).ConfigureAwait(false);
    }

    public async Task<Invoice> CreateEntityAsync(Invoice item, CancellationToken token = default)
    {
        return await _invoicePorvider.CreateEntityAsync(item, token).ConfigureAwait(false);
    }

    public async Task<Invoice> UpdateEntityAsync(Invoice item, CancellationToken token = default)
    {
        return await _invoicePorvider.UpdateEntityAsync(item, token).ConfigureAwait(false);
    }

    public async Task<bool> DeleteEntityAsync(int id, CancellationToken token = default)
    {
        return await _invoicePorvider.DeleteEntityAsync(id, token).ConfigureAwait(false);
    }
}
