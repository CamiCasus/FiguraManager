using Infrastructure.CrossCutting.Logging;
using PostSharp.Aspects;

namespace Presentation.Aspects
{
    public interface IActionMethod
    {
        void Process(MethodInterceptionArgs args, ILogger log);
    }
}