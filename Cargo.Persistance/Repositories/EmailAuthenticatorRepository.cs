using CarGo.Application.Services.Repositories;
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
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, BaseDbContext>, IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
