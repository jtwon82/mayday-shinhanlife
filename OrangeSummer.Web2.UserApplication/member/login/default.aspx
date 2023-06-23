<%@ Page Title="" Language="C#" MasterPageFile="~/common/master/page.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OrangeSummer.Web2.UserApplication.member.login._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/resources/css/reset.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
    <link rel="stylesheet" href="/resources/css/layout.css?v=<% =DateTime.Now.ToString("yyyyMMddHHmmss") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
<body class="login">
	<p class="login_txt"><img src="/resources/img/login_txt.png" alt="2023 SUMMER FESTIVAL"/></p>
	<div class="loginPage">
		<div class="fc_code">
            <asp:TextBox ID="code" runat="server" MaxLength="8" ClientIDMode="Static" placeholder="FC코드 8자리를 입력해 주세요."></asp:TextBox>
		</div>
		
		<div class="fc_pwd">
            <asp:TextBox ID="pwd" runat="server" TextMode="Password" MaxLength="12" ClientIDMode="Static" placeholder="Password"></asp:TextBox>
		</div>
         
		<div class="btn_login">
            <button id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick" onclick="if (!member.login()) { return false; }">로그인</button>
		</div>
		<p class="tail">※ 기존 FC회원은 코드 앞에 '000'을 붙여주세요.</p>
		<div class="check_group">
			<div class="login_check">
				<input type="checkbox" name="loginChk" id="loginChk" onchange="remember.value=this.checked?'Y':'N'"/>
				<label for="loginChk" class="loginChk">자동 로그인</label>
                <asp:HiddenField ID="remember" runat="server" ClientIDMode="Static" Value="Y" />
			</div>
            <ul class="btn_list">
				<li class="findPw"><a href="/member/find_pw/">비밀번호 찾기</a></li>
				<li class="join"><a href="/member/regist/">회원가입</a></li>
			</ul>
		</div>
	</div>
</body>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        $(document).ready(function () {
            $(".login_check em").on('click', function () {
                $('.login_check .loginChk').click();
            });
            $("#auto").on("click", function () {
                if ($(this).is(":checked")) {
                    $("#remember").val("Y");
                } else {
                    $("#remember").val("N");
                }
            });
            var bgimgSet= '<%="" %>';
            $(bgimgSet).each(function(id){
                if(this.Type=="LOGIN"){
                    var T = this.AttMobile;
                    T = T.replace("\\","/");
                    $(".login").css('background-image','url(/upload/'+T+')')
                }
            });
        });

        var member = {
            login: function () {
                var literal = {
                    code: {
                        selector: $("#code"), required: { message: "FC 코드를 입력해주세요." },
                        length: { value: 8, message: "FC 코드는 숫자 8자리로 입력해주세요." },
                        digit: { message: "FC 코드는 숫자 5자리로 입력해주세요." }
                    },
                    pwd: { selector: $("#pwd"), required: { message: "비밀번호를 입력해주세요." } }
                };

                return $.validate.rules(literal, { mode: 'alert' });
            }
        };
    </script>
</asp:Content>
