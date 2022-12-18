namespace MvcOdev.Services
{
	public static class NotHesaplaServices
	{
		public static double OrtalamaHesapla(int vize, int final, int finalYuzde)
		{
			int vizeYuzde = 100 - finalYuzde;

			double finalNotu = (final * finalYuzde) / 100;

			double vizeNotu = (vize * vizeYuzde) / 100;

			return(finalNotu + vizeNotu);
		}
	}
}
