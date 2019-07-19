function calculate() {
   var notaPlata = 0 ;
   var procentTips = 0;
   var tips = 0;
   var total = 0;
   var notaPlata = document.getElementById("notaPlata").value;
   var procentTips=document.getElementById("procentTips").value;
   if (isNaN(notaPlata)){
       window.alert("Introduceti o valoare valida! (CIFRE)")
       location.reload();
   }
   else if(notaPlata<0){
       window.alert('Introduceti o valoare pozitiva!')
       location.reload();
   }
   var tips= notaPlata *( procentTips /100);
   if (isNaN(tips)){
       window.alert("Introduceti o valoare valida! (CIFRE)")
       location.reload();
   }
   else if (tips <0){
       window.alert("Introduceti o valoare pozitiva!")
       location.reload();
   }
   var tipsRotunjit = Math.round(tips * 100)/100;
   var notaPlataRotunjita = Math.round(notaPlata * 100) /100;
   total = tipsRotunjit + notaPlataRotunjita; 
   document.getElementById("tipsRotunjit").value=tipsRotunjit;
   document.getElementById("total").value=total;

}