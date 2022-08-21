using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.DaoProviders.Tests.InvoiceDaoProviderTests;

public class GetEntitiesAsyncTests : BaseInvoiceDaoProviderTests
{
    [Fact]
    public async Task Scenario_01_ShouldReturnEmptyResult()
    {
        //average
        //act
        var result = await _daoProvider.GetEntitiesAsync();

        //assert
        result.ShouldNotBeNull();
        result.ShouldBeEmpty();
    }

    [Fact]
    public async Task Scenario_02_ShouldReturnResult()
    {
        //average
        var invoice = GetFixtureObject<Invoice>();

        GetEntitiesAsync(new List<Invoice> { invoice });

        //act
        var result = await _daoProvider.GetEntitiesAsync();

        //assert
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.First().Id.ShouldBe(invoice.Id);
        result.First().IsPaid.ShouldBe(invoice.IsPaid);
        result.First().Sum.ShouldBe(invoice.Sum);
        result.First().Period.ShouldBe(invoice.Period);
        result.First().Provider.ShouldBe(invoice.Provider);
    }
}
