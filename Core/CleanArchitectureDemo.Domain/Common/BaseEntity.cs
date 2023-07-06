using CleanArchitectureDemo.Domain.Common.Interfaces;

namespace CleanArchitectureDemo.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
