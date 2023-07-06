using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.IRepositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayersByClubAsync(int clubId);
    }
}
