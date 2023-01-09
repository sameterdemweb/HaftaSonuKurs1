
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class SepetUrunlerRepository : Repository<SepetUrunler>, ISepetUrunlerRepository
    {
        private AdminPanelContext _context;

        public SepetUrunlerRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
