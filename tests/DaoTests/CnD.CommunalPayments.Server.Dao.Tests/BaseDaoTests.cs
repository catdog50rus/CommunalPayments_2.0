using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CnD.CommunalPayments.Server.Dao.Tests;

public class BaseDaoTests<TEntity> where TEntity : class, new()
{
    protected Mock<CommunalPaymentsDbContext> _dbContextMock = new();

    protected CancellationToken _cancel = new();

    protected Fixture _fixture = new();

    protected T GetFixtureObject<T>() => _fixture.Create<T>();
}