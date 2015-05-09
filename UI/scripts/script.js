$(document).ready(function() {
   
	$('.mainBody').css('min-height',eval($(window).height() - $('.head').height() - $('.footer').height() -20));

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
    var pageClass = (!$('#topnav li').first().hasClass('active')) ? 'innerPage' :  'homePage' ;
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
	
	//Poll
 	 $('.pollCont button').prop('disabled', 'disabled').addClass('disabled');
      
      $('.pollCont input[name="Response"]').click(function(){
           $('.pollCont button').prop('disabled', '').removeClass('disabled');
			 $('.pollCont input[name="Response"]').parent().removeClass('selected');
			 $(this).parent().addClass('selected');
      });

      //Generate Poll Result Graph on vote button click
      $('.pollButtonCont input[type="submit"]').click(function(e){
        e.preventDefault();
        var form = $(this).closest('form');
        showPollResult(form);
      });
     
      //If user has already voted
      if($('.pollQuestionCont').length == 0){
        $('.pollResultCont').html("Loading Poll Result...").removeClass('hide');
        var form = $('.pollCont form');
        showPollResult(form)
      }

       //Generate Poll Result Graph
      function showPollResult(form){
        var formUrl = $(form).attr('action');
        
        $.ajax({
            url:formUrl,
            dataType:'json',
            data:$(form).serialize(),
            type:"POST",
            beforeSend:function(){
              $('.pollResultCont').html("Loading Poll Result...").removeClass('hide');
              $('.pollCont input[type="submit"]').prop('disabled', 'disabled').addClass('disabled');
            },
            success: function(data, status, xhr) {
              	var res = "", percent = [] ;
				$.each(data.pollAnswer, function(index, value) {
					percent[index] = eval((100*data.pollAnswer[index].votes)/data.totalVotes);
					
					res+= '<li id="pollQuest'+index+'"><div class="pollQ">'+data.pollAnswer[index].answer+'</div><div class="pollQGraph"><span>'+data.pollAnswer[index].votes+'</span></div></li>';
				});
				$('.pollQuestionCont,.pollButtonCont').hide();
				$('.pollResultCont').html(res).removeClass('hide');

				$('.pollQGraph span').each(function(ind){
				    $(this).animate({
				      width:percent[ind]+"%",
				    },1000).css('display','block');
				});
            },
           error: function(err, status, xhr) {
              console.log(err);
           }
        });
      }
      //Poll

});