namespace Office.Entities
{
    public class UrunlerForm
    {
        public int Id { get; set; }
        
        public string UrunAdi { get; set; }
       
        public double UrunFiyat { get; set; }
       
        public int UrunAdet { get; set; }
       
        public int UrunVergi { get; set; }
        public double UrunVergiFiyat { get; set; }
        public double GenelToplam { get; set; }
    }
}
