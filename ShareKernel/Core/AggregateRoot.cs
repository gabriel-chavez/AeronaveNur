using System.Diagnostics.CodeAnalysis;

namespace ShareKernel.Core
{
    [ExcludeFromCodeCoverage]
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
    }
}
