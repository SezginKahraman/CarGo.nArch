using Core.Persistance.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Application.Services.Repositories
{
    public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator, int>, IRepository<EmailAuthenticator, int>
    {
    }
}
