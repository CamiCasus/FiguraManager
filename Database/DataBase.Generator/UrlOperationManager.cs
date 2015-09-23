using System.Collections.Generic;
using DataBase.Generator.Enums;

namespace DataBase.Generator
{
    public static class UrlOperationManager
    {
        static UrlOperationManager()
        {
            OperationsUrl = new Dictionary<TipoOperacion, string>
            {
                {TipoOperacion.UsuarioOperation, "~/Administracion/Usuario/Index"},
                {TipoOperacion.FormularioOperation, "~/Administracion/Formulario/Index"},
                {TipoOperacion.DatoGeneralOperation, "~/Administracion/DatoGeneral/Index"},
                {TipoOperacion.TablaOperation, "~/Administracion/Tabla/Index"},
                {TipoOperacion.AgenciaOperation, "~/Administracion/Agencia/Index"},
                {TipoOperacion.ClienteOperation, "~/Administracion/Cliente/Index"},
                {TipoOperacion.SerieDocumentoOperation, "~/Administracion/SerieDocumento/Index"},
                {TipoOperacion.TipoCambioOperation, "~/Administracion/TipoCambio/Index"},
                {TipoOperacion.EmisionRemesaOperation, "~/Administracion/EmisionRemesa/Index"},
                {TipoOperacion.PagoRemesaOperation, "~/Administracion/PagoRemesa/Index"},
                {TipoOperacion.DevolucionRemesaOperation, "~/Administracion/DevolucionRemesa/Index"},
                {TipoOperacion.MovimientoOperation, "~/Administracion/Movimiento/Index"},
                {TipoOperacion.CierreSaldosOperation, "~/Administracion/CierreSaldos/Index"},
                {TipoOperacion.SeguimientoOperation, "~/Administracion/Seguimiento/Index"},
                {TipoOperacion.SaldosOperation, "~/Administracion/Saldos/Index"},
                {TipoOperacion.GananciaOperation, "~/Administracion/Ganancia/Index"},
                {TipoOperacion.SaldoActualOperation, "~/Administracion/SaldoActual/Index"}
            };
        }

        public static Dictionary<TipoOperacion, string> OperationsUrl { get; set; }
    }
}