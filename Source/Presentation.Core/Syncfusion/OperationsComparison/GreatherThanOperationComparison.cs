using System.Linq.Expressions;

namespace Presentation.Core.Syncfusion.OperationsComparison
{
    public class GreatherThanOperationComparison : BaseOperationComparison, IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
           where T : class
        {
            return GreaterThanOrEqualNullable(GetMemberAccessLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}