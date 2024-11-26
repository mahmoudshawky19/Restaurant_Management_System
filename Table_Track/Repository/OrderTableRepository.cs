using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class OrderTableRepository : Repository<OrderTable>, IOrderTableRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderTableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
