using Application.Core;
using Syncfusion.JavaScript;

namespace Presentation.Core.Syncfusion
{
    public class SyncFusionDataManagerToFilterParametersDtoConverter<TDto> where TDto : class
    {
        public static PaginationParametersDto<TDto> Convert(DataManager dataManager, bool whereStr = false)
        {
            var orderBy = LambdaManager.GetOrderByColumn(dataManager.Sorted);

            var filterParameterDto = new PaginationParametersDto<TDto>
            {
                Start = dataManager.Skip,
                AmountRows = dataManager.Take,
                ColumnOrder = orderBy.Column,
                OrderType = orderBy.Direction,
                WhereFilter = !whereStr ? LambdaManager.GetWhereFilter<TDto>(dataManager.Where) : null,
                WhereFilterStr = whereStr ? LambdaManager.GetWhereFilterStr(dataManager.Where) : "",
                OrderByStr = whereStr ? LambdaManager.GetOrderByStr(dataManager.Sorted) : "",
                CurrentPage = dataManager.Skip/dataManager.Take
            };

            return filterParameterDto;
        }
    }
}