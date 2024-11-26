using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
