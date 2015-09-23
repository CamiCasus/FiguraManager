using Domain.Core.Entities;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Domain.Core.Interfaces.OrderBy;
using Domain.Core.OrderBy;

namespace Infrastructure.CrossCutting.IoC.DependencyResolution.Conventions
{
    public class OrderByEntityConvention : IRegistrationConvention
    {
        private static readonly Type OpenHandlerInterfaceType = typeof(IOrderByEntity<>);
        private static readonly IList<Type> CustomCommandHandlerTypes;

        static OrderByEntityConvention()
        {
            CustomCommandHandlerTypes = Assembly.Load(AssemblyNames.DomainMainModule)
                .ExportedTypes
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericType || x.GetGenericTypeDefinition() != typeof(OrderByEntity<>))
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IOrderByEntity<>)))
                .ToArray();
        }

        #region Public Methods and Operators

        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof(EntityBase).IsAssignableFrom(type))
            {
                var insertclosedHandlerInterfaceType = OpenHandlerInterfaceType.MakeGenericType(type);

                // check for any classes that implement IValidation<T> that are not also Validation<T>
                var customHandler = CustomCommandHandlerTypes.FirstOrDefault(t => t.GetInterfaces().Any(i => i == insertclosedHandlerInterfaceType));

                if (customHandler != null)
                {
                    registry.For(insertclosedHandlerInterfaceType)
                    .Use(customHandler);
                }
            }
        }

        #endregion 
    }
}