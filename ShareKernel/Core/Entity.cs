﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ShareKernel.Core
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        private readonly ICollection<DomainEvent> _domainEvents;

        public ICollection<DomainEvent> DomainEvents { get { return _domainEvents; } }

        protected Entity()
        {
            _domainEvents = new List<DomainEvent>();
        }

        public void AddDomainEvent(DomainEvent evento)
        {
            _domainEvents.Add(evento);
        }
        [ExcludeFromCodeCoverage]
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
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
