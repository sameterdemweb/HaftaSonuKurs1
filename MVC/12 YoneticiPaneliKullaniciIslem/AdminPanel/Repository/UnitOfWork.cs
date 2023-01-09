using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;
namespace AdminPanel.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdminPanelContext _context;


        public UnitOfWork(AdminPanelContext context)
        {
            _context = context;
        }

        public IAppUserRepository AppUser => new AppUserRepository(_context);

        public IBlogKategorilerRepository blogKategoriler => new BlogKategorilerRepository(_context);

        public IBloglarRepository bloglar => new BloglarRepository(_context);

        public IFavoriUrunlerRepository favoriUrunler => new FavoriUrunlerRepository(_context);

        public ISepetUrunlerRepository sepetUrunler => new SepetUrunlerRepository(_context);

        public ISiparisDetayRepository siparisDetay => new SiparisDetayRepository(_context);

        public ISiparislerRepository siparisler => new SiparislerRepository(_context);

        public ISliderRepository slider => new SliderRepository(_context);

        public IUrunFotograflariRepository urunFotograflari => new UrunFotograflariRepository(_context);

        public IUrunKategorileriRepository urunKategorileri => new UrunKategorileriRepository(_context);

        public IUrunlerRepository urunler => new UrunlerRepository(_context);

        public IUyeAdresleriRepository uyeAdresleri => new UyeAdresleriRepository(_context);

        public void Dispose()
        {
            _context.Dispose(); //Ramde Durmasını engeller ve kapatır. Performans bir tıkta olsa verimli hale gelir.
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
