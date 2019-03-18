using Data.Model.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public class EcoleRepository : IEcoleRepository
    {
        private readonly TunderDbContext _dbContext;

        public EcoleRepository(TunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Ecole> CreateEntity(Ecole ecole)
        {
            await _dbContext.Ecoles.AddAsync(ecole);
            return ecole;
        }

        public void DeleteEntity(Ecole ecole)
        {
            _dbContext.Ecoles.Remove(ecole);
        }

        public async Task<Ecole> GetById(long id)
        {
            return await _dbContext.Ecoles.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 1;
        }

        public void UpdateEntity(Ecole ecole)
        {
            throw new NotImplementedException();
        }
    }
}
