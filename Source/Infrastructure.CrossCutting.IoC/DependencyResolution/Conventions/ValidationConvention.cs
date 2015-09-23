using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core.Entities;
using Domain.Core.Interfaces.Validations;
using Domain.Core.Validations;
using Domain.MainModule.Validations;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Infrastructure.CrossCutting.IoC.DependencyResolution.Conventions
{
    public class ValidationConvention : IRegistrationConvention
    {
        private static readonly Type OpenImplementationValidation = typeof (UsuarioIsValidValidation);
        private static readonly Type OpenHandlerInterfaceType = typeof(IValidation<>);
        private static readonly Type OpenInsertCommandHandlerType = typeof(Validation<>);
        private static readonly IList<Type> CustomCommandHandlerTypes;

        static ValidationConvention()
        {
            CustomCommandHandlerTypes = OpenImplementationValidation
                .Assembly
                .ExportedTypes
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericType || x.GetGenericTypeDefinition() != typeof (Validation<>))
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidation<>)))
                .ToArray();
        }


        #region Public Methods and Operators

        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof(EntityBase).IsAssignableFrom(type))
            {
                var insertclosedHandlerInterfaceType = OpenHandlerInterfaceType.MakeGenericType(type);
                var closedInsertCommandHandlerType = OpenInsertCommandHandlerType.MakeGenericType(type);

                // check for any classes that implement IValidation<T> that are not also Validation<T>
                var customHandler = CustomCommandHandlerTypes.FirstOrDefault(t => t.GetInterfaces().Any(i => i == insertclosedHandlerInterfaceType));

                registry.For(insertclosedHandlerInterfaceType)
                    .Use(customHandler ?? closedInsertCommandHandlerType);
            }
        }

        #endregion
    }
}
