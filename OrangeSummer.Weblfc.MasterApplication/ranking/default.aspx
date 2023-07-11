<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Weblfc.MasterApplication.ranking._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-2">
        <div class="card-body" style="padding: 10px 10px 0px 10px;">
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label>지점</label>
                    <asp:DropDownList ID="branch" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label>신분</label>
                    <asp:DropDownList ID="level" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label>코드</label>
                    <asp:TextBox ID="code" ClientIDMode="Static" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label>이름</label>
                    <asp:TextBox ID="name" ClientIDMode="Static" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="d-flex justify-content-end">
        <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ClientIDMode="Static" CssClass="btn btn-primary mr-2">
            <i class="material-icons">search</i> 검색
        </asp:LinkButton>
        <a href="./" class="btn btn-secondary">
            <i class="material-icons">refresh</i> 초기화
        </a>
    </div>

    <ul class="nav nav-tabs mb-2">
        <li class="nav-item">
            <a class="nav-link<%= (_orderby == "PERSON_RANK") ? " active font-weight-bold" : "" %>" href="./?orderby=PERSON_RANK">개인 랭킹</a>
        </li>
        <li class="nav-item">
            <a class="nav-link<%= (_orderby == "BRANCH_RANK") ? " active font-weight-bold" : "" %>" href="./?orderby=BRANCH_RANK">지점 랭킹</a>
        </li>
        <li class="nav-item">
            <a class="nav-link<%= (_orderby == "SL_RANK2") ? " active font-weight-bold" : "" %>" href="./?orderby=SL_RANK2">S SL 랭킹</a>
        </li>
        <li class="nav-item">
            <a class="nav-link<%= (_orderby == "SL_RANK3") ? " active font-weight-bold" : "" %>" href="./?orderby=SL_RANK3">G SL 랭킹</a>
        </li>
        <li class="nav-item">
            <a class="nav-link<%= (_orderby == "SL_RANK") ? " active font-weight-bold" : "" %>" href="./?orderby=SL_RANK">E SL 랭킹</a>
        </li>
    </ul>
    <p class="mb-1">* 총 <span class="text-danger font-weight-bold"><%= _total %></span>개의 랭킹이 있습니다.</p>
    <div class="table-responsive">
        <table class="table table-bordered" style="min-width: 1024px;">
            <colgroup>
                <col style="width: 3%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col />
            </colgroup>
            <thead>
                <tr>
                    <th>No</th>
                    <th>지점</th>
                    <th>신분</th>
                    <th>코드</th>
                    <th>성명</th>
                    
                    <th>CMIP</th>
                    <th>CANP</th>
                    <th>CNT</th>
                    <th>SlCanp2</th>
                    <th>SlCmip2</th>
                    <th>SlCanp3</th>
                    <th>SlCmip3</th>
                    <th>SlCanp</th>
                    <th>SlCmip</th>
                    <th>BRANCH CANP</th>
                    <th>BRANCH CMIP</th>
                    <th>BRANCH CMIP달성</th>
                    <th>BRANCH CANP달성</th>
                    
                    <th>PERSON2 CANP</th>
                    <th>PERSON2 CMIP</th>
                    <th>PERSON2 CNT</th>

                    <th>RANK</th>
                    <th>S RANK</th>
                    <th>G RANK</th>
                    <th>E RANK</th>
                    <th>BRANCH RANK</th>
                    <th>PERSON2 RANK</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# ListNumber(Eval("Total"), Container.ItemIndex) %></td>
                            <td><%# Eval("Branch.Name") %></td>
                            <td><%# OrangeSummer.Common.Code.MemberLevelName(Eval("Level").ToString()) %></td>
                            <td><%# Eval("Code") %></td>
                            <td><%# Eval("Name") %></td>
                            
                            <td><%# Eval("PersonCmip") %></td>
                            <td><%# Eval("PersonCanp") %></td>
                            <td><%# Eval("PersonCnt") %></td>
                            <td><%# Eval("SlCanp2") %></td>
                            <td><%# Eval("SlCmip2") %></td>
                            <td><%# Eval("SlCanp3") %></td>
                            <td><%# Eval("SlCmip3") %></td>
                            <td><%# Eval("SlCanp") %></td>
                            <td><%# Eval("SlCmip") %></td>
                            <td><%# Eval("BranchCanp") %></td>
                            <td><%# Eval("BranchCmip") %></td>
                            <td><%# Eval("BranchCmip2") %></td>
                            <td><%# Eval("BranchCanp2") %></td>
                            <td><%# Eval("Person2Canp") %></td>
                            <td><%# Eval("Person2Cmip") %></td>
                            <td><%# Eval("Person2Cnt") %></td>

                            <td><%# Eval("PersonRank") %></td>
                            <td><%# Eval("SlRank2") %></td>
                            <td><%# Eval("SlRank3") %></td>
                            <td><%# Eval("SlRank") %></td>
                            <td><%# Eval("BranchRank") %></td>
                            <td><%# Eval("Person2Rank") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="noData" runat="server">
                    <td colspan="14">등록된 자료가 없습니다.</td>
                </tr>
            </tbody>
        </table>
    </div>

    <%= _paging %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptPlaceHolder1" runat="server">
</asp:Content>
