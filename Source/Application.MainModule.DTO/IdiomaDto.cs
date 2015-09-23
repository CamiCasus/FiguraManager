using System;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class IdiomaDto
    {
        public IdiomaDto(string codigo)
        {
            Codigo = codigo;
        }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsRTL { get; set; }
        public string CodigoNeutral
        {
            get
            {
                if (string.IsNullOrEmpty(Codigo)) return string.Empty;
                if (!Codigo.Contains("-")) return Codigo;
                return Codigo.Split('-')[0];
            }
        }
    }
}
