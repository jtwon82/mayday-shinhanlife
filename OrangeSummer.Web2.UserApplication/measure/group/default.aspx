<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.group._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"/>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<body>
	<div id="sub_wrap" class="subMeta05 measure">
            <uc1:menu runat="server" ID="menu" />
        
            <div class="subContainer guide group">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual">개인 부문</a></li>
                        <li><a href="/measure/sl">SL 부문</a></li>
                        <li><a href="/measure/point">지점 부문</a></li>
                        <li><a href="/measure/group" class="current">그룹부문</a></li>
                    </ul>
                  
                  <div class="evaluationInfo">
					<dl>
						<dt>평가 대상<span class="sl_blank">|</span></dt>
						<dd>독립사업본부, 사업본부, 사업단, 지점</dd>
					</dl>
					<dl>
						<dt>평가 기준<span class="sl_blank">|</span></dt>
						<dd>BP달성률에 따라 지점원 전원 초대! </dd>
					</dl>
					<dl>
						<dt>특<em class="space"></em>징<em class="space"></em><span>|</span></dt>
						<dd> FC / SL 개인 업적 CMIP 200만 이상 限 초대</dd>
					</dl>
				</div>
				  
				<div class="measureCon nsm first">
					<p class="Con_t">NSM 부문</p>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>독립본부 합산<br/>사업본부 합산</dd>
						</dl>
						<dl>
							<dt>7월+8월 BP달성률<br><span>(CMIP or CANP)</span></dt>
							<dd><strong class="purple">150% <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>푸켓 Trip</dt>
							<dd>7월+8월 개인 업적<br>CMIP 200만 이상<strong class="purple">전원 초대</strong></dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>사업단 합산</dd>
						</dl>
						<dl>
							<dt>7월+8월 BP달성률<br><span>(CMIP or CANP)</span></dt>
							<dd><strong class="purple">180% <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>푸켓 Trip</dt>
							<dd>7월+8월 개인 업적<br>CMIP 200만 이상<strong class="purple">전원 초대</strong></dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>지점</dd>
						</dl>
						<dl>
							<dt>7월+8월 BP달성률<br><span>(CMIP or CANP)</span></dt>
							<dd><strong class="purple">200% <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>푸켓 Trip</dt>
							<dd>7월+8월 개인 업적<br>CMIP 200만 이상<strong class="purple">전원 초대</strong></dd>
						</dl>
					</div>
					
				</div>
				
				
				<div class="measureCon guinness point">
					<p class="Con_t">GUINNESS 부문</p>
					<div class="Con">
						<dl>
							<dt>지점</dt>
							<dd>독립본부 합산<br/>사업본부 합산</dd>
						</dl>
						<dl>
							<dt>7월+8월 MI업적</dt>
							<dd><strong class="purple">CMIP<br/> 5억 <em>↑</em> </strong><span>or</span><strong class="purple">CANP<br/> 25억 <em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>푸켓 Trip</dt>
							<dd>기념패, 2,000만원<br>전용 버스, 별도 만찬</dd>
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
