"use strict";

(function () {

   var element = document.getElementById('duck');

// Hidding and showing the duck for a certain interval
  element.addEventListener("click" ,function () {
    var offsetWidth= element.offsetWidth;
    var offsetHeight= element.offsetHeight;
    var w = window.innerWidth;
    var h = window. innerHeight;
     var hidden = false;

// Making the duck appear in different places inside the screen
     setInterval(function(){
    element.style.visibility = hidden ? "visible" : "hidden";
    hidden = !hidden;

     var X= Math.floor(Math.random()*(w));
     var Y= Math.floor(Math.random()*(h));

     if (X >= (w-offsetWidth)) {
         element.style.left= X-element.offsetWidth +"px";
     }else {
       element.style.left= X+"px";
     };

     if (Y >= (h-offsetHeight)) {
         element.style.top=Y-element.offsetHeight +"px";
     }else {
       element.style.top= Y+"px";
     };


  },400);


   }
 );
  console.log(element);

})();
