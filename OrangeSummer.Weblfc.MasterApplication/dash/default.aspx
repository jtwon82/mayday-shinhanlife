﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Weblfc.MasterApplication.dash._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-group mb-5">
        <div class="card">
            <div class="card-header text-center">
                <h5 class="card-title font-weight-bold">회원 현황</h5>
            </div>
            <div class="card-body">
                <ul class="list-group">
                    <li class="d-flex justify-content-between align-items-center p-2">전체 회원
                            <span><span class="font-weight-bold text-primary"><%= _mtotal %></span>명</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">신규 가입
                            <span><span class="font-weight-bold text-primary"><%= _mnew %></span>명</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">&nbsp;</li>
                </ul>
            </div>
        </div>
        <div class="card">
            <div class="card-header text-center">
                <h5 class="card-title font-weight-bold">업적 현황</h5>
            </div>
            <div class="card-body" style="display:none1;">
                <ul class="list-group">
                    <li class="d-flex justify-content-between align-items-center p-2">월납화보험료(보장)
                            <span><span class="font-weight-bold text-primary"><%= _achievement.Cost2 %></span>원</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">월납화보험료
                            <span><span class="font-weight-bold text-primary"><%= _achievement.Cost %></span>원</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">CANP
                            <span><span class="font-weight-bold text-primary"><%= _achievement.Canp %></span>원</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">Reward
                            <span><span class="font-weight-bold text-primary"><%= _achievement.Reward%></span>원</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">CMIP
                            <span><span class="font-weight-bold text-primary"><%= _achievement.Cmip%></span>원</span>
                    </li>
                </ul>
            </div>
        </div>
        <div class="card">
            <div class="card-header text-center">
                <h5 class="card-title font-weight-bold">랭킹 현황</h5>
            </div>
            <div class="card-body" style="display:none1;">
                <ul class="list-group">
                    <li class="d-flex justify-content-between align-items-center p-2">개인 1위
                            <span><span class="font-weight-bold text-primary"><%= _member.Branch.Name%></span>지점
                                 <span class="font-weight-bold text-primary"><%= _member.MemberName %></span>님</span>
                    </li>
                    <%--<li class="d-flex justify-content-between align-items-center p-2">S SL 1위
                            <span><span class="font-weight-bold text-primary"><%= _SLbranch2 %></span>지점
                                 <span class="font-weight-bold text-primary"><%= _SLname2 %></span>님</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">G SL 1위
                            <span><span class="font-weight-bold text-primary"><%= _SLbranch3 %></span>지점
                                 <span class="font-weight-bold text-primary"><%= _SLname3 %></span>님</span>
                    </li>
                    <li class="d-flex justify-content-between align-items-center p-2">E SL 1위
                            <span><span class="font-weight-bold text-primary"><%= _SLbranch %></span>지점
                                 <span class="font-weight-bold text-primary"><%= _SLname %></span>님</span>
                    </li>--%>
                    <li class="d-flex justify-content-between align-items-center p-2">지점 1위
                            <span><span class="font-weight-bold text-primary"><%= _member2.Branch.Name %></span>지점</span>
                    </li>
                </ul>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <span class="font-weight-bold">공지사항</span>
                    <a href="/board/notice/" class="small text-decoration-none text-secondary">전체보기</a>
                </div>

                <ul class="list-group list-group-flush">
                    <asp:Repeater ID="rptNoticeList" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item d-flex justify-content-between hand" onclick="location.href='/board/notice/regist.aspx?id=<%# Eval("Id") %>';">
                                [<%# Eval("Type").ToString() == "NOTICE" ? "Notice" : "일반" %>] <%# Eval("Title") %>
                                <span class="small"><%# Eval("RegistDate").ToString().Replace("-", ".") %></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <span class="font-weight-bold">이벤트</span>
                    <a href="/board/evt/" class="small text-decoration-none text-secondary">전체보기</a>
                </div>
                <ul class="list-group list-group-flush">
                    <asp:Repeater ID="rptEventList" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item d-flex justify-content-between hand" onclick="location.href='/board/evt/regist.aspx?id=<%# Eval("Id") %>';">
                                [<%# Eval("Type").ToString() == "NOTICE" ? "Notice" : "일반" %>] <%# Eval("Title") %>
                                <span class="small"><%# Eval("RegistDate").ToString().Replace("-", ".") %></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder1" runat="server">
</asp:Content>
