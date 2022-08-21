using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.Tests.InvoiceDaoTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Tests.InvoiceServicesDaoTests;

public class CreateEntityAsyncTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {
        var entity = GetFixtureObject<InvoiceServicesEntity>();
        entity.Id = 0;

        var response = await _dao.CreateEntityAsync(entity, _cancel).ConfigureAwait(false);

        response.ShouldNotBeNull();
        //response.Id.ShouldBeGreaterThan(0);
    }
}

public class DeleteEntityAsyncTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {
        var id = 10;

        var response = await _dao.DeleteEntityAsync(id, _cancel).ConfigureAwait(false);

        response.ShouldBeTrue();
    }
}

public class GetEntitiesAsyncTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {

        var response = await _dao.GetEntitiesAsync(_cancel).ConfigureAwait(false);

        response.ShouldNotBeNull();
        //response.Count.ShouldBeGreaterThan(0);
    }
}

public class GetEntityAsyncTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {
        var id = 10;

        var response = await _dao.GetEntityAsync(id, _cancel).ConfigureAwait(false);

        response.ShouldNotBeNull();
        //response.Id.ShouldBe(id);
    }
}

public class UpdateEntityAsyncTests : BaseTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnResult()
    {
        var entity = GetFixtureObject<InvoiceServicesEntity>();
        entity.Id = 10;

        var response = await _dao.UpdateEntityAsync(entity, _cancel).ConfigureAwait(false);

        response.ShouldNotBeNull();
        //response.Id.ShouldBe(entity.Id);
    }
}
