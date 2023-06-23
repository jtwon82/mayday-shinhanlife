<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.point._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"" />
    <link rel="stylesheet" href="/resources/css/swiper.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>""/>

    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <body>
        <div id="sub_wrap" class="subMeta05">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer guide point">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_guide">
                    <ul class="bmTabs measure">
                        <li><a href="/measure/individual">개인 부문</a></li>
                        <li><a href="/measure/sl">SL 부문</a></li>
                        <li><a href="/measure/point" class="current">지점 부문</a></li>
                        <li><a href="/measure/group">그룹부문</a></li>
                    </ul>
                    
				<!-- 지점부문 -->
                <div class="measureCon ranking point">
					<p class="Con_t">순위부문</p>
					<div class="Con">
						<dl>
							<dt>구분</dt>
							<dd>상위</dd>
						</dl>
						<dl>
							<dt>순위</dt>
							<dd>환산 CANP 순위<strong><em>1-10</em> 위</strong></dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em>8,000</em>만<em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>보상</dt>
							<dd class="trip_area">제주+푸켓</dd>
						</dl>
					</div>
					
					<div class="Con">
						<dl>
							<dt>구분</dt>
							<dd>일반</dd>
						</dl>
						<dl>
							<dt>순위</dt>
							<dd>환산 CANP 순위<strong><em>11-40</em> 위</strong></dd>
						</dl>
						<dl>
							<dt>최소 기준</dt>
							<dd>CMIP <br/><strong><em>4,000</em>만<em>↑</em></strong></dd>
						</dl>
						<dl>
							<dt>보상</dt>
							<dd class="trip_area">푸켓</dd>
						</dl>
					</div>
				</div>
				
				 <dl class="necessaryGuidance">
					<dt>필수 기준</dt>
					<dd>지점 내 개인부문 달성인원 5명 이상</dd>
				</dl>
				   
				<div class="measureCon bp first">
					<p class="Con_t">BP부문</p>
					<div class="Con">
						<dl>
							<dt>순위</dt>
							<dd>CANP BP달성률<br/><strong>상위<em>10</em>위</strong> <br/></dd>
						</dl>
						<dl>
							<dt>필수기준</dt>
							<dd><strong class="purple">7월+8월 BP 100% 달성</strong>
								(CMIP 또는 CANP BP 달성)<br/>
								<strong class="purple">7월+8월 CMIP 2,000만 ↑</strong>
							</dd>
						</dl>
						<dl>
							<dt>보상</dt>
							<dd class="trip_area">푸켓</dd>
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
