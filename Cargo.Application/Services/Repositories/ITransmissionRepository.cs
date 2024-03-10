using CarGo.Domain.Entities;
using Core.Persistance.Repositories;

namespace CarGo.Application.Services.Repositories;

public interface ITransmissionRepository : IAsyncRepository<Transmission, Guid>, IRepository<Transmission, Guid>
{
}