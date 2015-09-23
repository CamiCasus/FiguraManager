using Infrastructure.CrossCutting.Enums;

namespace Presentation.Core.Syncfusion
{
    public class OrderByParameter
    {
        public string Column { get; set; }
        public TipoOrdenamiento Direction { get; set; }
    }
}