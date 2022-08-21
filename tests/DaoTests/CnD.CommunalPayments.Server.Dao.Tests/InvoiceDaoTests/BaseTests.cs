using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Tests.InvoiceDaoTests;

public class BaseTests : BaseDaoTests<InvoiceEntity>
{
    protected IDao<InvoiceEntity> _dao;

    public BaseTests()
    {
        _dao = new InvoiceDao();
    }
}
