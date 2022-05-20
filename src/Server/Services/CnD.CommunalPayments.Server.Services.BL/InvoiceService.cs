using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Services.BL
{
    public class InvoiceService : IInvoiceService
    {
        public InvoiceService()
        {

        }

        public async Task<List<Invoice>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
        {
            return await Task.Run(() => new List<Invoice>() { new Invoice() }, token).ConfigureAwait(false);
        }

        public async Task<Invoice> GetEntityAsync(int id, CancellationToken token = default)
        {
            return await Task.Run(() => new Invoice(), token).ConfigureAwait(false);
        }

        public async Task<Invoice> CreateEntityAsync(Invoice item, CancellationToken token = default)
        {
            return await Task.Run(() => new Invoice(), token).ConfigureAwait(false);
        }

        public async Task<Invoice> UpdateEntityAsync(Invoice item, CancellationToken token = default)
        {
            return await Task.Run(() => new Invoice(), token).ConfigureAwait(false);
        }

        public async Task<Invoice> DeleteEntityAsync(int id, CancellationToken token = default)
        {
            return await Task.Run(() => new Invoice(), token).ConfigureAwait(false);
        }
    }

    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

        Task<Invoice> GetEntityAsync(int id, CancellationToken token = default);

        Task<Invoice> CreateEntityAsync(Invoice item, CancellationToken token = default);

        Task<Invoice> UpdateEntityAsync(Invoice item, CancellationToken token = default);

        Task<Invoice> DeleteEntityAsync(int id, CancellationToken token = default);
    }
}