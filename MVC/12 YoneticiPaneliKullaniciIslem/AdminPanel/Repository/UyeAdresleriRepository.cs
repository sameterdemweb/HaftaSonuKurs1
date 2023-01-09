
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class UyeAdresleriRepository : Repository<UyeAdresleri>, IUyeAdresleriRepository
    {
        private AdminPanelContext _context;

        public UyeAdresleriRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}