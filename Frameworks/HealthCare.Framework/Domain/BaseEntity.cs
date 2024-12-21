using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthCare.Framework.Resources;

namespace HealthCare.Framework.Domain
{
    public abstract class BaseEntity
    {
        private readonly List<ResultMessage> _brokenRules = new List<ResultMessage>();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        protected abstract void Validate();

        public virtual IEnumerable<ResultMessage> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(ResultMessage businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}