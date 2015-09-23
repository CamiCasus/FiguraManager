using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Validations
{
    public class ValidationResultWithType<TEntity> : ValidationResult
    {
        #region Propiedades

        public TEntity Data { get; set; }
        

        #endregion
    }
}