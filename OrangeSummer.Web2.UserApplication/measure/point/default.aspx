<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.point._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>""/>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05 measure ">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer guide point">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual">개인 부문</a></li>
                        <li><a href="/measure/sl">SL 부문</a></li>
                        <li><a href="/measure/point" class="current">지점 부문</a></li>
                        <li><a href="/measure/group">기타부문</a></li>
                    </ul>
                    
					<div class="evaluationInfo">
						<dl>
							<dt>평가 대상<span>|</span></dt>
							<dd>BM, EM, ERM, IRM</dd>
						</dl>
						<dl>
							<dt>평가 기준<span>|</span></dt>
							<dd><strong>순위부문 :</strong> 환산 CANP</dd>
							<dd><strong>BP부문 :</strong> CANP BP 달성률</dd>
						</dl>
						<dl>
							<dt>선발 인원<span>|</span></dt>
							<dd>상위 65명 + α</dd>
						</dl>
						<dl>
							<dt>특<em class="space"></em>징<span>|</span></dt>
							<dd class="purple">순위부문 우선 선발 후 BP부문 선발</dd>
						</dl>
					</div>

					<div class="measureCon ranking point">
						<p class="Con_t">순위부문</p>
						<div class="mandatory_standards gsl">
							<dl>
								<dt>필수기준</dt>
								<dd><strong>CMIP 3천만↑</strong><br>지점 내 개인부문 5명 이상 달성<br>& 7~8월 합산 CMIP(MI 기준) 3천만 ↑</dd>
							</dl>
						</div>
						<div class="Con">
							<dl>
								<dt>평가 CANP 순위</dt>
								<dd><strong>1-10</strong>위</dd>
							</dl>
							<dl>
								<dt>CMIP</dt>
								<dd><strong>15,000만↑</strong></dd>
							</dl>
							<dl>
								<dt>혜택</dt>
								<dd><strong>스페인+다낭</strong></dd>
							</dl>
						</div>
						
						<div class="Con">
							<dl>
								<dt>평가 CANP 순위</dt>
								<dd><strong>11-25</strong>위</dd>
							</dl>
							<dl>
								<dt>CMIP</dt>
								<dd><strong>8,000만↑</strong></dd>
							</dl>
							<dl>
								<dt>혜택</dt>
								<dd><strong>호주</strong></dd>
							</dl>
						</div>

						<div class="Con">
							<dl>
								<dt>평가 CANP 순위</dt>
								<dd><strong>26-65</strong>위</dd>
							</dl>
							<dl>
								<dt>CMIP</dt>
								<dd><strong>4,000만↑</strong></dd>
							</dl>
							<dl>
								<dt>혜택</dt>
								<dd><strong>다낭</strong></dd>
							</dl>
						</div>
				</div>
				   
				<div class="bp">
					<dt>BP 부문</dt>
					<dd class="purple">CANP BP 100% 이상 달성 시 다낭 Trip 확정!</dd>
					<dd>지점 내 개인부문 5명 이상 달성</dd>
					<dd>& 7~8월 합산 CMIP(MI 기준) 3천만 ↑</dd>
				</div>	
				
			</div> 
		</div>
				
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
