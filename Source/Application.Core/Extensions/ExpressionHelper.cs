using System;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;

namespace Application.Core.Extensions
{
    public static class ExpressionHelper
    {
        public static Expression<Func<TEntity, bool>> CreateDtoToEntityExpression<TEntity, TDto>(
            this Expression<Func<TDto, bool>> predicate) where TEntity : class
        {
            var visitor = new Visitor();
            var expresionReducida = visitor.Visit(predicate);

            var mappedExpression = Mapper.Map<Expression<Func<TEntity, bool>>>(expresionReducida);
            return mappedExpression;
        }
    }

    public class Visitor : ExpressionVisitor
    {
        protected override Expression VisitMember
            (MemberExpression memberExpression)
        {
            // Recurse down to see if we can simplify...
            var expression = Visit(memberExpression.Expression);

            // If we've ended up with a constant, and it's a property or a field,
            // we can simplify ourselves to a constant
            if (expression is ConstantExpression)
            {
                object container = ((ConstantExpression)expression).Value;
                var member = memberExpression.Member;
                if (member is FieldInfo)
                {
                    var fildConcreteType = (FieldInfo) member;
                    object value = fildConcreteType.GetValue(container);
                    return Expression.Constant(value, fildConcreteType.FieldType);
                }
                if (member is PropertyInfo)
                {
                    var propertyConcreteType = (PropertyInfo) member;
                    object value = propertyConcreteType.GetValue(container, null);
                    return Expression.Constant(value, propertyConcreteType.PropertyType);
                }

                //switch (member.MemberType)
                //{
                //    case MemberTypes.Event:
                //        return ((EventInfo)member).EventHandlerType;
                //    case MemberTypes.Field:
                //        return ((FieldInfo)member).FieldType;
                //    case MemberTypes.Method:
                //        return ((MethodInfo)member).ReturnType;
                //    case MemberTypes.Property:
                //        return ((PropertyInfo)member).PropertyType;
                //    default:
                //        throw new ArgumentException
                //        (
                //         "Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo"
                //        );
                //}

            }
            return base.VisitMember(memberExpression);
        }
    }
}