using Data.Model.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public class ProfesseurRepository : IProfesseurRepository
    {
        private readonly TunderDbContext _dbContext;

        public ProfesseurRepository(TunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Professeur> CreateEntity(Professeur professeur)
        {
            await _dbContext.Professeurs.AddAsync(professeur);
            return professeur;
        }

        public void DeleteEntity(Professeur professeur)
        {
            _dbContext.Professeurs.Remove(professeur);
        }

        public async Task<Professeur> GetById(long id)
        {
            return await _dbContext.Professeurs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 1;
        }
    }
}
