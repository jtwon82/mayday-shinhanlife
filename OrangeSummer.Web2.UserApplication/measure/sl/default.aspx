<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.sl._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05 measure">
            <uc1:menu runat="server" ID="menu" />
		<div class="subContainer guide sl">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual">개인 부문</a></li>
                        <li><a href="/measure/sl" class="current">SL 부문</a></li>
                        <li><a href="/measure/point">지점 부문</a></li>
                        <li><a href="/measure/group">그룹부문</a></li>
                    </ul>
                    
				<!-- E SL부문 -->
				<div class="titleBox">
					<p class="titleBox_t first">E SL부문</p>
				</div>
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span>|</span></dt>
						<dd>E SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span>|</span></dt>
						<dd>시책 기간 내 <strong>환산 CANP 순위</strong></dd>
					</dl>
				</div>
				
				<div class="measureCon Con1">
					<p class="Con_t">순위 부문</p>
					<div class="mandatory_standards">
						<dl>
							<dt>필수기준</dt>
							<dd>
								<strong>7월 – 8월 2명 이상 팀 도입</strong><br/>
								(9월 – 10월 위촉 기준)<br/>
								<span></span>
								팀 내 SUMMER 개인 부문 2명 이상 달성<br/>
								(E SL 본인 포함)</dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>CANP 순위</dt>
							<dd><strong>1-10</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>유럽+다낭</strong></dd>
						</dl>
						<dl>
							<dt>CMIP</dt>
							<dd><strong>7,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>기타</dt>
							<dd>중복 달성 가능 시,<br>
								여행 티켓 사용<br>
								또는 현금 보상</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon Con2">
					<div class="Con">
						<dl>
							<dt>CANP 순위</dt>
							<dd><strong>11-30</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>호주</strong></dd>
						</dl>
						<dl>
							<dt>CMIP</dt>
							<dd><strong>4,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>기타</dt>
							<dd>중복 달성 가능 시,<br>
								여행 티켓 사용<br>
								또는 현금 보상</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon Con3">
					<div class="Con">
						<dl>
							<dt>CANP 순위</dt>
							<dd><strong>31-110</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>다낭</strong></dd>
						</dl>
						<dl>
							<dt>CMIP</dt>
							<dd><strong>2,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>기타</dt>
							<dd>중복 달성 가능 시,<br>
								여행 티켓 사용<br>
								또는 현금 보상</dd>
						</dl>
					</div>
				</div>
					
				<div class="introduction">
					<dt>도입 부문</dt>
					<dd class="purple">10명 이상 도입 시, 달성 확정!</dd>
					<dd>9~10월 위촉 (8~9월 입과) </dd>
					<dd>중복 달성 가능 시,여행 티켓 사용 또는 현금 보상</dd>
				</div>	
				
				
				<!-- G SL부문 -->
				<div class="titleBox">
					<p class="titleBox_t">G SL부문</p>
				</div>
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span>|</span></dt>
						<dd>G SL</dd>
					</dl>
					<dl>
						<dt>선발 인원<span>|</span></dt>
						<dd>환산 CANP <strong>상위 30위</strong></dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd><strong><em>피 도입자 합산</em> CANP 상위 선발</strong><br>(필수: 9~10월 1명이상 직도입)</dd>
					</dl>
				</div>

				<!-- S SL부문 -->
				<div class="titleBox">
					<p class="titleBox_t">S SL부문</p>
				</div>
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span>|</span></dt>
						<dd>S SL</dd>
					</dl>
						<dt>선발 인원<span>|</span></dt>
						<dd>환산 CANP <strong>상위 30위</strong></dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd><strong><em>피 도입자 합산</em> CANP 상위 선발</strong><br>(필수: 9~10월 1명이상 직도입)</dd>
					</dl>
				</div>

			</div>
		</div>
				
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
