$(function () {

    var scrollY;

    // 상단바 고정
    //$(window).on('scroll', function () {
    //    var headerH = $('.title_wrap').height();
    //    var scrollH = $(window).scrollTop();

    //    if (scrollH >= headerH) {
    //        $('.page_title').addClass('fixed');
    //    } else {
    //        $('.page_title').removeClass('fixed');
    //    }
    //});

    // 상단바 고정
    $(window).on('scroll', function () {
        var headerH = $('#header').height();
        var scrollH = $(window).scrollTop();

        if (scrollH >= headerH) {
            $('#header').addClass('fixed');
        } else {
            $('#header').removeClass('fixed');
        }
    });

    // 전체메뉴
    $('.btn_allmenu').on('click', 'a', function (e) {
        e.preventDefault();

        openPopup('.allmenu_wrap');
    });
    $('.allmenu_wrap').on('click', '.allmenu_close', function (e) {
        e.preventDefault();

        $(this).closest('.allmenu_wrap').hide();
        closePopup();
    });

    $('.popup_wrap .popup_close, .popup_wrap .btn_close').on('click', function (e) {
        e.preventDefault();

        $(this).closest('.popup_wrap').hide();
        closePopup();
    });

    // 페이지 이동
    if ($("#tab").val() === "branch") {
        galleryTop.slideTo(2, 1000);
    }

    // 이벤트 키비 슬라이드
    //var eventSwiper = new Swiper('.swiper-event', {
    //    speed: 400,
    //    spaceBetween: 100,
    //    loop: true,
    //    pagination: {
    //        el: '.pagination',
    //        clickable: true
    //    },
    //});

    // 200702 수정 시작
    // 이벤트 배너 업적
    //var eventbtSwiper = new Swiper('.swiper_event_bottom', {
    //    autoHeight: true,
    //    speed: 600,
    //    loop: true,
    //    autoplay: true
    //});
    // 200702 수정 끝

    // 탭 영역
    //var galleryThumbs = new Swiper('.tab_list', {
    //    allowTouchMove: false,
    //    slidesPerView: 3,
    //    speed: 600
    //});
    //var galleryTop = new Swiper('.tab_cont_wrap', {
    //    autoHeight: true,
    //    slidesPerView: 1,
    //    thumbs: {
    //        swiper: galleryThumbs
    //    }
    //});

    // 200702 수정 시작
    // 탭 영역 - 업적
    //var galleryThumbsA = new Swiper('.rank_wrap .tab_list.type01', {
    //    allowTouchMove: false,
    //    slidesPerView: 1,
    //    speed: 600
    //});
    //var galleryTopA = new Swiper('.rank_wrap .tab_cont_wrap.type01', {
    //    autoHeight: true,
    //    slidesPerView: 1,
    //    thumbs: {
    //        swiper: galleryThumbsA
    //    }
    //});

    //var galleryThumbsB = new Swiper('.rank_wrap .tab_list.type02', {
    //    allowTouchMove: false,
    //    slidesPerView: 2,
    //    speed: 600
    //});
    //var galleryTopB = new Swiper('.rank_wrap .tab_cont_wrap.type02', {
    //    autoHeight: true,
    //    slidesPerView: 1,
    //    thumbs: {
    //        swiper: galleryThumbsB
    //    }
    //});

    //var galleryThumbsC = new Swiper('.rank_wrap .tab_list.type03', {
    //    allowTouchMove: false,
    //    slidesPerView: 3,
    //    speed: 600
    //});
    //var galleryTopC = new Swiper('.rank_wrap .tab_cont_wrap.type03', {
    //    autoHeight: true,
    //    slidesPerView: 1,
    //    thumbs: {
    //        swiper: galleryThumbsC
    //    }
    //});
    // 200702 수정 끝

    // 룰렛 영역
    function roulette() {
        var gift;
        var roulette = $(".roulette");
        //var rotationPos = new Array(60,120,180,240,300,360);
        var rotationPos = new Array(30, 90, 150, 210, 270, 330);
        var clicked = 0;

        function iniGame(num) {
            gift = num;
            TweenLite.killTweensOf(roulette);
            TweenLite.to(roulette, 0, { css: { rotation: rotationPos[gift] } });
            TweenLite.from(roulette, 5, { css: { rotation: -3000 }, onComplete: endGame, ease: Sine.easeOut });
            // console.log("gift 숫자 : "+ (gift +1) +"rotationPos:" + rotationPos );
        }

        function endGame() {
            if (gift == 0 || gift == 2 || gift == 4) {
                openPopup('.popup_fail');
            } else {
                openPopup('.popup_winning');

            }
            var result = $("#result").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/api/roulette/play",
                data: JSON.stringify({ "result": result }),
                dataType: "json",
                async: false,
                success: function (json) {
                    if (json.result !== "SUCCESS") {
                        alert("정상적으로 참여되지 않았습니다.");
                        return false;
                    } else {
                    }
                },
                error: function (jqxhr, status, error) {
                    var err = "[" + jqxhr.status + "] " + jqxhr.statusText;
                    alert("오류가 발생했습니다.\n새로고침 후 다시 시도해주세요.\n" + err);
                }
            });
        }

        $('.btn_roulette').on('click', function (e) {
            var result = $("#result").val();
            if (result === "EXISTS") {
                clicked = 1;
            }
            if (clicked <= 0) {

                var array = [], ran = 0;
                if (result === "FAIL") {
                    array = [0, 2, 4];
                } else {
                    array = [1, 3, 5];
                }

                ran = Math.floor(Math.random() * array.length);
                iniGame(array[ran]);

                //iniGame(Math.floor(Math.random() * 6));

            } else if (clicked >= 1) {
                e.preventDefault();
                alert('룰렛이벤트는 1일 1회참여입니다.');
            }
            clicked++;
        });
    }
    roulette();

    // UCC 영역
    //$('.ucc_box .img').on('click', 'a', function (e) {
    //    e.preventDefault();

    //    var url = $(this).data('video');
    //    $('.popup_ucc .video_box iframe').attr('src', url);
    //    openPopup('.popup_ucc');
    //});

    //$('.popup_ucc').on('click', '.popup_close', function (e) {
    //    $('.popup_ucc .video_box iframe').attr('src', '');
    //    closePopup('.popup_ucc');
    //});
    });

// 팝업
function openPopup(obj) {
    scrollY = $(window).scrollTop();

    $('html, body').css({ top: -scrollY }).addClass('scroll-fiexd');
    $('.wrapper').prepend('<div class="dimm"></di>');
    $(obj).show();
}

function closePopup() {
    $('html, body').removeAttr('style').removeClass('scroll-fiexd');
    $('.dimm').remove();

    $(window).scrollTop(scrollY);
}