using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;

namespace Presentation.Core.Syncfusion
{
    public class BaseOperationComparison
    {
        public static Expression GetMemberAccessLambda<T>(ParameterExpression arg, string itemField) where T : class
        {
            string[] listaPropiedades = itemField.Split('.');
            Expression expression = arg;

            Type tipoActual = typeof(T);

            foreach (string propiedad in listaPropiedades)
            {
                PropertyInfo propertyInfo = tipoActual.GetProperty(propiedad);

                if (propertyInfo.PropertyType == typeof(DateTime) ||
                    propertyInfo.PropertyType == typeof(DateTime?))
                {
                    var gmt = Expression.Convert(Expression.Constant(WebSession.Usuario.TimeZoneGMT), typeof(int?));
                    var date = Expression.Convert(Expression.MakeMemberAccess(expression, propertyInfo), typeof(DateTime?));
                    var addHoursMethod = typeof(DbFunctions).GetMethod("AddHours", new[] { typeof(DateTime?), typeof(int?) });

                    expression = Expression.Call(addHoursMethod, new Expression[] { date, gmt });
                }
                else
                {
                    expression = Expression.MakeMemberAccess(expression, propertyInfo);
                }

                tipoActual = propertyInfo.PropertyType;
            }

            return expression;
        }

        public static Expression GreaterThanOrEqualNullable(Expression e1, Expression e2)
        {
            if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                e2 = Expression.Convert(e2, e1.Type);
            else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                e1 = Expression.Convert(e1, e2.Type);

            return Expression.GreaterThanOrEqual(e1, e2);
        }

        public static Expression LowerThanOrEqualNullable(Expression e1, Expression e2)
        {
            if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                e2 = Expression.Convert(e2, e1.Type);
            else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                e1 = Expression.Convert(e1, e2.Type);

            return Expression.LessThanOrEqual(e1, e2);
        }

        public static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}