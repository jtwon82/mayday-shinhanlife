﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.achieve.point._default" %>

<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css" />
    <link rel="stylesheet" href="/resources/css/swiper.css" />

    <script type="text/javascript" src="/resources/js/swiper3.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<body class="bm_point">
	<div id="sub_wrap" class="subMeta04">
            <uc1:menu runat="server" ID="menu" />
            <div class="subContainer guide bm point">
                <p class="subTitle"><img src="/resources/img/sub/bmTitle.png" alt="SUMMER 업적" /></p>
                <ul class="bmTabs">
                    <li><a href="/achieve/point" class="current">지점 부문</a></li>
                </ul>
                <div class="swiper-container3">
                    <div class="swiper-wrapper">
                         <%=_contents %> 
                    </div>
                </div>

                <!-- Initialize Swiper -->

                
                <ul class="referenceBox">
                    <li>* 본 데이터는 2023 Summer Festival 진도관리를 위한 보조자료이며, 달성 결과가 아님을 알려드립니다.</li>
				    
                    <li>* 자세한 내용은 해당공문을 반드시 참고하시기 바랍니다. </li>
                </ul>
            </div>
        </div>
    </body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        var swiper = new Swiper('.swiper-container3', {
            initialSlide: '1',
            pagination: '.swiper-pagination',
            paginationClickable: true,
            nextButton: '.swiper-button-next',
            prevButton: '.swiper-button-prev',
            autoplay: false,
            spaceBetween: 30
        });
        $('.swiper-container3 .swiper-slide').each(function (id) {
            if ($(this).hasClass("slide1")) {
                swiper.slideTo(id, 0, false);
            }
        });
    </script>
</asp:Content>
