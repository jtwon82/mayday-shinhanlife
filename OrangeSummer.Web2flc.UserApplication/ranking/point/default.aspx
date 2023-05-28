<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.ranking.point._default" %>
<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css" />
    <link rel="stylesheet" href="/resources/css/swiper.css" />

    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/resources/js/swiper.min.4.3.5.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<body>
	<div class="background sub">
		<p class="cover"></p>
		<p class="upload"><img src="/resources/img/sub/subMetaBg_ranking.jpg" alt=""/></p>
		<p class="topBox"><img src="/resources/img/sub/subTopImg.png" alt=""/></p>
	</div>
	<div id="sub_wrap">
            <uc1:menu runat="server" ID="menu1" />
		<div class="subContainer">
			<p class="subTitle"><img src="/resources/img/sub/rankingTitle.png" alt="랭킹" /></p>
			<ul class="bmTabs measure ranking">
				<li><a href="/ranking/">개인 부문</a></li>
				<li><a href="/ranking/point/" class="current">지점 부문</a></li>
			</ul>
			
			<%=_branch %>
            <%=_paging %>
		</div>	
	</div>
</body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        $(document).ready(function () {
            var bgimgSet= <%=_json %>;
            $(bgimgSet).each(function(id){
                if(this.Type=="RANKING"){
                    var T = this.AttMobile;
                    T = T.replace("\\","/");
                    $(".background .upload img").attr('src', "/upload/"+T);
                }
            });
        });
    </script>
</asp:Content>
