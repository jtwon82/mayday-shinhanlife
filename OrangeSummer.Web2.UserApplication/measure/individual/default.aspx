<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.individual._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05 measure">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer guide individual">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual" class="current">개인 부문</a></li>
                        <li><a href="/measure/sl">SL 부문</a></li>
                        <li><a href="/measure/point">지점 부문</a></li>
                        <li><a href="/measure/group">기타부문</a></li>
                    </ul>
				<!-- 개인부문 -->
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span>|</span></dt>
						<dd>FC, G SL, S SL, E SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span>|</span></dt>
						<dd>시책 기간 내 <strong>평가 환산 CANP 순위</strong></dd>
						<dd class="purple"><strong>순 위 :</strong> 환산 CANP평가</dd>
						<dd class="purple"><strong>필수 기준 :</strong> 원 CMIP평가</dd>
					</dl>
					<dl>
						<dt>선발 인원<span>|</span></dt>
						<dd>상위 1,050명</dd>
					</dl>
					<dl>
						<dt>최소 필수 조건<span>|</span></dt>
						<dd>7월 - 8월, 각 월 CMIP(MI 기준) 30만↑ 또는 </dd>
						<dd>환산 CANP 150만↑</dd>
					</dl>
				</div>
				<!--ul>
					<li>관리자<span>ㅣ</span></li>
					<li>view 43<span>ㅣ</span></li>
					<li>21-07-11</li>
				</ul-->
				<div class="measureCon Con1">
					<p class="Con_t">TRIPLE+</p>
					<div class="Con">
						<dl>
							<dt>평가 CANP 순위</dt>
							<dd><strong>1-50</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>스페인+다낭</strong><br>+ 금5돈</dd>
						</dl>
						<dl>
							<dt>필수조건 01</dt>
							<dd>원 CMIP<br><strong>1,500만↑</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 02</dt>
							<dd><strong>10건 이상</strong><br>7~8월</dd>
						</dl>
					</div>
				</div>
					
				<div class="measureCon Con2">
					<p class="Con_t">TRIPLE</p>
					<div class="Con">
						<dl>
							<dt>평가 CANP 순위</dt>
							<dd><strong>51-200</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>스페인+다낭</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 01</dt>
							<dd>원 CMIP<br><strong>1,100만↑</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 02</dt>
							<dd><strong>10건 이상</strong><br>7~8월</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon Con3">
					<p class="Con_t">Double</p>
					<div class="Con">
						<dl>
							<dt>평가 CANP 순위</dt>
							<dd><strong>201-450</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>호주</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 01</dt>
							<dd>원 CMIP<br><strong>700만↑</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 02</dt>
							<dd><strong>10건 이상</strong><br>7~8월</dd>
						</dl>
					</div>
				</div>
				
				<div class="measureCon Con4">
					<p class="Con_t">일반</p>
					<div class="Con">
						<dl>
							<dt>평가 CANP 순위</dt>
							<dd><strong>451-1,050</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>다낭</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 01</dt>
							<dd>원 CMIP<br><strong>300만↑</strong></dd>
						</dl>
						<dl>
							<dt>필수조건 02</dt>
							<dd><strong>10건 이상</strong><br>7~8월</dd>
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
