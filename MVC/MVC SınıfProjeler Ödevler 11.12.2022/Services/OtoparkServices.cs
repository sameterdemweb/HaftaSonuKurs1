namespace MvcOdev.Services
{
	public static class OtoparkServices
	{
		public static int KalanAracBulma(int mevcutArac, int girenArac, int cikanArac, int saat)
		{
			int fark = girenArac - cikanArac;
			for (int i = 0; i < saat; i++)
			{
				mevcutArac += fark;
			}
			return mevcutArac;
		}
	}
}
