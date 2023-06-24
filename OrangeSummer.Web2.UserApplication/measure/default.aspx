﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.measure._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />

    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <body>
        <div id="sub_wrap" class="subMeta05">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer notice">
                <p class="subTitle"><img src="/resources/img/sub/measureTitle.png" alt="시책안내" /></p>
                <div class="measure_list">
                    <dl>
                        <dt>썸머시책안내</dt>
                        <dd>썸머 기간 / 2022년 07월 01일 ~ 08월 31일까지</dd>
                    </dl>
                    <ul>
                        <li><a href="/measure/individual">
                            <img src="/resources/img/sub/measure/measureIndividual.png" alt="로지와 함께 썸머 개인부문" /></a></li>
                        <li><a href="/measure/sl">
                            <img src="/resources/img/sub/measure/measureSl.png" alt="로지와 함께 썸머 SL부문" /></a></li>
                        <li><a href="/measure/point">
                            <img src="/resources/img/sub/measure/measurePoint.png" alt="로지와 함께 썸머 지점부문" /></a></li>
						<li><a href="/measure/group">
                            <img src="/resources/img/sub/measure/measureGroup.png" alt="로지와 함께 썸머 그룹부문" /></a></li>
                    </ul>
				   <%-- <dl class="dynamite">
					    <dt>DYNAMITE 시책</dt>
					    <dd>2021년 9월 30일 ~ 10월 신 계약 마감일</dd>
				    </dl>
				    <p class="dynamiteBanner"><a href="#none"><img src="/resources/img/sub/measure/dynamiteBanner.jpg" alt="보장 개인부문 DYNAMITE"/></a></p>--%>
			    </div>
		    </div>
				
	    </div>
    </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
