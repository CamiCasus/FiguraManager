﻿using System.Linq.Expressions;

namespace Presentation.Core.Syncfusion.OperationsComparison
{
    public class EqualsOperationComparison : BaseOperationComparison, IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
          where T : class
        {
            return Expression.Equal(GetMemberAccessLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}