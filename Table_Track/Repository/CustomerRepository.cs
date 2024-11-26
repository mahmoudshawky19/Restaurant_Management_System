using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
