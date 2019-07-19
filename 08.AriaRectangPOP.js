    var length = window.prompt('What is the length of the room in feet?');
    var width = window.prompt('What is the width of the room in feet?');
    const metri = 0.09290304;
    var lenParse = parseInt(length);
    var widParse = parseInt(width);
    var ariaFeet = lenParse*widParse;
    var ariaMetri = ariaFeet* metri;
    if(isNaN(lenParse) ||isNaN (widParse) || lenParse <0 ||widParse <0){
       window.alert('Intorduceti DOAR valori numerice si pozitive');
    } else {
        document.write('Ai introdus dimensiunile: ', lenParse, ' feet si ',  widParse ,  ' feet.'+ '</br>' + 'Aria este de ' ,  ariaFeet , ' square feet ' + '</br>' , ariaMetri.toFixed(3) + ' de metri patrati.');
    }
