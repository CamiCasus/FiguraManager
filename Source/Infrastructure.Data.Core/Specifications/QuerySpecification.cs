using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Core.Interfaces.Specifications;

namespace Infrastructure.Data.Core.Specifications
{
    public abstract class QuerySpecification<T> : IQuerySpecification<T>
    {
        public virtual Expression<Func<T, bool>> MatchingCriteria
        {
            get { return null; }
        }

        public virtual IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            if (MatchingCriteria != null)
            {
                return candidates.Where(MatchingCriteria).AsQueryable();
            }
            return candidates;
        }
    }
}