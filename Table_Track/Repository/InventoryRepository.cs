using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InventoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
