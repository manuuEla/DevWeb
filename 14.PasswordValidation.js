var storedUN = ['mihai', 'manu', 'damian'];
var storedPW = ['mihai2525', '*651manu', 'damiidam'];
var valid = false;
var usr = prompt('What is your username?');
var pass = prompt('What is the password?');
 for ( var i = 0 ;i <= storedUN.length; i++){
     if( storedPW[i] == pass && storedUN[i]==usr){
         valid = true;
     } 
 } if( valid == false){
     document.write("I don't know you!");
 }else{
     document.write('Welcome!');
 }
