using System.Collections.Generic;
using System.Linq;
using Infrastructure.CrossCutting.Enums;
using Syncfusion.JavaScript;

namespace Presentation.Core.Syncfusion
{
    public static class SyncFusionToolbarItemsHelper
    {
        public static List<ToolBarItems> GetValidItems(int seccion, bool includeUpdateAndCancel = false)
        {
            var permisosFormulario = WebSession.FormularioActual.PermisoList.Where(p => p.Seccion == seccion);
            var listaToolbarItems = new List<ToolBarItems>();

            foreach (var item in permisosFormulario)
            {
                var tipoPermiso = (TipoPermiso)item.TipoPermiso;
                switch (tipoPermiso)
                {
                    case TipoPermiso.Crear:
                        listaToolbarItems.Add(ToolBarItems.Add);
                        break;
                    case TipoPermiso.Editar:
                        listaToolbarItems.Add(ToolBarItems.Edit);
                        break;
                    case TipoPermiso.Eliminar:
                        listaToolbarItems.Add(ToolBarItems.Delete);
                        break;
                    case TipoPermiso.Imprimir:
                        listaToolbarItems.Add(ToolBarItems.PrintGrid);
                        break;
                }
            }

            if (includeUpdateAndCancel && listaToolbarItems.Any())
                listaToolbarItems.AddRange(new[] { ToolBarItems.Update, ToolBarItems.Cancel });

            return listaToolbarItems;
        }

        public static EditOptionsBuilder<T> AllowActions<T>(EditOptionsBuilder<T> edit, int seccion) where T : class
        {
            var permisosFormulario = WebSession.FormularioActual.PermisoList.Where(p => p.Seccion == seccion);

            foreach (var item in permisosFormulario)
            {
                var tipoPermiso = (TipoPermiso)item.TipoPermiso;
                switch (tipoPermiso)
                {
                    case TipoPermiso.Crear:
                        edit = edit.AllowAdding();
                        break;
                    case TipoPermiso.Editar:
                        edit = edit.AllowEditing();
                        break;
                    case TipoPermiso.Eliminar:
                        edit = edit.AllowDeleting();
                        break;
                }
            }

            return edit;
        }
    }
}