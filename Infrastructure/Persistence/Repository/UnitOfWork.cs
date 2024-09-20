using Application.Repositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolApiDbContext _schoolApiDbContext;
        public UnitOfWork(SchoolApiDbContext schoolApiDbContext)
        {
            _schoolApiDbContext = schoolApiDbContext;
        }
        public async Task<int> SaveAsync()
        {
           return await _schoolApiDbContext.SaveChangesAsync();
        }
    }
}
