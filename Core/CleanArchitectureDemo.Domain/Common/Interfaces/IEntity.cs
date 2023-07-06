namespace CleanArchitectureDemo.Domain.Common.Interfaces
{
    /// <summary>
    /// This file contains a base IEntity interface and 
    /// all domain entities will implement this interface either directly or indirectly
    /// </summary>
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
