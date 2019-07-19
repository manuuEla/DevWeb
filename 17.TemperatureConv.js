function Convert(){
 var choice = prompt('What is your choice?(F/C)');
 var chUpp = choice.toUpperCase();
 document.getElementById('choice').value = chUpp;
    if(chUpp == 'F'){
  var far = prompt('Please enter the temperature in Celsius:');
  if(isNaN(far) || far < 0 ){
      window.alert('Enter ONLY numbers.');
      location.reload();
  }
  var F = (far * 9 / 5 ) + 32;
      document.getElementById('output').innerHTML='The temperature in '  +  chUpp + ' is ' + F;
  }
    else {
  var cel = prompt('Please enter the temperature in Fahrenheit:');
  if(isNaN(cel) || cel < 0 ){
    window.alert('Enter ONLY numbers.');
    location.reload();
  var C = (cel - 32) * 5 / 9;
  document.getElementById('output').innerHTML='The temperature in ' + chUpp + ' is ' + C;
 }
}
}
