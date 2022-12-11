namespace MvcOdev.Services
{
	public static class VincTasimaHesapla
	{
		public static int KayipKgBul(int KacMetreGidecek, int HerMetredeKayip, int YuklenenKg) {
			int toplamKg = YuklenenKg;
			int yuzdeKayip=0;
			int yeniToplamKg = toplamKg;

            for (int i = 0; i < KacMetreGidecek; i++)
			{
                yuzdeKayip = (yeniToplamKg / 100) * HerMetredeKayip;
                yeniToplamKg = yeniToplamKg - yuzdeKayip;

            }
			return yeniToplamKg;
		}




	}
}
