﻿using System.Linq.Expressions;

namespace Presentation.Core.Syncfusion.OperationsComparison
{
    public class LowerThanOperationComparison : BaseOperationComparison, IOperationComparison
    {
        public Expression GetOperationComparison<T>(ParameterExpression parameterExpression, string itemField, Expression expressionValue)
           where T : class
        {
            return LowerThanOrEqualNullable(GetMemberAccessLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}