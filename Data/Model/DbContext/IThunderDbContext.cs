using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Model.DbContext
{
    public interface ITunderDbContext 
    {
        DbSet<User> Users { get; set; }
        DbSet<Ecole> Ecoles { get; set; }
    }
}