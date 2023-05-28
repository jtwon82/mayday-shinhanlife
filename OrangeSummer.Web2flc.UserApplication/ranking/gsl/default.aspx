<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.ranking.gsl._default" %>
<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css" />
    <link rel="stylesheet" href="/resources/css/swiper.css" />

    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<body>
	<div id="sub_wrap" class="subMeta07">
            <uc1:menu runat="server" ID="menu" />
		<div class="subContainer">
			<p class="subTitle"><img src="/resources/img/sub/rankingTitle.png" alt="SUMMER 랭킹" /></p>
			<div class="cumulativePage">
				<p class="endTxt">
				<span>서비스 종료 안내</span>
				2021년 8월 28일부터<br/>
				썸머 업적 페이지와 썸머 랭킹 데이터를<br/>
				제공하지 않습니다.<br/>
				<strong>이벤트와 알림게시판은 8월 31일까지<br/>
				운영하오니 많은 이용 부탁드립니다.</strong></p>
			</div>
		</div>
		<div class="subContainer" style="display:none;">
			<p class="subTitle"><img src="/resources/img/sub/rankingTitle.png" alt="SUMMER 랭킹" /></p>
			<ul class="bmTabs measure ranking">
				<li><a href="/ranking" >개인 부문</a></li>
				<li><a href="/ranking/sl">E SL 부문</a></li>
				<li><a href="/ranking/point">지점 부문</a></li>
			</ul>
			<ul class="bmTabs measure ranking two">
				<li><a href="/ranking/gsl" class="current">G SL 부문</a></li>
				<li><a href="/ranking/ssl">S SL 부문</a></li>
			</ul>
                
			<%=_sl%>
		</div>	
	</div>
</body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
