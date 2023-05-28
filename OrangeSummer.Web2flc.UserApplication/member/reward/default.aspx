<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2flc.UserApplication.member.reward._default" %>
<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/sub.css?st=1" />
    <link rel="stylesheet" href="/resources/css/swiper.css" />

    <script type="text/javascript" src="/resources/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
    <script type="text/javascript" src="/common/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<body>
	<div class="background sub">
		<p class="cover"></p>
		<p class="upload"><img src="/resources/img/sub/subMetaBg_reword.jpg" alt=""/></p>
	</div>
	<div id="sub_wrap">
            <uc1:menu runat="server" ID="menu1" />
		<div class="subContainer">
			<p class="subTitle"><img src="/resources/img/sub/rewardTitle.png" alt="My Reward" /></p>
			
			<div class="rewardBox">
				<p class="update_date"><%=_achievement.Date %> 기준</p>
				<dl class="rewardStatus">
					<dt>My Reward 적립 현황</dt>
					<dd>총 <%=_achievement.Reward %>원</dd>
				</dl>
			</div>
			
			<div class="rewardCon">
				<ul class="bmTabs reward">
					<li class="tab-link current" data-tab="tab-1">Promotion</li>
					<li class="tab-link" data-tab="tab-2">수수료</li>
				  </ul>

				  <%--<p class="reward_title"><span>Promotion</span></p>--%>

				<div id="tab-1" class="tab-content current">
					<ul class="promotion_total">
						<li>Promotion 합계</li>
						<li><%=_achievement.Promotion %>원</li>
					</ul>
					<div class="promotion_table">
						<table width="100%" style="table-layout: fixed;">
							<colgroup>
								<col width="15%" />
								<col width="60%" />
								<col width="" />
							</colgroup>
							<tr>
								<th>지급월</th>
								<th>시책명</th>
								<th>금액</th>
							</tr>
                        <asp:Repeater ID="promotionList" runat="server">
                            <ItemTemplate>
							<tr class="row1" style="display:none;">
								<td><%# Eval("Date").ToString() %></td>
								<td style="white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding: 0 20px;"><%# Eval("TypeName").ToString() %></td>
								<td><%# Eval("Price").ToString() %></td>
							</tr>
                            </ItemTemplate>
                        </asp:Repeater>
						</table>
                        <p class="moreBtn moreBtn1" style="text-align:center;"><img src="/resources/img/sub/reward/reword_more.png" alt="더보기" style="display:initial;"/></p>
					</div>
				</div>

				<div id="tab-2" class="tab-content">
					<ul class="fees_noti">
						<li>실제 지급월 시점에 수수료 지급/BP적립*으로 나뉘어 발생 예정이며,<br/>최종수수료 지급액 변동 가능<br/>(*BP적립:계약 미유지 상태 혹은 유지(성과)수수료 지급 조건 미충족 FC/SL)</li>
					</ul>
					<ul class="promotion_total">
						<li>수수료 합계</li>
						<li><%=_achievement.Charge %>원</li>
					</ul>
					<div class="charge_table">
						<table width="100%" style="table-layout: fixed;">
							<colgroup>
								<col width="15%" />
								<col width="60%" />
								<col width="" />
							</colgroup>
							<tr>
								<th>지급월</th>
								<th>수수료명</th>
								<th>금액</th>
							</tr>
                        <asp:Repeater ID="chargeList" runat="server">
                            <ItemTemplate>
							<tr class="row2" style="display:none;">
								<td><%# Eval("Date").ToString() %></td>
								<td style="white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding: 0 20px;"><%# Eval("TypeName").ToString() %></td>
								<td><%# Eval("Price").ToString() %></td>
							</tr>
                            </ItemTemplate>
                        </asp:Repeater>
						</table>
                        <p class="moreBtn moreBtn2" style="text-align:center;"><img src="/resources/img/sub/reward/reword_more.png" alt="더보기" style="display:initial;"/></p>
					</div>
				</div>
			</div>

		</div>	
	</div>
</body>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        $(document).ready(function () {
            

            $('ul.bmTabs li').click(function(){
                var tab_id = $(this).attr('data-tab');

                $('ul.bmTabs li').removeClass('current');
                $('.tab-content').removeClass('current');

                $(this).addClass('current');
                $("#"+tab_id).addClass('current');
            });
            if('<%=_reward%>'=='reward'){
                $('ul.bmTabs li:eq(1)').click();
            }


            var bgimgSet= <%=_json %>;
            $(bgimgSet).each(function(id){
                if(this.Type=="MYREWARD"){
                    var T = this.AttMobile;
                    T = T.replace("\\","/");
                    $(".background .upload img").attr('src', "/upload/"+T);
                }
            });

            
            $(".row1").slice(0, 10).show();
            $(".moreBtn1").click(function(e){
                e.preventDefault();
                $(".row1:hidden").slice(0, 10).show();
                if($(".row1:hidden").length == 0){
                    $(this).hide();
                } else {
                    $(this).show();
                }
            });
            if($(".row1:hidden").length == 0){
                $(".moreBtn1").hide();
            }
            console.log($(".row1:hidden").length);

            
            $(".row2").slice(0, 10).show();
            $(".moreBtn2").click(function(e){
                e.preventDefault();
                $(".row2:hidden").slice(0, 10).show();
                if($(".row2:hidden").length == 0){
                    $(this).hide();
                } else {
                    $(this).show();
                }
            });
            if($(".row2:hidden").length == 0){
                $(".moreBtn2").hide();
            }
            console.log($(".row2:hidden").length);

            //$(".tab-content").hide();
            //$(".tab-content:eq(1)").show();
        });

        $(function(){
        });
    </script>
</asp:Content>
