namespace Domain.Core.Validations
{
    public class ValidationResultWithType<TEntity> : ValidationResult
    {
        #region Propiedades

        public TEntity Data { get; set; }
        

        #endregion
    }
}