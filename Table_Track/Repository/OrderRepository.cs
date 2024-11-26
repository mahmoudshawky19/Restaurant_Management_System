using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
