﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.common.uc.menu" %>

<div id="header">
			<h1 class="logo"><a href="/index"><img src="/resources/img/index/index_logo.png" alt="ShinhanLife" /></a></h1>
			<p class="homeBtn"><a href="/index"><img src="/resources/img/index/index_homeIcon.png" alt="ShinhanLife" /></a></p>

    <header class="cf" id="hd">
        <div id="hd_wr">
            <div class="btn"></div>
            <div class="page_cover"></div>
            <div id="menu">
                <div class="person_info">
        <% 
            if (MLib.Auth.Forms.IsAuthenticated)
            {
        %>
                    <p class="person_img"><img src="<%=OrangeSummer.Common.User.Identify.ProfileImg %>" onerror="this.src='/resources/img/index/personImg2.png'" alt="" style="with:112px;height:112px;"/></p>
        <%
            if ( OrangeSummer.Common.User.Identify.LevelName == "신인FC" )
            {
        %>
                    <p class="rank new_fc"><span><%= OrangeSummer.Common.User.Identify.BranchName %></span><em class="newfc"><%= OrangeSummer.Common.User.Identify.Name %> / 신인FC</em></p>
        <%
            }
            else
            {
        %>
                    <p class="rank"><span><%= OrangeSummer.Common.User.Identify.BranchName %></span><%= OrangeSummer.Common.User.Identify.Name %> / <%= OrangeSummer.Common.User.Identify.LevelName %></p>
        <%
            }
        %>
                    <ul class="editBtn">
                        <li><a href="/member/edit">내 정보 수정하기</a></li>
                        <li>
                            <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CssClass="btn_logout" Text="로그아웃"></asp:LinkButton></li>
                    </ul>
        <%
            }
        %>
                </div>
                <div class="close"></div>
                <ul id="mainMenu">
							<li>
								<a href="/measure">시책 안내</a>
							</li>
							<li>
								<a href="/achieve">나의 업적</a>
							</li>
							<li>
								<a href="/ranking">썸머 랭킹</a>
							</li>
							<li>
								<a href="/board/notice">공지&이벤트</a>
							</li>
                </ul>
            </div>
        </div>
    </header>
		</div>