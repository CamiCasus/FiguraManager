namespace Domain.Core.Entities
{
    public class EntityWithTypedId<TId> : EntityBase
    {
        public TId Id { get; set; }
    }
}