function retirement(){
    var age = document.getElementById('varsta').value;
    var ret = document.getElementById('pensionare').value;
    var ageInput = parseInt(age);
    var retInput = parseInt(ret);
    var yearLeft = retInput - ageInput;
    var data = new Date().getFullYear();
    var anRet = data + yearLeft;
    var pensionat = ageInput - retInput;
    if(isNaN(ageInput) || isNaN (retInput) || ageInput < 0 || retInput <0 ){
        document.getElementById('output').innerHTML='Introduceti date valide si pozitive!';
    } else if(isNaN(ageInput)|| isNaN(retInput) || ageInput > retInput) { 
        document.getElementById('output').innerHTML= 'Felicitari, ai ' + pensionat + ' de ani ' + ' de cand  esti pensionat/a. ';
    } else {
    document.getElementById('output').innerHTML= 'Mai ai ' + yearLeft + ' de ani ' + ' pana la pensionare. ' +  '</br>' + 'Suntem in ' + data + ' , asa ca te poti pensiona in ' +  anRet + '.';
}
}
function refresh(){
    window.location.reload();
}