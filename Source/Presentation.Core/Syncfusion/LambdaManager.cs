using Application.Core;
using Infrastructure.CrossCutting.Common;
using Infrastructure.CrossCutting.Enums;
using Presentation.Core.Syncfusion.OperationsComparison;
using Syncfusion.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Presentation.Core.Syncfusion
{
    public static class LambdaManager
    {
        private static readonly Dictionary<string, IOperationComparison> OperationComparisons;
        private static readonly Dictionary<string, string> OperationStr;

        static LambdaManager()
        {
            OperationComparisons = new Dictionary<string, IOperationComparison>
            {
                {"startswith", new BeginWithOperationComparison()},
                {"greaterthan", new GreatherThanOperationComparison()},
                {"lessthan", new LowerThanOperationComparison()},
                {"equal", new EqualsOperationComparison()},
                {"notequal", new NotEqualsOperationComparison()},
                {"endswith", new EndsWithOperationComparison()},
                {"contains", new ContainsOperationComparison()}
            };

            OperationStr = new Dictionary<string, string>
            {
                {"greaterthan", "{0} > {1}"},
                {"greaterthanorequal", "{0} >= {1}"},
                {"lessthanorequal", "{0} <= {1}"},
                {"lessthan", "{0} < {1}"},
                {"equal", "{0} = {1}"},
                {"startswith", "{0} like '{1}%'"},
                {"endswith", "{0} like '%{1}'"},
                {"contains", "{0} like '%{1}%'"},
                {"notequal", "{0} <> {1}"}
            };
        }

        public static Expression<Func<T, bool>> GetWhereFilter<T>(List<WhereFilter> rules) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            if (rules == null)
                return p => true;

            foreach (WhereFilter item in rules)
            {
                if (!item.IsComplex)
                {
                    expresionsLambdaSet = expresionsLambdaSet == null
                        ? GetLambdaPropertyComparison<T>(item)
                        : expresionsLambdaSet.And(GetLambdaPropertyComparison<T>(item));
                }
                else
                {
                    if (item.Condition == "and")
                    {
                        expresionsLambdaSet = expresionsLambdaSet != null
                            ? expresionsLambdaSet.And(GetWhereFilter<T>(item.predicates))
                            : GetWhereFilter<T>(item.predicates);
                    }
                    else if (item.Condition == "or")
                    {
                        expresionsLambdaSet = expresionsLambdaSet != null
                            ? expresionsLambdaSet.Or(GetWhereFilter<T>(item.predicates))
                            : GetWhereFilter<T>(item.predicates);
                    }
                }
            }

            return expresionsLambdaSet;
        }

        public static OrderByParameter GetOrderByColumn(List<Sort> ordenamientoList)
        {
            if (ordenamientoList == null)
                return new OrderByParameter { Direction = TipoOrdenamiento.Ascending };

            var orderBy = ordenamientoList.First();

            return new OrderByParameter
            {
                Column = orderBy.Name,
                Direction = (TipoOrdenamiento)Enum.Parse(typeof(TipoOrdenamiento), orderBy.Direction, true)
            };
        }

        private static Expression<Func<T, bool>> GetLambdaPropertyComparison<T>(WhereFilter filter) where T : class
        {
            Expression comparison = null;
            ParameterExpression arg = Expression.Parameter(typeof(T), "p");
            PropertyInfo property = GetPropertyInfo(typeof(T), filter.Field);

            if (property != null)
            {
                Expression valorEvaluar = filter.value == null
                    ? (Expression)Expression.Constant(filter.value)
                    : Expression.Convert(Expression.Constant(Convert.ChangeType(filter.value,
                        Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType)),
                        property.PropertyType);

                comparison = OperationComparisons[filter.Operator].GetOperationComparison<T>(arg, filter.Field, valorEvaluar);
            }

            #region Concatenacion de las Expresiones de los rules actuales

            return comparison != null ? Expression.Lambda<Func<T, bool>>(comparison, arg) : null;

            #endregion
        }

        private static PropertyInfo GetPropertyInfo(Type tipoDato, string field)
        {
            PropertyInfo property = tipoDato.GetProperty(field);
            return property;
        }

        public static string GetWhereFilterStr(List<WhereFilter> rules)
        {
            string expWhere = "";

            if (rules == null)
                return "";

            foreach (WhereFilter item in rules)
            {
                string condition = string.IsNullOrEmpty(item.Condition) ? " AND " : item.Condition;

                if (!item.IsComplex)
                {
                    expWhere = expWhere == "" ? expWhere : (expWhere + " " + condition);

                    var valueWithoutSingleQuotes = item.value.ToString().Replace("'", "");

                    if (DateTimeUtils.CheckingConvertDate(valueWithoutSingleQuotes, Constantes.FormatoFechaPorDefecto))
                    {
                        var date = DateTimeUtils.ConvertDate(valueWithoutSingleQuotes, Constantes.FormatoFechaPorDefecto);
                        var dateSql = string.Format("''{0}''", date.ToString(MasterConstantes.FormatoFechaSqlServer));
                        var fieldSql = string.Format("DATEADD(HOUR,{0},{1})", WebSession.Usuario.TimeZoneGMT, item.Field);

                        expWhere = expWhere + string.Format(OperationStr[item.Operator.ToLower()], fieldSql, dateSql);
                    }
                    else
                    {
                        expWhere = expWhere + string.Format(OperationStr[item.Operator.ToLower()], item.Field, item.value);
                    }
                }
                else
                {
                    expWhere = expWhere == "" ? expWhere : ("(" + expWhere + ") " + condition + " ");
                    var getPred = GetWhereFilterStr(item.predicates);
                    expWhere = expWhere + (getPred == "" ? "" : ("(" + getPred + ") "));
                }
            }

            return expWhere;
        }

        public static string GetOrderByStr(List<Sort> ordenamientoList)
        {
            string orderBy = "";
            if (ordenamientoList == null)
            {
                return orderBy;
            }

            foreach (var order in ordenamientoList)
            {
                var orderParam = new OrderByParameter
                {
                    Column = order.Name,
                    Direction = (TipoOrdenamiento)Enum.Parse(typeof(TipoOrdenamiento), order.Direction, true)
                };

                string orderType = orderParam.Direction == TipoOrdenamiento.Ascending ? "asc" : "";
                orderType = orderParam.Direction == TipoOrdenamiento.Descending ? "desc" : "";

                orderBy = orderBy + (orderBy == "" ? "" : ", ") + (orderParam.Column + " " + orderType);
            }

            return orderBy;
        }
    }
}