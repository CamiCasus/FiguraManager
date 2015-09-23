using System;
using System.Collections.Generic;
using Infrastructure.CrossCutting.Logging;
using PostSharp.Aspects;

namespace Presentation.Aspects
{
    [Serializable]
    public class ActionControllerAttribute : MethodInterceptionAspect
    {
        protected static readonly ILogger Logger = new Log4Net();

        private readonly Dictionary<ActionType, IActionMethod> _accionesMethods;

        private readonly ActionType _actionType;

        public ActionControllerAttribute(ActionType actionType)
        {
            AspectPriority = 9;
            AttributePriority = 9;

            _accionesMethods = new Dictionary<ActionType, IActionMethod>
            {
                {ActionType.Get, new GetActionMethod()},
                {ActionType.Post, new PostActionMethod()},
                {ActionType.Delete, new DeleteActionMethod()}
            };

            _actionType = actionType;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            _accionesMethods[_actionType].Process(args, Logger);
        }
    }
}