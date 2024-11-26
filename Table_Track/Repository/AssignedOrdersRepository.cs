
using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class AssignedOrdersRepository : Repository<AssignedOrders>, IAssignedOrdersRepository
    {
        private readonly ApplicationDbContext dbContext;
        public AssignedOrdersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
