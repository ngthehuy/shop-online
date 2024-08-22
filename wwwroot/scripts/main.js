window.awe = window.awe || {};
awe.init = function () {
	awe.showPopup();
	awe.hidePopup();	
};
$(document).ready(function ($) {

	"use strict";
	awe_owl();
	awe_backtotop();
	awe_category();
	awe_menumobile();
	awe_lazyloadImage();
	awe_tab();

	/*Time product_grid_office*/
	$('.dealtop').each(function(e){
		awe_countDown2($(this));
	});
	/*time details deal*/
	$('.dealcount_details').each(function(e){
		awe_countDown($(this));
	});

	$('[data-toggle="tooltip"]').tooltip();
});

$(document).on('click','.overlay, .close-popup, .btn-continue, .fancybox-close', function() {   
	hidePopup('.awe-popup'); 	
	setTimeout(function(){
		$('.loading').removeClass('loaded-content');
	},500);
	return false;
})

/********************************************************
# LAZY LOAD
********************************************************/
function awe_lazyloadImage() {
	setTimeout(function(){
		var i = $("[data-lazyload]");
		i.length > 0 && i.each(function() {
			var i = $(this), e = i.attr("data-lazyload");
			i.appear(function() {
				i.removeAttr("height").attr("src", e);
			}, {
				accX: 0,
				accY: 120
			}, "easeInCubic");
		});
		var e = $("[data-lazyload2]");
		e.length > 0 && e.each(function() {
			var i = $(this), e = i.attr("data-lazyload2");
			i.appear(function() {
				i.css("background-image", "url(" + e + ")");
			}, {
				accX: 0,
				accY: 120
			}, "easeInCubic");
		});
	},1000);
} window.awe_lazyloadImage=awe_lazyloadImage;


/********************************************************
# Countdown
********************************************************/
function awe_countDown(selector){
	// Set the date we're counting down to
	// Kiểu thời gian đặt tag endtime_4/15/2018 15:10:00
	var dataTime = selector.attr('data-time');
	var countDownDate = new Date(dataTime).getTime();
	// Update the count down every 1 second
	var x = setInterval(function() {
		// Get todays date and time
		var now = new Date().getTime();
		// Find the distance between now an the count down date
		var distance = countDownDate - now;
		// Time calculations for days, hours, minutes and seconds
		var days = Math.floor(distance / (1000 * 60 * 60 * 24));
		var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
		var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
		var seconds = Math.floor((distance % (1000 * 60)) / 1000);
		// Display the result in the element
		selector.find('.time-x').html("<span>"+days+"<p>Ngày</p></span><span>:</span>" +"<span>"+hours+"<p>Giờ</p></span><span>:</span>" + "<span>"+minutes+"<p>Phút</p></span><span>:</span>" + "<span>"+seconds+"<p>Giây</p></span>");
		// If the count down is finished, write some text
		if (distance < 0) {
			clearInterval(x);
			selector.hide();
			selector.find('.time-x').html("<span class='a-center block'>Deal hết hạn</span>");
		}
	}, 1000);
}

function awe_countDown2(selector2){
	// Set the date we're counting down to
	// Kiểu thời gian đặt tag endtime_4/15/2018 15:10:00
	var dataTime = selector2.attr('data-time');
	var countDownDate = new Date(dataTime).getTime();
	// Update the count down every 1 second
	var x = setInterval(function() {
		// Get todays date and time
		var now = new Date().getTime();
		// Find the distance between now an the count down date
		var distance = countDownDate - now;
		// Time calculations for days, hours, minutes and seconds
		var days = Math.floor(distance / (1000 * 60 * 60 * 24));
		var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
		var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
		var seconds = Math.floor((distance % (1000 * 60)) / 1000);
		// Display the result in the element
		selector2.find('.time-x').html("<span class='border'>"+days+"<p>Ngày</p></span><span>:</span>" +"<span class='border'>"+hours+"<p>Giờ</p></span><span>:</span>" + "<span class='border'>"+minutes+"<p>Phút</p></span><span>:</span>" + "<span class='border'>"+seconds+"<p>Giây</p></span>");
		// If the count down is finished, write some text
		if (distance < 0) {
			clearInterval(x);
			selector2.find('.wrap_time, .productcount').hide();
			selector2.find('.time-x').html("<span class='dealtext a-center block false'>Deal hết hạn</span>");
		}
	}, 1000);
}


/********************************************************
# SHOW NOITICE
********************************************************/
function awe_showNoitice(selector) {
	$(selector).animate({right: '0'}, 500);
	setTimeout(function() {
		$(selector).animate({right: '-300px'}, 500);
	}, 3500);
}  window.awe_showNoitice=awe_showNoitice;

/********************************************************
# SHOW LOADING
********************************************************/
function awe_showLoading(selector) {
	var loading = $('.loader').html();
	$(selector).addClass("loading").append(loading); 
}  window.awe_showLoading=awe_showLoading;

/********************************************************
# HIDE LOADING
********************************************************/
function awe_hideLoading(selector) {
	$(selector).removeClass("loading"); 
	$(selector + ' .loading-icon').remove();
}  window.awe_hideLoading=awe_hideLoading;

/********************************************************
# SHOW POPUP
********************************************************/
function awe_showPopup(selector) {
	$(selector).addClass('active');
}  window.awe_showPopup=awe_showPopup;

/********************************************************
# HIDE POPUP
********************************************************/

function awe_hidePopup(selector) {
	$(selector).removeClass('active');
}  window.awe_hidePopup=awe_hidePopup;
/********************************************************
# HIDE POPUP
********************************************************/
awe.hidePopup = function (selector) {
	$(selector).removeClass('active');
}


/************************************************/
$(document).on('click','.overlay, .close-popup, .btn-continue, .fancybox-close', function() {   
	awe.hidePopup('.awe-popup'); 
	setTimeout(function(){
		$('.loading').removeClass('loaded-content');
	},500);
	return false;
})

/*Double click go to link menu*/
var wDWs = $(window).width();
if (wDWs < 1199) {
	$('.ul_menu li:has(ul)' ).doubleTapToGo();
	$('.item_big li:has(ul)' ).doubleTapToGo();
}

/********************************************************
# CONVERT VIETNAMESE
********************************************************/
function awe_convertVietnamese(str) { 
	str= str.toLowerCase();
	str= str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g,"a"); 
	str= str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g,"e"); 
	str= str.replace(/ì|í|ị|ỉ|ĩ/g,"i"); 
	str= str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g,"o"); 
	str= str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g,"u"); 
	str= str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g,"y"); 
	str= str.replace(/đ/g,"d"); 
	str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");
	str= str.replace(/-+-/g,"-");
	str= str.replace(/^\-+|\-+$/g,""); 
	return str; 
} window.awe_convertVietnamese=awe_convertVietnamese;


/*JS Bộ lọc*/


/********************************************************
# SIDEBAR CATEOGRY
********************************************************/
function awe_category(){

	$('.nav-category .fa-angle-right').click(function(e){
		$(this).parent().toggleClass('active');
	});
	$('.nav-category .fa-angle-down').click(function(e){
		$(this).parent().toggleClass('active');
	});
} window.awe_category=awe_category;




/********************************************************
# MENU MOBILE
********************************************************/
function awe_menumobile(){
	$('.menu-bar').click(function(e){
		e.preventDefault();
		$('#nav').toggleClass('open');
	});
	$('#nav .fa').click(function(e){		
		e.preventDefault();
		$(this).parent().parent().toggleClass('open');
	});
} window.awe_menumobile=awe_menumobile;

/********************************************************
# ACCORDION
********************************************************/
function awe_accordion(){
	$('.accordion .nav-link').click(function(e){
		e.preventDefault;
		$(this).parent().toggleClass('active');
	})
} window.awe_accordion=awe_accordion;

/********************************************************
# OWL CAROUSEL
********************************************************/
function awe_owl() { 
	$('.owl-carousel:not(.not-thuongdq)').each( function(){
		var xs_item = $(this).attr('data-xs-items');
		var md_item = $(this).attr('data-md-items');
		var lg_item = $(this).attr('data-lg-items');
		var sm_item = $(this).attr('data-sm-items');	
		var margin=$(this).attr('data-margin');
		var dot=$(this).attr('data-dot');
		var nav=$(this).attr('data-nav');
		var height = $(this).attr('data-height');
		var play = $(this).attr('data-autoplay');
		var loop=$(this).attr('data-loop');
		if (typeof margin !== typeof undefined && margin !== false) {    
		} else{
			margin = 30;
		}
		if (typeof xs_item !== typeof undefined && xs_item !== false) {    
		} else{
			xs_item = 1;
		}
		if (typeof sm_item !== typeof undefined && sm_item !== false) {    

		} else{
			sm_item = 3;
		}	
		if (typeof md_item !== typeof undefined && md_item !== false) {    
		} else{
			md_item = 3;
		}
		if (typeof lg_item !== typeof undefined && lg_item !== false) {    
		} else{
			lg_item = 3;
		}
		if (typeof dot !== typeof undefined && dot !== true) {   
			dot= true;
		} else{
			dot = false;
		}
		$(this).owlCarousel({
			loop:loop,
			margin:Number(margin),
			responsiveClass:true,
			dots:dot,
			nav:nav,
			autoplay:play,
			autoplayTimeout:3000,
			autoplayHoverPause:true,
			autoHeight:height,
			responsive:{
				0:{
					items:Number(xs_item),
					margin:15				
				},
				600:{
					items:Number(sm_item),
					margin:15
				},
				1000:{
					items:Number(md_item)				
				},
				1200:{
					items:Number(lg_item)				
				}
			}
		})
	})
} window.awe_owl=awe_owl;


/********************************************************
# BACKTOTOP
********************************************************/
function awe_backtotop() { 
	/* Back to top */
	if ($('#back-to-top').length) {
		var scrollTrigger = 200, // px
			backToTop = function () {
				var scrollTop = $(window).scrollTop();
				if (scrollTop > scrollTrigger) {
					$('#back-to-top').addClass('show');
				} else {
					$('#back-to-top').removeClass('show');
				}
			};
		backToTop();
		$(window).on('scroll', function () {
			backToTop();
		});
		$('#back-to-top').on('click', function (e) {
			e.preventDefault();
			$('html,body').animate({
				scrollTop: 0
			}, 700);
		});
	}
} window.awe_backtotop=awe_backtotop;

/********************************************************
# TAB
********************************************************/
function awe_tab() {
	$(".e-tabs:not(.not-dqtab)").each( function(){
		$(this).find('.tabs-title li:first-child').addClass('current');
		$(this).find('.tab-content').first().addClass('current');

		$(this).find('.tabs-title li').click(function(e){

			var tab_id = $(this).attr('data-tab');
			var url = $(this).attr('data-url');
			$(this).closest('.e-tabs').find('.tab-viewall').attr('href',url);
			$(this).closest('.e-tabs').find('.tabs-title li').removeClass('current');
			$(this).closest('.e-tabs').find('.tab-content').removeClass('current');
			$(this).addClass('current');
			$(this).closest('.e-tabs').find("#"+tab_id).addClass('current');

		});    
	});
} window.awe_tab=awe_tab;
/*Open filter*/
$('.open-filters').click(function(e){
	e.stopPropagation();
	$(this).toggleClass('openf');
	$('.dqdt-sidebar').toggleClass('openf');
});
/********************************************************
# DROPDOWN
********************************************************/
$('.dropdown-toggle').click(function() {
	$(this).parent().toggleClass('open'); 	
}); 
$('.btn-close').click(function() {
	$(this).parents('.dropdown').toggleClass('open');
}); 
$('body').click(function(event) {
	if (!$(event.target).closest('.dropdown').length) {
		$('.dropdown').removeClass('open');
	};
});

/*Bắt lỗi điền giá trị âm pop cart*/
$(document).on('keydown','#qty, .number-sidebar',function(e){-1!==$.inArray(e.keyCode,[46,8,9,27,13,110,190])||/65|67|86|88/.test(e.keyCode)&&(!0===e.ctrlKey||!0===e.metaKey)||35<=e.keyCode&&40>=e.keyCode||(e.shiftKey||48>e.keyCode||57<e.keyCode)&&(96>e.keyCode||105<e.keyCode)&&e.preventDefault()});
/* Cong tru product detaile*/

$(document).on('click','.qtyplus',function(e){
	e.preventDefault();   
	fieldName = $(this).attr('data-field'); 
	var currentVal = parseInt($('input[data-field='+fieldName+']').val());
	if (!isNaN(currentVal)) { 
		$('input[data-field='+fieldName+']').val(currentVal + 1);
	} else {
		$('input[data-field='+fieldName+']').val(0);
	}
});

$(document).on('click','.qtyminus',function(e){
	e.preventDefault(); 
	fieldName = $(this).attr('data-field');
	var currentVal = parseInt($('input[data-field='+fieldName+']').val());
	if (!isNaN(currentVal) && currentVal > 1) {          
		$('input[data-field='+fieldName+']').val(currentVal - 1);
	} else {
		$('input[data-field='+fieldName+']').val(1);
	}
});


$(document).ready(function() {
	$('.btn-wrap').click(function(e){
		$(this).parent().slideToggle('fast');
	});



	/*fix menu sub*/
	jQuery("#nav li.level0 li").mouseover(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul').css({top:0,left:"158px"});
			var offset = jQuery(this).offset();
			if(offset && (jQuery(window).width() < offset.left+300)){
				jQuery(this).children('ul').removeClass("right-sub");
				jQuery(this).children('ul').addClass("left-sub");
				jQuery(this).children('ul').css({top:0,left:"-158px"});
			} else {
				jQuery(this).children('ul').removeClass("left-sub");
				jQuery(this).children('ul').addClass("right-sub");
			}
			jQuery(this).children('ul').fadeIn(100);
		}
	}).mouseleave(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul').fadeOut(100);
		}
	});
});





/*MENU MOBILE*/

$('.menu-bar-h').click(function(e){
	e.stopPropagation();
	$('.menu_mobile').toggleClass('open_sidebar_menu');
	$('.opacity_menu').toggleClass('open_opacity');
});
$('.opacity_menu').click(function(e){
	$('.menu_mobile').removeClass('open_sidebar_menu');
	$('.opacity_menu').removeClass('open_opacity');
});


$('.ul_collections li > .fa').click(function(){
	$(this).parent().toggleClass('current');
	$(this).toggleClass('fa-angle-down fa-angle-up');
	$(this).next('ul').slideToggle("fast");
	$(this).next('div').slideToggle("fast");
});


$(document).ready(function(){

	$(".body_tab .button_show_tab").click(function(){ 
		$('.link_tab_check_click').slideToggle('down');
	});

	$("body header .topbar .login_content").hover(
		function () {
			$("body #menu-overlay").addClass('reveal');
		}, 
		function () {
			$("body #menu-overlay").removeClass("reveal");
		}
	);
});





/**Tab click mobile*/
$(".not-tab").each( function(e){
	/*khai báo cho chức năng dành cho mobile tab*/
	var _this = $(this).find('.wrap_tab .button_show_tab');
	var droptab = $(this).find('.link_tab_check_click');
	$(_this).click(function(){ 
		if ($(droptab).hasClass('opensit')) {
			$(droptab).addClass('closeit').removeClass('opensit');
			$(_this).removeClass('active');
		}else if ($(droptab).hasClass('closeit')) {
			$(droptab).addClass('opensit').removeClass('closeit');
			$(_this).addClass('active');
		}
	});
});





/*** FIX POPUP LOGIN / REGISTER ***/
$(document).mouseup(function(e) {
	var container = $("#login_register");
	if (!container.is(e.target) && container.has(e.target).length === 0) {
		container.fadeOut();
		$('#login_register').modal('hide');
	}
});





/* JS MODULE SECTION RESPONSIVE */
$('.section_base .btn_menu').on('click', function(e){
	e.preventDefault();
	var $this = $(this);
	$this.parents('.section_base .title_top_menu').find('ul').stop().slideToggle();
	$(this).toggleClass('active')
	return false;
});

/*JS CLICK TÀI KHOẢN RESPONSIVE */
var wDH = $(window).height();
if (wDH < 1199) {
	$('.click_account').click(function(){
		e.preventDefault();
		$this.parents('.login_content').find('.ul_account').stop().slideToggle();

	});
}

//*JS carousel chi tiết sp */
$(document).ready(function (e) {
	$("#gallery_02").owlCarousel({
		navigation: true,
		nav: true,
		navigationPage: false,
		navigationText: false,
		slideSpeed: 1000,
		pagination: true,
		dots: false,
		margin: 5,
		autoHeight: true,
		autoplay: false,
		autoplayTimeout: false,
		autoplayHoverPause: true,
		loop: false,
		responsive: {
			0: {
				items: 3
			},
			543: {
				items: 3
			},
			768: {
				items: 3
			},
			991: {
				items: 3
			},
			992: {
				items: 3
			},
			1200: {
				items: 3
			}
		}
	});

	$('#gallery_02 img, .swatch-element label').click(function (e) {
		e.preventDefault();
		var ths = $(this).attr('data-img');
		console.log(ths);
		$('.large-image .checkurl').attr('src', ths);

		$('.large-image .checkurl img').attr('src', ths);

		/*** xử lý active thumb -- ko variant ***/
		var thumbLargeimg = $('.details-product .large-image a').attr('href');
		var thumMedium = $('#gallery_02 .owl-item .item a').find('img').attr('src');
		var url = [];

		$('#gallery_02 .owl-item .item').each(function () {
			var srcImg = '';
			$(this).find('a img').each(function () {
				var current = $(this);
				if (current.children().size() > 0) { return true; }
				srcImg += $(this).attr('src');
			});
			url.push(srcImg);
			var srcimage = $(this).find('a img').attr('src');
			if (srcimage == thumbLargeimg) {
				$(this).find('a').addClass('active');
			} else {
				$(this).find('a').removeClass('active');
			}
		});
	})
});

/* Tab chi tiết sản phẩm */
$(".not-dqtab").each(function (e) {
	$(this).find('.tabs-title li:first-child').addClass('current');
	$(this).find('.tab-content').first().addClass('current');

	$(this).find('.tabs-title li').click(function () {
		if ($(window).width() > 315) {
			if ($(this).hasClass('current')) {
				$(this).removeClass('current');
			} else {
				var tab_id = $(this).attr('data-tab');
				var url = $(this).attr('data-url');
				$(this).closest('.e-tabs').find('.tab-viewall').attr('href', url);

				$(this).closest('.e-tabs').find('.tabs-title li').removeClass('current');
				$(this).closest('.e-tabs').find('.tab-content').removeClass('current');

				$(this).addClass('current');
				$(this).closest('.e-tabs').find("#" + tab_id).addClass('current');
			}
		} else {
			var tab_id = $(this).attr('data-tab');
			var url = $(this).attr('data-url');
			$(this).closest('.e-tabs').find('.tab-viewall').attr('href', url);

			$(this).closest('.e-tabs').find('.tabs-title li').removeClass('current');
			$(this).closest('.e-tabs').find('.tab-content').removeClass('current');

			$(this).addClass('current');
			$(this).closest('.e-tabs').find("#" + tab_id).addClass('current');

		}

	});
});

$(function () {
	//$(".price-filter input").each(function () {
	//	var value = $(this).val();
	//	alert(value);
	//});

	$(".price-filter input").change(function () {
		var value = $(this).val();
		var url = "/ProductList.aspx";

		if (value == "<3") {
			url += "?maxprice=3";
		}
		else if (value == "3-5") {
			url += "?minprice=3&maxprice=5";
		}
		else if (value == "5-10") {
			url += "?minprice=5&maxprice=10";
		}
		else if (value == ">10") {
			url += "?minprice=10";
		}
		else {
			url = url;
		}

		location.href = url;

	});
});