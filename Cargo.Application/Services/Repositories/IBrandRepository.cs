using CarGo.Domain.Entities;
using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Application.Services.Repositories
{
    public interface IBrandRepository : IAsyncRepository<Brand, Guid>, IRepository<Brand, Guid>
    {
    }
}
