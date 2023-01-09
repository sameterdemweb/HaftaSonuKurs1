
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class SiparislerRepository : Repository<Siparisler>, ISiparislerRepository
    {
        private AdminPanelContext _context;

        public SiparislerRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
