using CleanArchitectureDemo.Application.IRepositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Persistence.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly IGenericRepository<Stadium> _repository;

        public StadiumRepository(IGenericRepository<Stadium> repository)
        {
            _repository = repository;
        }
    }
}
