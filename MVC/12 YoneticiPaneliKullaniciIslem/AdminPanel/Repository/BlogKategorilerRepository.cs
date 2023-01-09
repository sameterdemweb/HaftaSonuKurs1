
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class BlogKategorilerRepository : Repository<BlogKategorileri>, IBlogKategorilerRepository
    {
        private AdminPanelContext _context;

        public BlogKategorilerRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
