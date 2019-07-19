function ariaCalc(){
    var length = document.getElementById('length').value;
    var width = document.getElementById('width').value;
    var lenghtParse = parseInt(length);
    var widthParse = parseInt(width);
    var ariaFeet = lenghtParse * widthParse;
    const feetToMeters = 0.09290304;
    var metri = ariaFeet*feetToMeters;
    if(isNaN(lenghtParse) || isNaN(widthParse) || lenghtParse < 0 || widthParse < 0 ){
        document.getElementById('output').innerText ='Introduceti DOAR valori numerice pozitive'; 
    } else {
        document.getElementById('output').innerHTML='Ai introdus dimensiunile: ' + lenghtParse+ ' feet si '+ widthParse + ' feet.'+ '</br>' + 'Aria este de ' + ariaFeet +  ' square feet ' + '</br>' + metri.toFixed(3) + ' de metri patrati. ';

}
function refresh (){
    window.location.reload();
}
}