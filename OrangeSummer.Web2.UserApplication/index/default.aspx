﻿<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.index._default" %>
<%@ Register Src="~/common/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/index.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />

    <script type="text/javascript" src="/resources/js/common.js"></script>
    <script type="text/javascript" src="/common/js/common.js?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
<body id="main">
	<div class="background">
		<p class="cover"></p>
		<p class="upload"><img src="<%=_member.BackgroundImg %>" error="this.src='/resources/img/index/backgroundImg.png'" alt=""/></p>
	</div>
	<div id="main_wrap">
            <uc1:menu runat="server" ID="menu1" />
		<div class="main_container">
			<div class="main_personInfo">
				<p class="main_personImg"><img src="<%=_member.ProfileImg %>" alt="" class="personImg" /><span><label for="myfile" class="inputFileButton"><img src="/resources/img/index/fileIcon.png" alt="" /></label><input type="file" id="myfile" name="myfile" style="display:none";></span></p>
				<p class="person_rank"><span class="point"><%=_member.Branch.Name %></span><%=_member.MemberName %> / <%=_member.LevelName %></p>
				<p class="imgEditBtn"><label for="myfile2" class="inputFileButton2"><img src="/resources/img/index/fileIcon.png" alt="" /></label><input type="file" id="myfile2" name="myfile2" style="display:none";></p>
			</div>
			<div class="rewardBox">
				<p class="rewardTitle"><span><%=_member.Achievement.Date %> 기준</span></p>
				<dl> 
					<dt>My Reward 적립 현황</dt>
					<dd><a href="/member/reward/">총 <%=_member.Achievement.Reward %>원</a></dd>
				</dl>
			</div>
			<dl class="categoryBox">
				<dd><a href="/member/reward/"><img src="/resources/img/index/categoryBg_01.png" alt="프로모션" /></a></dd>
				<dd><a href="/member/reward/?reward=reward"><img src="/resources/img/index/categoryBg_02.png" alt="수수료" /></a></dd>
				<dd><a href="/board/notice/"><img src="/resources/img/index/categoryBg_03.png" alt="주요안내" /></a></dd>
				<!--dt>Category</dt-->
			</dl>
			<div class="mainEventBanner">
				<!--p class="mainEventBanner_t">EVENT &amp; NOTICE</p-->
				<div class="EventBanner_rolling">
					
					<!-- Swiper -->
					<div class="swiper-container">
						<div class="swiper-wrapper">
                        <asp:Repeater ID="rptBannerList" runat="server">
                            <ItemTemplate>
                                <div class="swiper-slide"><a href="<%# MLib.Util.Check.IsNone(Eval("Link").ToString()) ? "javascript:;" : Eval("Link").ToString() %>"><img src="<%#OrangeSummer.Common.User.AppSetting.AwsUrl(Eval("AttMobile").ToString()) %>" alt="<%#Eval("Title") %>"/></a></div>
                            </ItemTemplate>
                        </asp:Repeater>
						</div>
						<!-- Add Pagination -->
						<div class="swiper-pagination"></div>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript">
        $("#myfile, #myfile2").on("change", function () {
            var thiss = this;
            console.log(thiss.name);

            if (thiss.files && thiss.files[0]) {
                var file = thiss.files[0];

                var fd = new FormData();
                if (thiss.name == 'myfile') {
                    fd.append('mode', 'PROFILE');
                } else {
                    fd.append('mode', 'BACKGROUND');
                }
                fd.append('file', file);

                $.ajax({
                    url: "/api/member/fileupload",
                    type: "POST",
                    data: fd,
                    dataType: "json",
                    processData: false,  // tell jQuery not to process the data
                    contentType: false   // tell jQuery not to set contentType
                }).done(function (req) {
                    console.log(req);
                    if (req.result != 'SUCCESS') {
                        alert("이미지 업로드에 실패했습니다.");

                    } else {
                        if (fd.get("mode") == "PROFILE") {
                            $(".profile").attr("src", req.url);
                        } else {
                            $(".upload img").attr("src", req.url);
                        }

                        var fd2 = new FormData();
                        fd2.append("mode", fd.get("mode"));
                        fd2.append("url", req.url);
                        $.ajax({
                            url: "/api/member/updateImg",
                            type: "POST",
                            data: { "mode": fd.get("mode"), 'url': req.url },
                            dataType: "json"
                        }).done(function (req) {
                            console.log(req);
                            if (req.result != 'SUCCESS') {
                                alert("이미지 업로드에 실패했습니다.");
                            } else {
                                location.reload();
                            }
                        });
                    }
                });

            }
        })
    </script>

    
					<!-- Initialize Swiper -->
					<script type="text/javascript">
					    $(window).load(function () {
					        var mySwiper = new Swiper('.swiper-container', {
					            slidesPerView: 1, //슬라이드를 한번에 3개를 보여준다
					            spaceBetween: 30, //슬라이드간 padding 값 30px 씩 떨어뜨려줌
					            loop: false, //loop 를 true 로 할경우 무한반복 슬라이드 false 로 할경우 슬라이드의 끝에서 더보여지지 않음
					            pagination: {
					                el: '.swiper-pagination',
					            },
					        });
					    });
					</script>
</asp:Content>
