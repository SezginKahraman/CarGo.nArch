using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace CarGo.Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
    {
    }
}
