using Infrastructure.CrossCutting.Enums;
using System;
using System.Linq.Expressions;

namespace Domain.Core.Pagination
{
    public class PaginationParameters<T> where T : class
    {
        public LambdaExpression ColumnOrder { get; set; }
        public TipoOrdenamiento OrderType { get; set; }
        public int Start { get; set; }
        public int AmountRows { get; set; }
        public Expression<Func<T, bool>> WhereFilter { get; set; }
    }
}
