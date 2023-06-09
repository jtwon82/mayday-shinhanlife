﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure.group._default" %>

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
                        <li><a href="/measure/group" class="current">기타부문</a></li>
                    </ul>
                  
                  <div class="evaluationInfo">
						<dt>특<em class="space"></em>징<span>|</span></dt>
						<dd>그룹(사업본부/사업단/지점) BP달성률에 따라</dd>
						<dd class="purple"><span class="transparent"></span>산하조직 전체 초대</dd>
						<dd class="purple"><span class="transparent"></span>(최저 기준 250만↑ 달성자 限)</dd>
					</dl>
				</div>
				  
				<div class="measureCon bi">
					<p class="Con_t">그룹 부문</p>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>사업본부<br>
								(+산하 조직)
							</dd>
						</dl>
						<dl>
							<dt>CANP BP 달성률<br><span>7~8월 MI</span></dt>
							<dd><strong>150% ↑</strong></dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd class="small">CMIP 250만 이상<br>
								소속 FC/SL 전원 초대
							</dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>사업단<br>
								(+산하 조직)
							</dd>
						</dl>
						<dl>
							<dt>CANP BP 달성률<br><span>7~8월 MI</span></dt>
							<dd><strong>180% ↑</strong></dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd class="small">CMIP 250만 이상<br>
								소속 FC/SL 전원 초대
							</dd>
						</dl>
					</div>
					<div class="Con">
						<dl>
							<dt>그룹</dt>
							<dd>지점</dd>
						</dl>
						<dl>
							<dt>CANP BP 달성률<br><span>7~8월 MI</span></dt>
							<dd><strong>200% ↑</strong></dd>
						</dl>
						<dl>
							<dt>혜택</dt>
							<dd class="small">CMIP 250만 이상<br> 
								소속 FC/SL 전원 초대
							</dd>
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
