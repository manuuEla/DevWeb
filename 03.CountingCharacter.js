 /*var input_string = null;
   do{
   input_string = window.prompt('Care este string-ul pe care doriti sa-l numarati?');
}
while(input_string===null);
console.log(input_string + ' = ' + input_string.length + ' caractere.');
document.write(input_string + ' = ' + input_string.length + ' caractere.');*/

var input_string;
function numara(){
    input_string = document.getElementById('count').value;
    rezultat = input_string.length;
    document.getElementById('rezultat'). innerHTML = input_string + " are " + input_string.length + ' caractere.';
    document.getElementById('counter').value = result;

}
 function isEmpty(){
     if(document.getElementById('count').value==''){
         document.getElementById('rezultat').innerHTML = 'Introdu un string.';
     }return;
 }
function startTimer(){
    setTimeout('numara()', 1000);
}