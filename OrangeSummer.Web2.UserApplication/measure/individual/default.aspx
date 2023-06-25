<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.individual._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer guide individual">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual" class="current">개인 부문</a></li>
                        <li><a href="/measure/sl">SL 부문</a></li>
                        <li><a href="/measure/point">지점 부문</a></li>
                        <li><a href="/measure/group">그룹부문</a></li>
                    </ul>
				<!-- 개인부문 -->
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span>|</span></dt>
						<dd>FC, G SL, S SL, E SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span>|</span></dt>
						<dd>시책 기간 내 <strong>환산 CANP 순위</strong></dd>
						<dd><strong class="purple">순위</strong> 환산 CANP 평가  <strong class="purple">필수기준</strong>  CMIP 평가</dd>
					</dl>
					<dl>
						<dt>선발 인원<span>|</span></dt>
						<dd>상위 800명</dd>
					</dl>
				</div>
				<div class="mandatory_standards">
					<dl>
						<dt>필수조건 01</dt>
						<dd><strong>7~8월</strong>각 월 CMIP 30만 ↑<br/>or 환산 CANP 150만 ↑</dd>
					</dl>
					<dl class="two">
						<dt>필수조건 02</dt>
						<dd><strong>7~8월</strong>건수 7건 ↑<br/>(신인부문 5건 ↑)</dd>
					</dl>
				</div>
				<!--ul>
					<li>관리자<span>ㅣ</span></li>
					<li>view 43<span>ㅣ</span></li>
					<li>21-07-11</li>
				</ul-->
				<div class="measureCon first">
					<p class="Con_t">TRIPLE</p>
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd><em>1-30</em> 위</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >750</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area">제주+푸켓</dd>
						</dl>
						<dl>
							<dt>② 현금</dt>
							<dd><em>100만</em></dd>
						</dl>
					</div>
				</div>
					
				<div class="measureCon">
					<p class="Con_t">DOUBLE</p>
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd><em>31-200</em> 위</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >500</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area">제주+푸켓</dd>
						</dl>
						<dl>
							<dt>② 현금</dt>
							<dd class="blank">-</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon last">
					<p class="Con_t">일반</p>
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd><em>201-800</em> 위</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >250</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area one">푸켓</dd>
						</dl>
						<dl>
							<dt>② 현금</dt>
							<dd class="blank">-</dd>
						</dl>
					</div>
				</div>
				
				<div class="measureCon last">
					<p class="Con_t">신인</p>
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd>상위 <em>30</em> 명</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >200</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area one">푸켓</dd>
						</dl>
						<dl>
							<dt>② 현금</dt>
							<dd class="blank">-</dd>
						</dl>
					</div>
				</div>

			</div>
		</div>
				
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
