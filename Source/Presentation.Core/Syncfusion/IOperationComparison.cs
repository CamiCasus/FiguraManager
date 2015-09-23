using System.Linq.Expressions;

namespace Presentation.Core.Syncfusion
{
    public interface IOperationComparison
    {
        Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
            where T : class;
    }
}