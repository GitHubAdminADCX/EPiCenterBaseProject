$(document).ready(function() {
   
   //New Ticker stop on mouseover
   $('#newsTicker marquee').hover(function(){
   		this.stop();
   },
   function(){
   		this.start();
   });

   //Banner 
  $('#banners').cycle({ 
	    fx:     'fade',
	    timeout: 5000,
	    pager:  '#bannerNav',
	    speed: 1000,
	    fit: 0
	});
	
  // Add class to diffrenciate home page and other pages.	
    var pageClass = (!$('#topnav li.active').hasClass('first')) ? 'innerPage' :  'homePage' ;
  	$('body').addClass(pageClass);

// Click Toggle
	$.fn.clickToggle = function(a,b) {
	  var ab=[b,a];
	  function cb(){ ab[this._tog^=1].call(this); }
	  return this.on("click", cb);
	};

  	$('.profileCont .editButton .button').clickToggle(
  		function(){
  			$('.profileCont').find('.label').hide();
  			$('.profileCont').find('.inputField').show();
  		},
  		function(){
  			$(this).attr('type','submit');
  			$('.profileCont').find('.inputField').hide();
  			$('.profileCont').find('.label').show();
  		}
  	);

});