//************************************* */
// TAGNAME İLE HTML NESNELERİNE ULAŞMA !
//************************************* */

// Ul tag name i olan tüm Elemenltlere ulaştım.
var tumListeler=document.getElementsByTagName("ul");
//console.log(tumListeler);

// Ul tag name i olan tüm İLK ELEMENTE ulaştım.
var IlkNesneyeUlas=tumListeler[0];
var tumElemanlar=IlkNesneyeUlas.getElementsByTagName("li");
//console.log(tumElemanlar);


for(i=0;i<tumElemanlar.length;i++){
 //console.log(tumElemanlar[i].innerHTML);
}

//************************************* */
// ClassName İLE HTML NESNELERİNE ULAŞMA !
//************************************* */

var classListeleri=document.getElementsByClassName("AnaSayfaListe");

// Ul tag name i olan tüm İLK ELEMENTE ulaştım.
var ilkClassNesne=classListeleri[0];
var tumElemanlar=ilkClassNesne.getElementsByClassName("Liste");
//console.log(tumElemanlar);


for(i=0;i<tumElemanlar.length;i++){
 //console.log(tumElemanlar[i].innerHTML);
}

//************************************* */
// querySelectorAll İLE HTML NESNELERİNE ULAŞMA ! (Belli bir TAG'in içerisindeki classlara ulaşır.)
//************************************* */

var selectorElemanlar=document.querySelectorAll("li.Liste");

for(i=0;i<selectorElemanlar.length;i++){
   // console.log(selectorElemanlar[i].innerHTML);
   }
   

//************************************* */
// getElementsByName İLE HTML NESNELERİNE ULAŞMA ! (Name Üzerinden Erişim)
//************************************* */

var sayi1Element=document.getElementsByName("sayi1");
var sayi1=parseInt(sayi1Element[0].value);


var sayi2Element=document.getElementsByName("sayi2");
var sayi2=parseInt(sayi2Element[0].value);

//console.log(sayi1+sayi2);

//************************************* */
// getElementById İLE HTML NESNEYE ULAŞMA ! (Id üzerinden BİR Nesneye erişim sağlarız)
//****

var sayim1=document.getElementById("sayibir");
console.log(sayim1);

