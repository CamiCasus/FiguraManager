namespace Application.Core
{
    public abstract class EntityDto<TId>
    {
        public TId Id { get; set; }
    }
}
