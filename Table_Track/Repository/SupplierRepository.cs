using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {this.dbContext = dbContext;
        }
    }
}
