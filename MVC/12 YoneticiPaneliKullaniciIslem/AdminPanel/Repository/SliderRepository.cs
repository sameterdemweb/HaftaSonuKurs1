
using AdminPanel.Entities;
using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;

namespace AdminPanel.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private AdminPanelContext _context;

        public SliderRepository(AdminPanelContext context) : base(context)
        {
            _context = context;
        }
    }
}
