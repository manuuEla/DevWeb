var key = prompt('Is the car silent when you turn the key?');
var sliK = key.slice(0,1);
var ansK = key.toLowerCase();
if(ansK == 'y'){
    var ansK1 = prompt('Are the battery terminals corroded?');
} if(ansK1=='y'){
    window.alert('Clean terminals and try starting again.');
}else if(ansK1 == 'n'){
    window.alert('Replace cables and try again.');
}
if(ansK == 'n'){
    var ans1 = prompt('Does the car make a clicking noise?');
    if(ans1 == 'y'){
        window.alert('Replace your battery.');
    } else if(ans1 == 'n'){
       var ans2 = window.prompt('Does the car crank up fail to start?');
    } 
}
    if(ans2 == 'y'){
        window.alert('Check apart plug connections.');
    }else if( ans2 == 'n'){
        var ans3 = prompt('Does the engine start and then die? If you say no, the program will out.');
    } 
 if(ans3 == 'y'){
        var ans4 = prompt('Does your car have fuel injection?');
    if(ans4 == 'n'){
        window.alert('Check to ensure the choke is opening and closing.');
    }else if(ans4 == 'y'){
        window.alert('Get it in for service.');
    }
}
