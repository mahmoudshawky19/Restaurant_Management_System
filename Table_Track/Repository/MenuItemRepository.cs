using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MenuItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext; 
        }
    }
}
