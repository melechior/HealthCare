using System;
using System.Linq.Expressions;

namespace HealthCare.Framework.Specification
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity candidate);
        Expression<Func<TEntity, bool>> IsSatisfied();
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
        ISpecification<TEntity> Not();
        ISpecification<TEntity> OrderBy(ISpecification<TEntity> other);
        ISpecification<TEntity> Take(int amount);
        ISpecification<TEntity> Skip(int amount);
    }
}
