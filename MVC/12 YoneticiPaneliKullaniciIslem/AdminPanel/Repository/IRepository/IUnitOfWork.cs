namespace AdminPanel.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUser { get; }
        IBlogKategorilerRepository blogKategoriler { get; }
        IBloglarRepository bloglar { get; }
        IFavoriUrunlerRepository favoriUrunler { get; }
        ISepetUrunlerRepository sepetUrunler { get; }
        ISiparisDetayRepository siparisDetay { get; }
        ISiparislerRepository siparisler { get; }
        ISliderRepository slider { get; }
        IUrunFotograflariRepository urunFotograflari { get; }
        IUrunKategorileriRepository urunKategorileri { get; }
        IUrunlerRepository urunler { get; } 
        IUyeAdresleriRepository uyeAdresleri { get; }

        void Save();
    }
}
