
var sayi=10;
var sehir="Tekirdağ";

let sayi2=11;// "let" Tekrar Tanımlanamaz kuralcı değişken yapısını oluşturur.

const piSayisi=3.14; // İçeriği daha sonradan değiştirilemeyen bir kez tanımlanabilir değişken tipleri
const IpAdresim="192.168.1.1";

let nesne= document.getElementById("sehirGelecek").innerHTML=sehir;


function RenkDegistir()
{
    var renkKodu=document.getElementById("renk").value;
    document.getElementById("sehirGelecek").style.color=renkKodu;
    var deger= document.getElementById("sayiUlas").style;

    console.log(deger);
}



var btnRenkUygula=document.getElementById("btnRenkUygula");
btnRenkUygula.addEventListener("click",RenkDegistir);

function Gizle(){
    document.getElementById("gizleBunu").style.display="none";

}
function Goster(){
    document.getElementById("gizleBunu").style.display="block";

}


function Hesapla(){
    var sayi1=parseInt(document.getElementById("sayibir").value);
    var sayi2=parseInt(document.getElementById("sayiiki").value);
    var ortalama=(sayi1+sayi2)/2;
    
    if(ortalama<50){
        document.getElementById("h1Sonuc").style.color="red";
    }
    else {
        document.getElementById("h1Sonuc").style.color="green";
    }
    document.getElementById("h1Sonuc").innerHTML=ortalama;
}

//1. Yontem #######################################3
function FunctionOrnek1(){
   console.log("Merhaba 1");
}
FunctionOrnek1(); // Fonksiyonu Çağırma

//2. Yöntem #######################################3
var SelamFunct=function FunctionOrnek2(){
    console.log("Merhaba 2");
}
SelamFunct();// Fonksiyonu Çağırma

//3. Yöntem #######################################3
const FunctionCagirma3= () => console.log("Merhaba 3");
FunctionCagirma3();// Fonksiyonu Çağırma

//3.Yöntem Parametreli ############################3
const FunctionCagirma3Parametreli= (mesaj) => console.log("Mesajınız: "+mesaj);
FunctionCagirma3Parametreli(" Mesaj Bilgisi");// Fonksiyonu Çağırma
