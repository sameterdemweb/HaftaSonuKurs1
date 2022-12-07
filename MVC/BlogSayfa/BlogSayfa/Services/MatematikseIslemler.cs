namespace BlogSayfa.Services
{
    public static class MatematikseIslemler
    {
        public static int DogumTarihiBul(int yas)
        {
            int suankiYil=DateTime.Now.Year;
            int dogumYili = suankiYil - yas;
            return dogumYili;
        }
    }
}
