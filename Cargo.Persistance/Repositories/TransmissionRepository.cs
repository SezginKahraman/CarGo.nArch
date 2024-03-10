using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using CarGo.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CarGo.Persistance.Repositories;

public class TransmissionRepository : EfRepositoryBase<Transmission, Guid, BaseDbContext>, ITransmissionRepository
{
    public TransmissionRepository(BaseDbContext context) : base(context)
    {
    }
}