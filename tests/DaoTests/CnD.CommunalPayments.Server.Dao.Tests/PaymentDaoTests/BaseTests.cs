﻿using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Tests.PaymentDaoTests;

public class BaseTests : BaseDaoTests<PaymentEntity>
{
    protected IDao<PaymentEntity> _dao;

    public BaseTests()
    {
        _dao = new PaymentDao(_dbContextMock.Object);
    }
}