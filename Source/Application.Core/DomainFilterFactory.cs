using Application.Core.Extensions;
using Domain.Core.Interfaces.OrderBy;
using Domain.Core.Pagination;

namespace Application.Core
{
    public static class DomainFilterFactory
    {
        public static PaginationParameters<TEntity> GenerateDomainFilterParameters<TEntity, TEntityDto>(
            PaginationParametersDto<TEntityDto> parametersDto, IOrderByEntity<TEntity> orderByEntity)
            where TEntity : class where TEntityDto : class
        {
            var orderByResponse = orderByEntity.GetOrderExpression(parametersDto.ColumnOrder);
            var nuevoFiltroParameters = new PaginationParameters<TEntity>
            {
                ColumnOrder = orderByResponse.LambdaExpression,
                AmountRows = parametersDto.AmountRows,
                Start = parametersDto.Start,
                OrderType = orderByResponse.TipoOrdenamiento ?? parametersDto.OrderType,
                WhereFilter = parametersDto.WhereFilter.CreateDtoToEntityExpression<TEntity, TEntityDto>()
            };

            return nuevoFiltroParameters;
        }
    }
}