﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.board.notice._default" %>
<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <link rel="stylesheet" href="/resources/css/board.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <link rel="stylesheet" href="/resources/css/swiper-bundle.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <script type="text/javascript" src="/resources/js/swiper-bundle2.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
<body>
	<div id="sub_wrap" class="subMeta09">
            <uc1:menu runat="server" ID="menu1" />
		<div class="subContainer ">
			<p class="subTitle"><img src="/resources/img/sub/noticeTitle.png" alt="주요 공지" /></p>
					<div class="event_rolling">
						<!-- Swiper -->
						<div class="swiper-container2">
							<div class="swiper-wrapper">
                            <asp:Repeater ID="rptBannerList" runat="server">
                                <ItemTemplate>
                                    <div class="swiper-slide"><a href="<%# MLib.Util.Check.IsNone(Eval("Link").ToString()) ? "javascript:;" : Eval("Link").ToString() %>"><img src="<%#OrangeSummer.Common.User.AppSetting.AwsUrl(Eval("AttMobile").ToString()) %>" alt="<%#Eval("Title") %>"/></a></div>
                                </ItemTemplate>
                            </asp:Repeater>
							</div>
							<!-- Add Pagination -->
							<div class="swiper-pagination2"></div>
						</div>
					</div>
					<div class="noticeList">
                    <asp:Repeater ID="rptNoticeList" runat="server">
                        <ItemTemplate>
                                <div class="listBox ">
                                <a href="detail.aspx?id=<%# Eval("Id").ToString() + "&type=" + Eval("Type").ToString() %>">
                                    <p class="title">[공지] <%# Eval("Title") %></p>
                                    <p class="replyNum"><%# Eval("ReplyCount") %></p>
                                    <ul class="info">
                                        <li class="name"><%# Eval("Admin.Name") %><span>ㅣ</span></li>
                                        <li class="view">view <em><%# Eval("ViewCount") %></em><span>ㅣ</span></li>
                                        <li class="date"><%# Eval("RegistDate").ToString().Substring(2) %></li>
                                    </ul>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rptEventlList" runat="server">
                        <ItemTemplate>
                                <div class="listBox ">
                                <a href="<%# Eval("url").ToString() %>">
                                    <p class="title">[이벤트] <%# Eval("Title") %></p>
                                    <p class="replyNum"><%# Eval("ReplyCount") %></p>
                                    <ul class="info">
                                        <li class="name"><%# Eval("Admin.Name") %><span>ㅣ</span></li>
                                        <li class="view">view <em><%# Eval("ViewCount") %></em><span>ㅣ</span></li>
                                        <li class="date"><%# Eval("RegistDate").ToString().Substring(2) %></li>
                                    </ul>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                        <asp:Repeater ID="rptNormalList" runat="server">
                            <ItemTemplate>
                                <div class="listBox">
                                    <a href="detail.aspx?id=<%# Eval("Id").ToString() + "&type=" + Eval("Type").ToString() %>">
                                        <p class="title"><span><%# ListNumber(Eval("Total"), Container.ItemIndex) %></span> <%# Eval("Title") %></p>
                                        <p class="replyNum"><%# Eval("ReplyCount") %></p>
                                        <ul class="info">
                                            <li class="name"><%# Eval("Admin.Name") %><span>ㅣ</span></li>
                                            <li class="view">view <em><%# Eval("ViewCount") %></em><span>ㅣ</span></li>
                                            <li class="date"><%# Eval("RegistDate").ToString().Substring(2) %></li>
                                        </ul>
                                    </a>
				                </div>
                            </ItemTemplate>
                        </asp:Repeater>
			    </div>
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
                if(this.Type=="NOTICE"){
                    var T = this.AttMobile;
                    T = T.replace("\\","/");
                    $(".background .upload img").attr('src', "/upload/"+T);
                }
            });
        });
    </script>
						<!-- Initialize Swiper -->
							<script>
							    var swiper = new Swiper('.swiper-container2', {
							        e: '',
							        autoplay: {
							            delay: 5000,
							            disableOnInteraction: false,
							        },
								  pagination: {
									el: '.swiper-pagination2',
								  },
								});
							</script>
</asp:Content>
