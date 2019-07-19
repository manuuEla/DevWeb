var first = prompt('What is the first number?');
var second = prompt('What is the second number?');
var third = prompt('What is the third number?');
var vect = [first, second, third];
/*To find the lower/higher value of array */
vect.sort(function(a,b) {return a - b})
document.write('The largest number beetwen ', first,',',second, ',', third, ' is ', vect[0]);