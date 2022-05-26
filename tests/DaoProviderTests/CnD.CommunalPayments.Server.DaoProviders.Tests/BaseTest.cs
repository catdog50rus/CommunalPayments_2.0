using CnD.CommunalPayments.Server.Dao.Base;

namespace CnD.CommunalPayments.Server.DaoProviders.Tests;

public class BaseTest<TItem, TEntity> 
    where TEntity : class, new()
    where TItem : class, new()
{
    protected Mock<IMapper> _mapperMock = new();

    protected Mock<IDao<TEntity>> _daoMock = new();

    protected CancellationToken _cancel = new CancellationToken();

    protected Fixture _fixture = new();

    protected T GetFixtureObject<T>() => _fixture.Create<T>();

    protected void MapT(TItem result)
    {
        _mapperMock.
            Setup(x => x.Map<TItem>(It.IsAny<TEntity>()))
            .Returns(result)
            .Verifiable();
    }

    protected void MapListT(List<TItem> result)
    {
        _mapperMock.
            Setup(x => x.Map<List<TItem>>(It.IsAny<List<TEntity>>()))
            .Returns(result)
            .Verifiable();
    }

    protected void GetEntitiesAsync(List<TItem> result)
    {
        var entities = new List<TEntity> { new TEntity() };

        _daoMock
            .Setup(x => x.GetEntitiesAsync(_cancel).Result)
            .Returns(entities)
            .Verifiable();

        MapListT(result);
    }

    protected void GetEntityAsync(TItem result)
    {
        var entities = new TEntity();

        _daoMock
            .Setup(x => x.GetEntityAsync(It.IsAny<int>(), _cancel).Result)
            .Returns(entities)
            .Verifiable();

        MapT(result);
    }
}