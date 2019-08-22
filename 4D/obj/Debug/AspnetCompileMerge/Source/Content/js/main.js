$(function(){
	$('.loader').fadeOut(1000);

	// Click to redirect page
	$('[data_href]').click(function(){
		window.location.href = $(this).attr('data_href');
	});

	// Stop redirect function above if detect got link in data_href box
	$('[data_href] a').click(function(e){
		e.stopPropagation();
	});

	// Scroll to top function
	$("a[href='#top']").click(function(e) {
		e.preventDefault();
		$("html, body").animate({ scrollTop: 0 }, "slow");
		return false;
	});

	// Detect user scroll website and show back to top button
	$(window).scroll(function (event) {
	    var scroll = $(window).scrollTop();

	    if(scroll >= 300)
	    	$('.top_btn:not(.show)').addClass('show');
	    else
	    	$('.top_btn.show').removeClass('show');
	});
})