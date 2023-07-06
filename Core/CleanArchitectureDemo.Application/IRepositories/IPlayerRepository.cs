using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.IRepositories
{
    /// <summary>
    /// Most of the time, repositories will only use the generic methods defined 
    /// in the IGenericRepository class but if they have some additional functionality and 
    /// require a custom method implementation then these methods can be defined in specific repository interfaces. 
    /// In the following example, IPlayerRepository is defining an additional method to get players by the club.
    /// </summary>
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayersByClubAsync(int clubId);
    }
}
