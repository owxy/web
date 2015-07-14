
	jQuery(document).ready(function(){
		jQuery(".contact-us").hover(
		  function () {
			jQuery('.contactdrop').fadeIn("fast");
		  },
		  function () {
			jQuery('.contactdrop').fadeOut("fast");
		  }
		);
		
		jQuery('.banner-icon a').each(function(i){
		jQuery(this).click(function(){
			jQuery('.banner-icon a').removeClass("active");
			jQuery(this).addClass("active");
			return false;
		});
		});
		
	});