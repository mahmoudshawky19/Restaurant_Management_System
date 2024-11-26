using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class OrderMenuItemRepository : Repository<OrderMenuItem>, IOrderMenuItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderMenuItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {this.dbContext = dbContext;
        }
    }
}
