(function($) {

	'use strict';

	// Mean Menu
	$('.mean-menu').meanmenu({
		meanScreenWidth: "992"
	}); 

	 // Others Option For Responsive JS
	 $(".others-option-for-responsive .dot-menu").on("click", function(){
		$(".others-option-for-responsive .container .container").toggleClass("active");
	});
	 
	// Sticky, Go To Top JS
	$(window).on('scroll', function() { 
		// Header Sticky JS 
		if ($(this).scrollTop() >150){  
			$('.navbar-area').addClass("is-sticky");
		}
		else{
			$('.navbar-area').removeClass("is-sticky"); 
		};
	});

	// Go to Top
	$(function(){
		// Scroll Event
		$(window).on('scroll', function(){
			var scrolled = $(window).scrollTop();
			if (scrolled > 600) $('.go-top').addClass('active');
			if (scrolled < 600) $('.go-top').removeClass('active');
		});  
		// Click Event
		$('.go-top').on('click', function() {
			$("html, body").animate({ scrollTop: "0" },  500);
		});
	}); 

	// aos 
	AOS.init({
		disable: function() {
			var maxWidth = 992;
			return window.innerWidth < maxWidth;
		}
	});

	// Language Switcher
	$(".language-option").each(function() {
		var each = $(this)
		each.find(".lang-name").html(each.find(".language-dropdown-menu a:nth-child(1)").text());
		var allOptions = $(".language-dropdown-menu").children('a');
		each.find(".language-dropdown-menu").on("click", "a", function() {
			allOptions.removeClass('selected');
			$(this).addClass('selected');
			$(this).closest(".language-option").find(".lang-name").html($(this).text());
		});
	})

	$('.popup-youtube, .popup-vimeo').magnificPopup({
		disableOn: 300,
		type: 'iframe',
		iframe: {
			markup: '<div class="mfp-iframe-scaler">' +
				'<div class="mfp-close"></div>' + '<iframe width="560" height="315" src="https://www.youtube.com/embed/HHHlvq5MBfg" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>' +
				'</div>'
		},
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,
		fixedContentPos: false
	});


	// Input Plus & Minus Number JS
	$('.input-counter').each(function() {
		var spinner = jQuery(this),
		input = spinner.find('input[type="text"]'),
		btnUp = spinner.find('.plus-btn'),
		btnDown = spinner.find('.minus-btn'),
		min = input.attr('min'),
		max = input.attr('max');
		
		btnUp.on('click', function() {
			var oldValue = parseFloat(input.val());
			if (oldValue >= max) {
				var newVal = oldValue;
			} else {
				var newVal = oldValue + 1;
			}
			spinner.find("input").val(newVal);
			spinner.find("input").trigger("change");
		});
		btnDown.on('click', function() {
			var oldValue = parseFloat(input.val());
			if (oldValue <= min) {
				var newVal = oldValue;
			} else {
				var newVal = oldValue - 1;
			}
			spinner.find("input").val(newVal);
			spinner.find("input").trigger("change");
		});
	}); 

	// Count Time JS
	function makeTimer() {
		var endTime = new Date("november  30, 2025 17:00:00 PDT");			
		var endTime = (Date.parse(endTime)) / 1000;
		var now = new Date();
		var now = (Date.parse(now) / 1000);
		var timeLeft = endTime - now;
		var days = Math.floor(timeLeft / 86400); 
		var hours = Math.floor((timeLeft - (days * 86400)) / 3600);
		var minutes = Math.floor((timeLeft - (days * 86400) - (hours * 3600 )) / 60);
		var seconds = Math.floor((timeLeft - (days * 86400) - (hours * 3600) - (minutes * 60)));
		if (hours < "10") { hours = "0" + hours; }
		if (minutes < "10") { minutes = "0" + minutes; }
		if (seconds < "10") { seconds = "0" + seconds; }
		$("#days").html(days + "<span>Days</span>");
		$("#hours").html(hours + "<span>Hours</span>");
		$("#minutes").html(minutes + "<span>Minutes</span>");
		$("#seconds").html(seconds + "<span>Seconds</span>");
	} 
	setInterval(function() { makeTimer(); }, 300); 

	// Nice Select JS
	$('select').niceSelect();

	// Partner Logo Slider 
	$('.partner-logo-slider').owlCarousel({
		loop: true,
		margin: 21,
		nav: true, 
		dots: false,
		animateOut: 'fadeOut',
		smartSpeed: 500,
		autoplayHoverPause: true,
		autoplay: true,
		autoHeight:true,
		navText: [
            '<i class="ri-arrow-left-line"></i>',   
            '<i class="ri-arrow-right-line"></i>',   
        ], 
		responsive:{
			0:{
				items:2
			},
			520:{
				items:3
			},
			768:{
				items:4
			},
			992:{
				items:5
			},
			1200:{
				items:5
			},
			1700:{
				items:5
			}
		} 
	}); 
	// Soka Has Won Slider 
	$('.soka-has-won-slider').owlCarousel({
		loop: true,
		margin: 30,
		nav: false, 
		dots: true,
		animateOut: 'fadeOut',
		smartSpeed: 500,
		autoplayHoverPause: true,
		autoplay: true,
		autoHeight:true,
		navText: [
            '<i class="ri-arrow-left-line"></i>',   
            '<i class="ri-arrow-right-line"></i>',   
        ], 
		responsive:{
			0:{
				items:1
			},
			520:{
				items:2
			},
			768:{
				items:3
			},
			992:{
				items:4
			},
			1200:{
				items:4
			},
			1700:{
				items:4
			}
		} 
	}); 
	// banner-tow-slider
	$('.banner-tow-slider').owlCarousel({
		loop: true,
		margin: 0,
		nav: false, 
		dots: false,  
		animateOut: 'fadeOut',  
		smartSpeed: 500,
		autoplayHoverPause: true,
		autoplay: true,
		autoHeight:true,
		items:1,
		navText: [
            '<i class="ri-arrow-left-line"></i>',   
            '<i class="ri-arrow-right-line"></i>',   
        ], 
	}); 

	// Banner Three Slider
	$('.banner-three-slider').owlCarousel({
		loop: true,
		margin: 0,
		nav: false, 
		dots: false,  
		animateOut: 'fadeOut',  
		smartSpeed: 500,
		autoplayHoverPause: true,
		autoplay: true,
		autoHeight:true,
		items:1,
	}); 

	// Preloader JS
	$(function() {
		$('body').addClass('loaded');
	});

	// Go to Top JS
	// Scroll Event
	$(window).on('scroll', function(){
		var scrolled = $(window).scrollTop();
		if (scrolled > 300) $('.go-top').addClass('active');
		if (scrolled < 300) $('.go-top').removeClass('active');
	});  

	// Click Event JS
	$('.go-top').on('click', function() {
		$("html, body").animate({ scrollTop: "0" },  500);
	});

	// FAQ Accordion JS
	$('.accordion').find('.accordion-title').on('click', function(){
		// Adds Active Class
		$(this).toggleClass('active');
		// Expand or Collapse This Panel
		$(this).next().slideToggle('fast');
		// Hide The Other Panels
		$('.accordion-content').not($(this).next()).slideUp('fast');
		// Removes Active Class From Other Titles
		$('.accordion-title').not($(this)).removeClass('active');		
	});

	// Date Picker JS
	$('#datetimepicker1').datepicker({
		weekStart: 0,
		todayBtn: "linked",
		language: "es",
		orientation: "bottom auto",
		keyboardNavigation: false,
		autoclose: true
	});

	// Live Auctions Countdown
	$('.live-auctions-countdown').downCount({
		date: '08/27/2025 12:00:00',
		offset: -5
	}, function () {
		alert('WOOT WOOT, done!');
	});

	// Tabs JS
	$('.tab ul.tabs').addClass('active').find('> li:eq(0)').addClass('current');
	$('.tab ul.tabs li').on('click', function (g) {
		var tab = $(this).closest('.tab'), 
		index = $(this).closest('li').index();
		tab.find('ul.tabs > li').removeClass('current');
		$(this).closest('li').addClass('current');
		tab.find('.tab_content').find('div.tabs_item').not('div.tabs_item:eq(' + index + ')').slideUp();
		tab.find('.tab_content').find('div.tabs_item:eq(' + index + ')').slideDown();
		g.preventDefault();
	});

	$('body').append("<div class='switch-box'><label id='switch' class='switch'><input type='checkbox' onchange='toggleTheme()' id='slider'><span class='slider round'></span></label></div>");

})(jQuery);

// function to set a given theme/color-scheme
function setTheme(themeName) {
    localStorage.setItem('soka_theme', themeName);
    document.documentElement.className = themeName;
}
// function to toggle between light and dark theme
function toggleTheme() {
    if (localStorage.getItem('soka_theme') === 'theme-dark') {
        setTheme('theme-light');
    } else {
        setTheme('theme-dark');
    }
}
// Immediately invoked function to set the theme on initial load
(function () {
    if (localStorage.getItem('soka_theme') === 'theme-dark') {
        setTheme('theme-dark');
        document.getElementById('slider').checked = false;
    } else {
        setTheme('theme-light');
      document.getElementById('slider').checked = true;
    }
})();
