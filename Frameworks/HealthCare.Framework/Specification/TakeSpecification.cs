﻿using System;
using System.Linq.Expressions;

namespace HealthCare.Framework.Specification
{
    internal class TakeSpecification<TEntity> : Specification<TEntity>
    {
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            throw new NotImplementedException();
        }
        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            throw new NotImplementedException();
        }
    }
}
