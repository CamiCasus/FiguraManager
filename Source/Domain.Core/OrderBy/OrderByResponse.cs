using System.Linq.Expressions;
using Infrastructure.CrossCutting.Enums;

namespace Domain.Core.OrderBy
{
    public class OrderByResponse
    {
        public LambdaExpression LambdaExpression { get; set; }
        public TipoOrdenamiento? TipoOrdenamiento { get; set; }
    }
}