using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Tests.PeriodDaoTests;

public class BaseTests : BaseDaoTests<PeriodEntity>
{
    protected IDao<PeriodEntity> _dao;

    public BaseTests()
    {
        _dao = new PeriodDao();
    }
}