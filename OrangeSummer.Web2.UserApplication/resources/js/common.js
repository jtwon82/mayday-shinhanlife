$(document).ready(function(){
	$(".btn").click(function() {
		$("#menu, html, .page_cover").addClass("open");
	});
	
	$(".close, .page_cover").click(function() {
		$("#menu, .page_cover, html").removeClass("open");
	});
	$("#certiBtn").click(function() {
		$(".certiCheck").show();
	});

	$(".moreBtn").click(function() {
		$(".charge_table.moreCon").show();
		$(this).hide();
	});
	
	//init();
	//init2();

	//$(".newfc").css({
	//	"font-size" : "37px",
	//	"color" : "#fff",
	//	"font-family" : 'OneShinhanB'
	//});

	//$(".new_fc").css({
	//	"margin-top" : "10px"
	//});

});

//// 팝업
//function openPopup(obj) {
//	scrollY = $(window).scrollTop();

//	$('html, body').css({top:-scrollY}).addClass('scroll-fiexd');
//	$('.popup_wrap').prepend('<div class="dimm"></di>');
//	$(obj).show();
//}
//function closePopup() {
//	$('html, body').removeAttr('style').removeClass('scroll-fiexd');
//	$('.dimm').remove();

//	$(window).scrollTop(scrollY);
//}

//$('.popup_wrap .popup_close, .popup_wrap .btn_close').on('click', function(e) {
//	e.preventDefault();

//	$(this).closest('.popup_wrap').hide();
//	closePopup();
//});


// 룰렛 영역
//function roulette() {
//	var gift;
//	var roulette = $(".roulette");
//	//var rotationPos = new Array(60,120,180,240,300,360);
//	var rotationPos = new Array(30,90,150,210,270,330);
//	var clicked  = 0;

//	function iniGame(num) {
//		gift = num;
//		TweenLite.killTweensOf(roulette);
//		TweenLite.to(roulette, 0, {css:{rotation:rotationPos[gift]}});
//		TweenLite.from(roulette, 5, {css:{rotation:-3000}, onComplete:endGame, ease:Sine.easeOut});
//		// console.log("gift 숫자 : "+ (gift +1) +"rotationPos:" + rotationPos );
//	}

//	function endGame(){
//		if (gift == 0 || gift == 2 || gift == 4) {
//			openPopup('.popup_fail');
//		} else {
//			openPopup('.popup_winning');
//		}
//	}

//	$('.btn_roulette').on('click', function(e){
//		if (clicked <= 0){
//			iniGame(Math.floor(Math.random() * 6));
//		} else if (clicked >= 1){
//			e.preventDefault();
//			alert('이미 도전 하셨습니다.');
//		}
//		clicked++;
//	});
//}
//roulette();

// 탭슬라이드
//function init() {
//	$('#tab1').addClass('hover');
//	$('#tab2').click(function() {
//		$('#tab1').removeClass('hover');
//	});
//	try{
//		var swiper = new Swiper('.swiper-containerX', {
//			autoHeight: true,
//			autoplay:false,
//			on: {
//				init: function () {
//					$(".swiper-slide").css("background-color", 'transparent');
//					$(".swiper-slide").css("text-align", 'left');
//					$('#tab1').addClass('hover');
//				},
//				slideChange: function () {
//					var slider = this;
//					if (swiper.activeIndex == 0) {
//						$('#tab1').addClass('active');
//						$('#tab2').removeClass('active');
//						$('#tab3').removeClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
	 
//					} else if (swiper.activeIndex == 1) {
//						$('#tab1').removeClass('active');
//						$('#tab2').addClass('active');
//						$('#tab3').removeClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
	 
//					} else if (swiper.activeIndex == 2) {
//						$('#tab1').removeClass('active');
//						$('#tab2').removeClass('active');
//						$('#tab3').addClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera

//					} 
//				}
//			}
//		});

//	}catch(e){} 
//    $('#tab1').click(function () {
//        swiper.slideTo(0, 300, false);
//    });
//    $('#tab2').click(function () {
//        swiper.slideTo(1, 300, false);
//    });
//    $('#tab3').click(function () {
//        swiper.slideTo(2, 300, false);
//    });
 
//}

//function init2() {
//	$('#tab4').addClass('hover');
//	$('#tab5').click(function() {
//		$('#tab4').removeClass('hover');
//	});
//	try{
//		var swiper2 = new Swiper('.swiper-container2X', {
//			autoHeight: true,
//			autoplay:false,
//			on: {
//				init2: function () {
//					$(".swiper-slide2").css("background-color", 'transparent');
//					$(".swiper-slide2").css("text-align", 'left');
//					$('#tab4').addClass('current');
//				},
//				slideChange: function () {
//					var slider2 = this;
//					if (swiper2.activeIndex == 3) {
//						$('#tab4').addClass('active');
//						$('#tab5').removeClass('active');
//						$('#tab6').removeClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
	 
//					} else if (swiper2.activeIndex == 4) {
//						$('#tab4').removeClass('active');
//						$('#tab5').addClass('active');
//						$('#tab6').removeClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
	 
//					} else if (swiper2.activeIndex == 5) {
//						$('#tab4').removeClass('active');
//						$('#tab5').removeClass('active');
//						$('#tab6').addClass('active');
	 
//						document.body.scrollTop = 0; // For Safari
//						document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera

//					} 
//				}
//			}
//		});

//	}catch(e){} 
//    $('#tab4').click(function () {
//        swiper2.slideTo(0, 300, false);
//    });
//    $('#tab5').click(function () {
//        swiper2.slideTo(1, 300, false);
//    });
//    $('#tab6').click(function () {
//        swiper2.slideTo(2, 300, false);
//    });
 
//}

