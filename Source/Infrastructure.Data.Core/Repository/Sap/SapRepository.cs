using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using Domain.Core.Interfaces.RepositoryContracts;
using Domain.Core.Pagination;
using SAP.Middleware.Connector;

namespace Infrastructure.Data.Core.Repository.Sap
{
    public class SapRepository<TEntity, TId> : IRepository<TEntity, TId>, IDisposable
         where TEntity : class
    {
        #region Métodos Privados

        private InMemoryDestinationConfiguration _destinationConfiguration;
        private readonly SapConfiguration _sapConfiguration;

        public SapRepository()
        {
            _sapConfiguration = ObtenerConfiguration();
        }

        private SapConfiguration ObtenerConfiguration()
        {
            var configurationSection = (SapConfigurationSection)ConfigurationManager.GetSection("Sap.Configuration");
            return configurationSection.Configuration;
        }

        private RfcDestination Conectar()
        {
            var destinationConfiguration = new DestinationConfig
            {
                Host = _sapConfiguration.Host,
                Client = _sapConfiguration.Client,
                Password = _sapConfiguration.Password,
                Language = _sapConfiguration.Language,
                User = _sapConfiguration.User,
                SystemNumber = _sapConfiguration.SystemNumber,
                SapRouter = _sapConfiguration.SapRouter,
                SystemId = _sapConfiguration.SystemId
            };

            _destinationConfiguration = new InMemoryDestinationConfiguration();
            _destinationConfiguration.AddOrEditDestination(destinationConfiguration.GetParameters(_sapConfiguration.Ambiente));
            {
                
            }
                

            RfcDestinationManager.RegisterDestinationConfiguration(_destinationConfiguration);
            return RfcDestinationManager.GetDestination(_sapConfiguration.Ambiente);
        }

        private void Desconectar()
        {
            RfcDestinationManager.UnregisterDestinationConfiguration(_destinationConfiguration);
            _destinationConfiguration.RemoveDestination(_sapConfiguration.Ambiente);
        } 

        #endregion

        #region Metodos IRepository

        public virtual TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            throw new NotImplementedException();
        }

        public virtual PaginationResult<TEntity> FindAllPaging(PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            throw new NotImplementedException();
        } 

        #endregion

        protected TEntity EjecutarFuncionRfc(string functionName, Dictionary<string, string> parametros,
            Func<IRfcFunction, TEntity> logicaEjecucion)
        {
            try
            {
                RfcDestination rfcDestination = Conectar();
                RfcRepository rfcRepository = rfcDestination.Repository;

                IRfcFunction rfcFunction = rfcRepository.CreateFunction(functionName);
                foreach (var parameter in parametros)
                {
                    rfcFunction.SetValue(parameter.Key, parameter.Value);
                }

                rfcFunction.Invoke(rfcDestination);

                var entidadRespuesta = logicaEjecucion(rfcFunction);

                return entidadRespuesta;
            }
            finally
            {
                Desconectar();
            }
        }

        protected void EjecutarFuncionRfcUpdate(string functionName, Dictionary<string, string> parametros,
            Action<IRfcFunction> logicaEjecucion)
        {
            try
            {
                RfcDestination rfcDestination = Conectar();
                RfcRepository rfcRepository = rfcDestination.Repository;

                IRfcFunction rfcFunction = rfcRepository.CreateFunction(functionName);
                foreach (var parameter in parametros)
                {
                    rfcFunction.SetValue(parameter.Key, parameter.Value);
                }

                rfcFunction.Invoke(rfcDestination);

                logicaEjecucion(rfcFunction);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Dispose()
        {
            
        }
    }
}