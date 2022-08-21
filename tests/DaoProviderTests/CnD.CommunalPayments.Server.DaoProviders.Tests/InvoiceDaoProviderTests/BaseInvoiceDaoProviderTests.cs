using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.DaoProviders.IMPL;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.DaoProviders.Tests.InvoiceDaoProviderTests;

public class BaseInvoiceDaoProviderTests : BaseTest<Invoice, InvoiceEntity>
{
    protected IBaseProviderService<Invoice> _daoProvider;

    public BaseInvoiceDaoProviderTests()
    {
        _daoProvider = new InvoiceDaoProvider (_mapperMock.Object, _daoMock.Object);
    }
}