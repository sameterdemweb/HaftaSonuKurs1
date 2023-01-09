
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class UrunKategorileriRepository : Repository<UrunKategorileri>, IUrunKategorileriRepository
    {
        private AdminPanelContext _context;

        public UrunKategorileriRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}