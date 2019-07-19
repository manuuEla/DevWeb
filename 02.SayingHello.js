function myFunction(){ 
   /*
   1) var nume=window.prompt("Care este numele tau?");
    var hei ="Buna, " + nume + ", imi pare bine sa te cunosc!";
    window.alert(hei); */

   /* 
   2) var nume = window.prompt('Care este numele  tau?');
    document.write('Buna, ' +  nume + " imi pare bine sa te cunosc!" )
    */

   /* 
   3) document.write("Buna, " + document.getElementById('nume').value + ", imi pare bine sa te cunosc!"); */

/*verificare tip de nume: scurt/mediu/lung */
 var nume=document.getElementById("nume").value;
 var div=document.createElement('div');
 var textNod= document.createTextNode(hei);
 div.appendChild(textNod);
 document.body.appendChild(div);
}
  function verificare(){
      var nume= document.getElementById('nume').value;
      if(nume.length < 3){
      hei = 'Buna, ' + nume+ ', imi pare bine sa te cunosc!...Ai un nume scurt'+ ' care are '+ nume.length+ ' caractere.';
      myFunction();
  } 
  else if (nume.length >=4 & nume.length<=8){
      hei= 'Buna, ' + nume+ ', imi pare bine sa te cunosc!...Ai un nume mediu'+ ' care are '+ nume.length+ ' caractere.';
      myFunction();
  }
  else if(nume.length >9){
      hei='Buna, '+ nume + ', imi pare bine sa te cunosc!...Ai un nume lung'+ ' care are '+ nume.length+ ' caractere.';
      myFunction();
  }


  }
  function refresh(){
    window.location.reload();
  }