namespace Application.Core.Interfaces
{
    public interface IPaginationAppService<TEntity> where TEntity : class
    {
        PaginationResultDto<TEntity> FindAllPaging(PaginationParametersDto<TEntity> parameters, bool @readonly = true); 
    }
}