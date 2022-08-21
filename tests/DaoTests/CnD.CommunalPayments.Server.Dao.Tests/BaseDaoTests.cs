namespace CnD.CommunalPayments.Server.Dao.Tests;

public class BaseDaoTests<TEntity> where TEntity : class, new()
{
    protected CancellationToken _cancel = new();

    protected Fixture _fixture = new();

    protected T GetFixtureObject<T>() => _fixture.Create<T>();
}