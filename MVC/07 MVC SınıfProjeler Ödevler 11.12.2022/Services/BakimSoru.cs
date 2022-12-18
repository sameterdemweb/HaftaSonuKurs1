namespace MvcOdev.Services
{
    public static class BakimSoru
    {
        public static double Bakim(int calismaSure , int bakimAraligi )
        {
            double kacGunCalisti = calismaSure / bakimAraligi;

            return kacGunCalisti;
        }

        public static double Maliyet(double maliyet , double kacGunBakim)
        {
            double toplamMaliyet = maliyet * kacGunBakim;

            return toplamMaliyet;
        }
    }
}
