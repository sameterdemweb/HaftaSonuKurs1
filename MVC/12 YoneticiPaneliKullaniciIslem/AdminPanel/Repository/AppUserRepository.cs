using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class AppUserRepository : Repository<AppIdentityUser>, IAppUserRepository
    {
        private AdminPanelContext _context;
        public AppUserRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
