<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.measure.sl._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05 measure lfc">
            <uc1:menu runat="server" ID="menu" />
		<div class="subContainer guide sl">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual">개인 부문</a></li>
                        <li><a href="/measure/sl" class="current">SL 부문</a></li>
                        <li><a href="/measure/point" >지점 부문</a></li>
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
						<dd><strong>순위부문 :</strong>평가 환산P</dd>
						<dd><strong>도입부문 :</strong>도입 인원 5명 이상</dd>
					</dl>
					<dl>
						<dt>선발 인원<span>|</span></dt>
						<dd>상위 50명 + α</dd>
					</dl>
					<dl>
						<dt>특<em class="space"></em>징<span>|</span></dt>
						<dd>개인 부문 & E SL 순위 부문<br>& E SL 도입 부문</dd>
						<dd class="purple">중복 달성 가능</dd>
						<dd class="purple">여행 티켓 사용 or 현금 보상</dd>
					</dl>
				</div>
				
				<div class="measureCon Con1">
					<p class="Con_t">순위 부문</p>
					<div class="mandatory_standards">
						<dl>
							<dt>필수기준</dt>
							<dd>
								<strong>7월 – 8월 1명 이상 팀 도입</strong><br/>
								(2개월, 9월 – 10월 위촉)<br/>
								<span></span>
								단, ‘스페인+방콕’ 및 ‘호주’ 달성자는<br/>
								2명 이상 도입 필수<br/>
								<span></span>
								팀 내 Summer 개인부문 2명 이상 달성<br/>
								(ESL 본인포함)
							</dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>평가 환산P 순위</dt>
							<dd><strong>1-5</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>스페인+방콕</strong></dd>
						</dl>
						<dl>
							<dt>월초P</dt>
							<dd><strong>4,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>구분</dt>
							<dd>
								<strong>팀 합산<br>업적 평가</strong><br>
								(E SL 본인 업적 포함)
							</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon Con2">
					<div class="Con">
						<dl>
							<dt>평가 환산P 순위</dt>
							<dd><strong>6-15</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>호주</strong></dd>
						</dl>
						<dl>
							<dt>월초P</dt>
							<dd><strong>2,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>구분</dt>
							<dd>
								<strong>팀 합산<br>업적 평가</strong><br>
								(E SL 본인 업적 포함)
							</dd>
						</dl>
					</div>
				</div>

				<div class="measureCon Con3">
					<div class="Con">
						<dl>
							<dt>평가 환산P 순위</dt>
							<dd><strong>16-50</strong>위</dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd><strong>방콕</strong></dd>
						</dl>
						<dl>
							<dt>월초P</dt>
							<dd><strong>1,000만↑</strong></dd>
						</dl>
						<dl>
							<dt>구분</dt>
							<dd>
								<strong>팀 합산<br>업적 평가</strong><br>
								(E SL 본인 업적 포함)
							</dd>
						</dl>
					</div>
				</div>
					
				<div class="introduction">
					<dt>도입 부문</dt>
					<dd class="purple">5명 이상 도입 시, 방콕 Trip 달성 확정</dd>
					<dd>9~10월 위촉 (8~9월 입과)  위촉월 환산P 30만원 필수</dd>
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
						<dd>평가 환산P <strong>상위 5명</strong></dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd>
							<strong><em>피 도입자 합산 (본인 업적 제외)</em><br>평가 환산P 상위 5명</strong><br>
							<span><strong>필수</strong>  · 1명↑ 도입 (9~10월 위촉 기준)</span>
							<span>· 월초P 900만 이상</span>
						</dd>
					</dl>
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
						<dd>평가 환산P <strong>상위 5명</strong></dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd>
							<strong><em>피 도입자 합산 (본인 업적 제외)</em><br>평가 환산P 상위 5명</strong><br>
							<span><strong>필수</strong>  · 1명↑ 도입 (9~10월 위촉 기준)</span>
							<span>· 월초P 600만 이상</span>
						</dd>
					</dl>
				</div>

			</div>
		</div>
				
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
