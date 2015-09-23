using System.Collections.Generic;

namespace Application.Core
{
    public class ValidationResultDto
    {
        #region Propiedades

        public bool IsValid { get; set; }

        public object Data { get; set; }

        public IEnumerable<string> Errors { get; set; }

        #endregion

        #region Metodos

        public string ErrorMessage(string delimiter = "<br/>")
        {
            string errorMessage = "";

            foreach (var error in Errors)
            {
                if (string.IsNullOrEmpty(errorMessage)) errorMessage = error;
                else
                    errorMessage += delimiter + error;
            }

            return errorMessage;
        }

        public TDto GetData<TDto>() 
        {
            return (TDto)Data;
        }

        #endregion
    }
}
