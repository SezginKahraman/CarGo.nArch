using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using CarGo.Persistance.Contexts;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userId, int refreshTokenTTL)
        {
            var tokens = await Query()
                .AsNoTracking()
                .Where(p => p.UserId == userId 
                            && p.Revoked == null 
                            && p.Expires >= DateTime.UtcNow 
                            && p.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow)
                .ToListAsync();
            return tokens;
        }
    }
}
