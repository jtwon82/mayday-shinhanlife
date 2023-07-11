<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.board.scrach._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<link rel="stylesheet" href="/resources/css/sub.css" />
<link rel="stylesheet" href="/resources/css/swiper.css" />
<script type="text/javascript" src="/resources/js/swiper3.js"></script>
<script type="text/javascript" src="/resources/js/wScratchPad.min.js"></script>
<script type="text/javascript" src="/resources/js/common.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
<body>
	<!-- 7월 : july / 8월 : august 로 클래스 명 변경하시면 됩니다 -->
	<div id="sub_wrap" class="subMeta06 july">
		<div id="header">
		    <h1 class="logo"><a href="/"><img src="/resources/img/index/index_logo.png" alt="ShinhanLife" /></a></h1>
		    <p class="homeBtn"><a href="/"><img src="/resources/img/index/index_homeIcon.png" alt="ShinhanLife" /></a></p>

  			<header class="cf" id="hd">
				<div id="hd_wr">
					<div class="btn"></div>
					<div class="page_cover"></div>
					<div id="menu">
						<div class="person_info">
							<p class="person_img"><img src="/resources/img/index/main_person_img2.png" onerror="this.src='/resources/img/index/person_img2.jpg'" alt=""/>
							</p>
							<p class="rank">
								<span>강남지점</span>손석구 / FC
							</p>
							<ul class="editBtn">
								<li>
									<a href="/signup_edit.html">내 정보 수정하기</a>
								</li>
								<li>
									<a id="ContentPlaceHolder2_menu_btnLogout" class="btn_logout" href="javascript:alert('logout')">로그아웃</a>
								</li>
							</ul>
						</div>

						<div class="close"></div>
						<ul id="mainMenu">
							<li>
								<a href="/measure_list.html">시책 안내</a>
							</li>
							<li>
								<a href="/bm.html">SUMMER 업적</a>
							</li>
							<li>
								<a href="/ranking.html">SUMMER 랭킹</a>
							</li>
							<li>
								<a href="/ranking_point.html">NSM 부문</a>
							</li>
							<li>
								<a href="/notice.html">공지사항</a>
							</li>
							<li>
								<a href="/event.html">이벤트</a>
							</li>
						</ul>
					</div>
				</div>
			</header>
		</div>
		<div class="subContainer">
			<div class="eventPage" id="scratcEvent">
				<h3 class="title"></h3>
				<div class="info_">
					<ul>
						<li><span>이벤트기간</span>2023년 7월 10일 ~ 8월 31일 까지</li>
						<li><span>이벤트경품</span>썸머 기간 커피쿠폰 총 1,500명<br>랜덤 추첨 증정</li>
					</ul>
					<div class="scratchpad"></div>
				</div>
				<script>
					var result = "win" //꽝=lose, 당첨=win
					var scratchEnd = false;
					var resultBg;
					if(result == "lose")resultBg = "/resources/img/sub/event/scratch_pad_lose.png";
					if(result == "win")resultBg = "/resources/img/sub/event/scratch_pad_win.png";
					$('.scratchpad').wScratchPad({
						size : 30,
						bg : resultBg,
						fg : '/resources/img/sub/event/scratch_pad_default.png',
						scratchMove : function(e, percent) {
							if (percent > 30 && scratchEnd == false) {
								this.clear();
								this.scratch = false;
								completeScratch();
							}
						}
					});
					function completeScratch(){
						scratchEnd = true;
						setTimeout(function(){
							if(result == "lose")openPopup('.popup_fail');
							if(result == "win")openPopup('.popup_winning');
						}, 1000);
					}
				</script>
			</div>
		</div>
				
	</div>
	<!-- popup -->
	<div class="popup_wrap popup_winning">
		<div class="popup_inner scratch">
			<div class="popup_container">
				<div class="popup_title">
					<p class="date">2023.07.10<br>홍길동 님</p>
					<p class="main_txt">당첨되셨습니다!</p>
					<p class="sub_txt">축하드립니다. <br><span>커피쿠폰</span>에 당첨되셨습니다.</p>
				</div>
			</div>
			<button class="popup_close">
				<img src="/resources/img/sub/event/scratch_popup_close.png" alt="닫기">
			</button>
		</div>
	</div>

	<div class="popup_wrap popup_fail">
		<div class="popup_inner scratch">
			<div class="popup_container">
				<div class="popup_title">
					<p class="main_txt">꽝</p>
					<p class="sub_txt"><span>다음 기회</span>에 도전하세요.</p>
			</div>
			<button class="popup_close">
				<img src="/resources/img/sub/event/scratch_popup_close.png" alt="닫기">
			</button>
		</div>
	</div>
	<!-- //popup -->

</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
