using E_Commerce.Application.Repositories;
using E_Commerce.Persistence.Contexts;

namespace E_Commerce.Persistence.Repositories
{
    internal class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
