using CarGo.Domain.Entities;
using Core.Persistance.Repositories;

namespace CarGo.Application.Services.Repositories;

public interface IModelRepository : IAsyncRepository<Model, Guid>, IRepository<Model, Guid>
{
}