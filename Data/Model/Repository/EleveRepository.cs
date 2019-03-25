using Data.Model.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public class EleveRepository : IEleveRepository
    {
        private readonly TunderDbContext _dbContext;

        public EleveRepository(TunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Eleve> CreateEntity(Eleve eleve)
        {
            await _dbContext.Eleves.AddAsync(eleve);
            return eleve;
        }

        public void DeleteEntity(Eleve eleve)
        {
            _dbContext.Eleves.Remove(eleve);
        }

        public async Task<Eleve> GetById(long id)
        {
            return await _dbContext.Eleves.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 1;
        }
    }
}
