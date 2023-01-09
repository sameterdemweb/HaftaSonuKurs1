

using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class UrunFotograflariRepository : Repository<UrunFotograflari>, IUrunFotograflariRepository
    {
        private AdminPanelContext _context;

        public UrunFotograflariRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
