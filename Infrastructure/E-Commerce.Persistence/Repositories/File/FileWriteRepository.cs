using E_Commerce.Application.Repositories;
using E_Commerce.Persistence.Contexts;

namespace E_Commerce.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
