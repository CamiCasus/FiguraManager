using Infrastructure.CrossCutting.Enums;
using System;
using System.Linq.Expressions;

namespace Application.Core
{
    public class PaginationParametersDto<T> where T : class 
    {
        public string ColumnOrder { get; set; }
        public TipoOrdenamiento OrderType { get; set; }
        public int Start { get; set; }
        public int CurrentPage { get; set; }
        public int AmountRows { get; set; }
        public Expression<Func<T, bool>> WhereFilter { get; set; }
        public string WhereFilterStr { get; set; }
        public string OrderByStr { get; set; }
    }
}