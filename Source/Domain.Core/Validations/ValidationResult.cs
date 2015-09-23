using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Validations
{
    public class ValidationResult
    {
        #region Variables

        private readonly List<ValidationError> _erros;

        #endregion

        #region Propiedades

        public bool IsValid { get { return !_erros.Any(); } }

        public IEnumerable<ValidationError> Errors { get { return _erros; } }

        public IEnumerable<string> ErrorsStr { get { return _erros.Select(p => p.Message); } }

        public string ErrorMessage
        {
            get
            {
                string errorMessage = "";
                foreach (var error in _erros)
                {
                    if (string.IsNullOrEmpty(errorMessage)) errorMessage = error.Message;
                    else errorMessage += Environment.NewLine + error.Message;
                }
                return errorMessage;
            }
        }

        #endregion

        #region Constructor

        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }

        #endregion

        #region Metodos

        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult [] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
            {
                if (!result.IsValid)
                {
                    _erros.AddRange(result.Errors);
                }
            }

            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_erros.Contains(error))
                _erros.Remove(error);
            return this;
        }

        #endregion
    }
}