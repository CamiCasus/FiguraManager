using System;
using Application.Core;
using PostSharp.Aspects;

namespace Application.Aspects
{
    [Serializable]
    public class CommitsOperationAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var instanciaAppService = args.Instance as AppService;

            if (instanciaAppService == null)
                throw new Exception("Se agregó el atributo commits sobre una clase que no hereda de AppService");

            instanciaAppService.BeginTransaction();
            args.Proceed();
            instanciaAppService.Commit();
        }
    }
}
