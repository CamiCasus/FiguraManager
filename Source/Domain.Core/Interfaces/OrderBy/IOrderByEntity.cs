using Domain.Core.OrderBy;

namespace Domain.Core.Interfaces.OrderBy
{
    public interface IOrderByEntity<TEntity>
    {
        OrderByResponse GetOrderExpression(string propertyName);
    }
}