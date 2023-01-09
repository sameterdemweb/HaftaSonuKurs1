
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class SiparisDetayRepository : Repository<SiparisDetay>, ISiparisDetayRepository
    {
        private AdminPanelContext _context;

        public SiparisDetayRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
