<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.board.evt._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/resources/js/jquery.1.11.0.min.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
<script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
<script type="text/javascript" src="/common/js/jquery-library.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
<link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
<link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
<script type="text/javascript" src="/resources/js/swiper3.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
<script type="text/javascript" src="/resources/js/wScratchPad.min.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
<script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
	<div id="sub_wrap" class="subMeta06 july">
            <uc1:menu runat="server" ID="menu" />

		<div class="subContainer">
			<div class="eventPage" id="scratcEvent">
				<h3 class="title"></h3>
				<div class="info_">
					<ul>
						<li><span>이벤트기간</span>2023년 7월 10일 ~ 8월 31일 까지</li>
						<li><span>이벤트경품</span>썸머 기간 커피쿠폰 총 1,600명<br>랜덤 추첨 증정</li>
					</ul>
					<div class="scratchpad"></div>
				</div>
				<script>
					var result = "<%= _result %>"
					var scratchEnd = false;
					var resultBg;
					if (result != "win") resultBg = "/resources/img/sub/event/scratch_pad_lose.png";
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
						setTimeout(function () {
						    $(".dimmed").show();

							if (result != "") {
							    $.ajax({
							        type: "POST",
							        contentType: "application/json; charset=utf-8",
							        url: "/api/roulette/play",
							        data: JSON.stringify({ "result": result }),
							        dataType: "json",
							        async: false,
							        success: function (json) {
						                if (result != "win") openPopup('.popup_fail');
							            if (result == "win") openPopup('.popup_winning');
							            if (json.result != "SUCCESS") {
							                //alert("정상적으로 참여되지 않았습니다.");
							                return false;
							            }
							        },
							        error: function (jqxhr, status, error) {
							            var err = "[" + jqxhr.status + "] " + jqxhr.statusText;
							            alert("오류가 발생했습니다.\n새로고침 후 다시 시도해주세요.\n" + err);
							        }
							    });
							}
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
					<p class="date"><%=DateTime.Now.ToString("yyyy-MM-dd") %><br><%=OrangeSummer.Common.User.Identify.Name %> 님</p>
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
<style>.hide{display:none;}</style>
<div class='dimmed hide' style="position: fixed; top: 0px; left: 0px; width: 100%; height: 100%; z-index: 100; opacity: 0.5; background-color: rgb(0, 0, 0); "></div>
</body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
