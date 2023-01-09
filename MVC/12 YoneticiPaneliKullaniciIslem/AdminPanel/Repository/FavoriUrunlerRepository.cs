

using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class FavoriUrunlerRepository : Repository<FavoriUrunler>, IFavoriUrunlerRepository
    {
        private AdminPanelContext _context;

        public FavoriUrunlerRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
