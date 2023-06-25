<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.sl._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05">
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
						<dt>평가 대상<span class="sl_blank">|</span></dt>
						<dd>E SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span class="sl_blank">|</span></dt>
						<dd>팀 합산 업적 평가 ( E SL 본인 업적 포함)</dd>
					</dl>
					<dl>
						<dt>선발 인원<span class="sl_blank">|</span></dt>
						<dd>제주+푸켓 1위-20위, 푸켓 21-100위</dd>
					</dl>
					<dl>
						<dt>특<em class="space"></em>징<em class="space"></em><span>|</span></dt>
						<dd>개인 부문 & E SL 순위 부문 & E SL 도입 부문</dd>
						<dd>중복 달성 가능! </dd>
					</dl>
				</div>
				<div class="mandatory_standards">
					<dl>
						<dt>필수기준</dt>
						<dd><strong>7월 – 9월 1명 이상 팀 도입</strong> (9월 – 11월 위촉 기준)<br/>팀 내 SUMMER 개인 부문 2명 이상 달성 (E SL 본인 포함)</dd>
					</dl>
				</div>
				<div class="measureCon first esl">
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd><em>1-20</em> 위</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >2,000</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area">제주+푸켓</dd>
						</dl>
						<dl>
							<dt>기타</dt>
							<dd class="small">
							중복 달성 시,<br/>
							현금보상 또는<br/>
							팀 산하 1명<br/>
							SUMMER Trip
						</dl>
					</div>
				</div>

				<div class="measureCon esl">
					<div class="Con">
						<dl>
							<dt>환산<br/>CANP순위</dt>
							<dd><em>21-100</em> 위</dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em >1,000</em>만 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>① Trip</dt>
							<dd class="trip_area">푸켓</dd>
						</dl>
						<dl>
							<dt>기타</dt>
							<dd class="small">
							중복 달성 시,<br/>
							현금보상 또는<br/>
							팀 산하 1명<br/>
							SUMMER Trip
						</dl>
					</div>
				</div>
					
				<div class="introduction">
					<dt>도입 부문</dt>
					<dd>5명 이상 도입 시, 달성 확정!</dd>
					<dd>7월 – 9월 팀 도입 (9월 – 11월 위촉 기준)</dd>
				</div>	
				
				
				<!-- G SL부문 -->
				<div class="titleBox">
					<p class="titleBox_t">G SL부문</p>
				</div>
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span class="sl_blank">|</span></dt>
						<dd>G SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span class="sl_blank">|</span></dt>
						<dd>피도입자 합산 (본인 업적 포함) </dd>
					</dl>
					<dl>
						<dt>선발 인원<span class="sl_blank">|</span></dt>
						<dd>환산 CANP 상위 30위</dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd><strong>7월 – 9월 1명 이상 팀 도입</strong> (9월 – 11월 위촉 기준)<br/>CMIP 500만 이상</dd>
					</dl>
				</div>
				<!-- S SL부문 -->
				<div class="titleBox">
					<p class="titleBox_t">S SL부문</p>
				</div>
				<div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span class="sl_blank">|</span></dt>
						<dd>S SL</dd>
					</dl>
					<dl>
						<dt>평가 기준<span class="sl_blank">|</span></dt>
						<dd>피도입자 합산 (본인 업적 포함) </dd>
					</dl>
					<dl>
						<dt>선발 인원<span class="sl_blank">|</span></dt>
						<dd>환산 CANP 상위 10위</dd>
					</dl>
				</div>
				<div class="mandatory_standards gsl">
					<dl>
						<dt>필수기준</dt>
						<dd><strong>7월 – 9월 1명 이상 팀 도입</strong> (9월 – 11월 위촉 기준)<br/>CMIP 750만 이상</dd>
					</dl>
				</div>

			</div>
		</div>
				
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
