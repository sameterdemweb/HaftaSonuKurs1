
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class BloglarRepository : Repository<Bloglar>, IBloglarRepository
    {
        private AdminPanelContext _context;

        public BloglarRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
