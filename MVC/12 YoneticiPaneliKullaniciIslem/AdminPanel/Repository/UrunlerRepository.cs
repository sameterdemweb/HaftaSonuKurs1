
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class UrunlerRepository : Repository<Urunler>, IUrunlerRepository
    {
        private AdminPanelContext _context;

        public UrunlerRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}