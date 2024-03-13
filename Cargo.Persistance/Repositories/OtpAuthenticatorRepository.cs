using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using CarGo.Persistance.Contexts;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Persistance.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, BaseDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
