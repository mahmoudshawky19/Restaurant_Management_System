using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class TableRepository : Repository<RestaurantTable>, ITableRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {this.dbContext = dbContext;
        }
    }
}
