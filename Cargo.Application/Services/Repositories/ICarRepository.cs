using CarGo.Domain.Entities;
using Core.Persistance.Repositories;

namespace CarGo.Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
{
}