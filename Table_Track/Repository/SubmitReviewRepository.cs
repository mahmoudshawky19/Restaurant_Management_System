using Table_Track.Data;
using Table_Track.Models;
using Table_Track.Repository.IRepository;

namespace Table_Track.Repository
{
    public class SubmitReviewRepository : Repository<SubmitReview>, ISubmitReviewRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SubmitReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
