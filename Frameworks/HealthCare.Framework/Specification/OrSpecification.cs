﻿using System;
using System.Linq.Expressions;

namespace HealthCare.Framework.Specification
{
    internal class OrSpecification<TEntity> : Specification<TEntity>
    {
        private readonly ISpecification<TEntity> _leftSpecification;
        private readonly ISpecification<TEntity> _rightSpecification;

        public OrSpecification(ISpecification<TEntity> leftSpecification, ISpecification<TEntity> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) || _rightSpecification.IsSatisfiedBy(candidate);
        }

        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            return _leftSpecification.IsSatisfied().Or(_rightSpecification.IsSatisfied());
        }
    }
}
