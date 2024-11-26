using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
