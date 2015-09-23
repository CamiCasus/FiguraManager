using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Domain.Core.Interfaces.OrderBy;
using Infrastructure.CrossCutting.Enums;

namespace Domain.Core.OrderBy
{
    public abstract class OrderByEntity<TEntity> : IOrderByEntity<TEntity> where TEntity: class 
    {
        private readonly Dictionary<string, LambdaExpression> _orders;
        private readonly string _defaultOrderByColumn;
        private readonly TipoOrdenamiento _defaultTipoOrdenamiento;

        protected OrderByEntity(string defaultOrderByColumn,
            TipoOrdenamiento defaultTipoOrdenamiento = TipoOrdenamiento.Ascending)
        {
            _orders = new Dictionary<string, LambdaExpression>();
            _defaultOrderByColumn = defaultOrderByColumn;
            _defaultTipoOrdenamiento = defaultTipoOrdenamiento;
        }

        protected void AddOrder<TKey>(string propertyNameDto, Expression<Func<TEntity, TKey>> expressionDomain)
        {
            _orders.Add(propertyNameDto, expressionDomain);
        }

        protected void RemoveOrder(string propertyNameDto)
        {
            _orders.Remove(propertyNameDto);
        }

        public OrderByResponse GetOrderExpression(string propertyName)
        {
            var orderByResponse = new OrderByResponse();

            if (string.IsNullOrEmpty(propertyName))
            {
                orderByResponse.LambdaExpression = GetLambdaByPropertyString(_defaultOrderByColumn);
                orderByResponse.TipoOrdenamiento = _defaultTipoOrdenamiento;

                return orderByResponse;
            }

            if (!_orders.ContainsKey(propertyName))
            {
                var propertyEntity = GetProperty(propertyName);
                if (propertyEntity == null)
                    throw new NotImplementedException(string.Format("La propiedad {0} no se encuentra en el tipo {1}",
                        propertyName, typeof (TEntity).Name));

                orderByResponse.LambdaExpression = GetLambdaByPropertyString(propertyName);
            }

            orderByResponse.LambdaExpression = _orders[propertyName];
            return orderByResponse;
        }

        private LambdaExpression GetLambdaByPropertyString(string propertyName)
        {
            ParameterExpression p = Expression.Parameter(typeof(TEntity), "p");
            return
                Expression.Lambda(
                    Expression.Property(p, GetProperty(propertyName)), p);
        } 

        private PropertyInfo GetProperty(string propertyName)
        {
            return typeof (TEntity).GetProperty(propertyName);
        }
    }
}