using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories;

namespace CnD.CommunalPayments.Server.Dao.Tests.InvoiceDaoTests;

public class BaseTests : BaseDaoTests<InvoiceEntity>
{
    protected IDao<InvoiceEntity> _dao;

    public BaseTests()
    {
        _dao = new InvoiceDao(_dbContextMock.Object);
    }
}
