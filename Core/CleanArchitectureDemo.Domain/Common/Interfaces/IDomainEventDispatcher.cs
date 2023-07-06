namespace CleanArchitectureDemo.Domain.Common.Interfaces
{
    /// <summary>
    /// This interface declares a method that can be used to dispatch domain events throughout the application.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
