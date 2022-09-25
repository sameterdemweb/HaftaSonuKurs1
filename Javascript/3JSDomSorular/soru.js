//Soru 1: Dışardan girilen birinci ve ikinci sayı arasındaki tam sayıların çarpımını bulan fonksiyonu yazınız

function CarpmaIslemi() {
    var sayi1 = parseInt(document.getElementById("sayibir").value);
    var sayi2 = parseInt(document.getElementById("sayiiki").value);
    var carpim = 1;
    sayi1++;
    for (i = sayi1; i < sayi2; i++) {
        carpim *= i;
    }

    var sonuch1 = document.getElementById("sonuc");
    sonuch1.innerHTML = carpim;
}

var islem = document.getElementById("hesapla");
islem.addEventListener("click", CarpmaIslemi);

function OrtalamaHesapla() {
    var vize = parseInt(document.getElementById("vize").value);
    var final = parseInt(document.getElementById("final").value);
    var ort = (vize + final) / 2;
    var durum = "";

    if (ort < 55) {
        durum = "Kaldı.";

    }
    else if (ort >= 70) {
        durum = "Geçti.";
    }
    else {
        durum = "Büte Kaldı.";
    }
    var sonuch2 = document.getElementById("Notsonuc");
    sonuch2.innerHTML = "Öğrencinin Sınıfı Geçme Durumu: " + durum + " Ögrencinin ortalaması: " + ort;
}
var ortalama = document.getElementById("NotHesapla");
ortalama.addEventListener("click", OrtalamaHesapla);


function SayiBul() {
    var sayi1 = parseInt(document.getElementById("sayi1").value);
    var sayi2 = parseInt(document.getElementById("sayi2").value);
    var sayi3 = parseInt(document.getElementById("sayi3").value);
    var enKucukSayi = 0;
    if (sayi1 < sayi2 && sayi1 < sayi3) {
        enKucukSayi = sayi1;
    }
    else if (sayi2 < sayi1 && sayi2 < sayi3) {
        enKucukSayi = sayi2;
    }
    else if (sayi3 < sayi1 && sayi3 < sayi2) {
        enKucukSayi = sayi3;
    }
    else {
        enKucukSayi = "Sayılar Eşit"
    }
    var sonuch3 = document.getElementById("enKucukSonuc");
    sonuch3.innerHTML = "girmiş olduğunuz en küçük sayı: " + enKucukSayi
}
var islem = document.getElementById("SayiBul");
islem.addEventListener("click", SayiBul);

function Urunler() {
    var urunAd = document.getElementById("urunAd").value;
    var urunAdet = parseInt(document.getElementById("urunAdet").value);
    var urunFiyat = parseInt(document.getElementById("urunFiyat").value);

    var fiyatToplam = urunAdet * urunFiyat;

    var ekranYazdırma = document.getElementById("UrunSonuc");
    ekranYazdırma.innerHTML = "Girmiş olduğunuz " + urunAd + " adlı ürünü" + urunAdet + " adet, " + urunFiyat + " fiyattan aldığınızda toplam " + fiyatToplam + " kadar ödersiniz.";

}
var UrunHesap = document.getElementById("UrunHesap");
UrunHesap.addEventListener("click", Urunler);

function YukHesapla() {
    var tasınanKg = parseInt(document.getElementById("urunKg").value);
    var tasınanYukseklik = parseInt(document.getElementById("tasinacakYukseklik").value);
    var dokulenkum = parseInt(document.getElementById("dokulenKg").value);

    var kalankummiktari = tasınanKg - (dokulenkum * tasınanYukseklik);

    var kumSonuc = document.getElementById("kumSonuc");
    kumSonuc.innerHTML = tasınanKg + " kg kum yüklenen bir vincin metrede " + dokulenkum + " Kg kum dökülerek, " + tasınanYukseklik + " metre yüksekliğe çıktığında kalan kum " + kalankummiktari;

}

function YukHesaplaYuzde() {
    var tasinanKg = parseInt(document.getElementById("urunKg").value);
  
    var tasinanYukseklik = parseInt(document.getElementById("tasinacakYukseklik").value);
    var dokulenkum = parseInt(document.getElementById("dokulenKg").value);
    
    var ilkYuklenenKg=tasinanKg;
    for(i=1;i<=tasinanYukseklik;i++){
      var herMetredeDokulenkum  =(tasinanKg/100)*dokulenkum;
      tasinanKg-=herMetredeDokulenkum;
    }

    var kumSonuc = document.getElementById("kumSonuc");
    kumSonuc.innerHTML = ilkYuklenenKg + " kg kum yüklenen bir vincin metrede %" + dokulenkum + " Kg kum dökülerek, " + tasinanYukseklik + " metre yüksekliğe çıktığında kalan kum " + tasinanKg;

}
var kumHesap =document.getElementById("kumHesap");
kumHesap.addEventListener("click",YukHesapla);

var kumHesapYuzde =document.getElementById("kumHesapYuzde");
kumHesapYuzde.addEventListener("click",YukHesaplaYuzde);