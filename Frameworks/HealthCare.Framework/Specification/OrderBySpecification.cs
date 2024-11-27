using System;
using System.Linq;
using System.Linq.Expressions;

namespace HealthCare.Framework.Specification
{
    internal class OrderBySpecification<TEntity> : Specification<TEntity>
    {
        private ISpecification<TEntity> _innerSpecification;
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Sort { get; protected set; }
        public Func<IQueryable<TEntity>, IQueryable<TEntity>> PostProcess { get; protected set; }

        public OrderBySpecification(ISpecification<TEntity> innerSpecification)
        {
            _innerSpecification = innerSpecification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !_innerSpecification.IsSatisfiedBy(candidate);
        }

        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            //return Expression.Lambda<Func<TEntity, bool>>(Expression.(_innerSpecification.IsSatisfied()));
            throw new NotImplementedException();
        }
    }
}
