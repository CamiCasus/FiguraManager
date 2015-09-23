using System.Linq.Expressions;
using System.Reflection;

namespace Presentation.Core.Syncfusion.OperationsComparison
{
    public class EndsWithOperationComparison : BaseOperationComparison, IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
           where T : class
        {
            MethodInfo miBeginWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            return Expression.Call(GetMemberAccessLambda<T>(parameterExpression, itemField), miBeginWith, expressionValue);
        }
    }
}