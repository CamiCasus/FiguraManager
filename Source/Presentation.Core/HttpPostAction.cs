using System;
using System.Reflection;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Enums;

namespace Presentation.Core
{
    /// <summary>
    /// Representa un atributo que se usa para restringir un método de acción de forma que el método administre solamente las solicitudes HTTP POST.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPostAction : ActionMethodSelectorAttribute, IPermiso
    {
        private readonly TipoPermiso _permiso;

        public HttpPostAction(TipoPermiso permiso)
        {
            _permiso = permiso;
        }

        public TipoPermiso GetPermiso()
        {
            return _permiso;
        }

        private static readonly AcceptVerbsAttribute InnerAttribute = new AcceptVerbsAttribute(HttpVerbs.Post);

        /// <summary>
        /// Determina si la solicitud post del método de acción es válida para el contexto de controlador especificado.
        /// </summary>
        /// 
        /// <returns>
        /// true si la solicitud del método de acción es válida para el contexto de controlador especificado; de lo contrario, false.
        /// </returns>
        /// <param name="controllerContext">Contexto del controlador.</param><param name="methodInfo">Información acerca del método de la acción.</param>
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return InnerAttribute.IsValidForRequest(controllerContext, methodInfo);
        }
    }
}