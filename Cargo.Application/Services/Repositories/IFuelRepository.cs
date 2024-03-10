using CarGo.Domain.Entities;
using Core.Persistance.Repositories;

namespace CarGo.Application.Services.Repositories;

public interface IFuelRepository : IAsyncRepository<Fuel, Guid>, IRepository<Fuel, Guid>
{
}