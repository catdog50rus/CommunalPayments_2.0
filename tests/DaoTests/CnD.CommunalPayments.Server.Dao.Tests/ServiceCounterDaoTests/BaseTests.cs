using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Tests.ServiceCounterDaoTests;

public class BaseTests : BaseDaoTests<ServiceCounterEntity>
{
    protected IDao<ServiceCounterEntity> _dao;

    public BaseTests()
    {
        _dao = new ServiceCounterDao(_dbContextMock.Object);
    }
}