using System;
using System.Diagnostics.CodeAnalysis;

namespace ShareKernel.Core
{
    public abstract record ValueObject
    {
        [ExcludeFromCodeCoverage]
        protected void CheckRule(IBussinessRule rule)
        {
            if (rule is null)
            {
                throw new ArgumentException("Rule cannot be null");
            }
            if (!rule.IsValid())
            {
                throw new BussinessRuleValidationException(rule);
            }
        }

    }
}
