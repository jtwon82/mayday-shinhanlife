﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLib.Data;
using MLib.Util;
using OrangeSummer.Common;

namespace OrangeSummer.Web2.UserApplication.member.edit
{
    public partial class _default : System.Web.UI.Page
    {
        protected string _code = string.Empty;
        public string _id = Common.User.Identify.Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageLoad();
            }
        }

        private void PageLoad()
        {
            try
            {
                // 지점
                //using (Business.Branch biz = new Business.Branch(Common.User.AppSetting.Connection))
                //{
                //    List<Model.Branch> list = biz.Line();
                //    if (list != null)
                //    {
                //        this.branch.DataSource = list;
                //        this.branch.DataTextField = "Name";
                //        this.branch.DataValueField = "Id";
                //        this.branch.DataBind();
                //    }

                //    this.branch.Items.Insert(0, new ListItem("지점 선택", ""));
                //}

                // 신분
                Dictionary<string, string> dic = Code.MemberLevel;
                //this.level.DataSource = dic;
                //this.level.DataTextField = "Value";
                //this.level.DataValueField = "Key";
                //this.level.DataBind();
                //this.level.Items.Insert(0, new ListItem("신분 선택", ""));

                // 조회
                using (Business.Member biz = new Business.Member(Common.User.AppSetting.Connection))
                {
                    Model.Member member = biz.UserDetail202302(Common.User.Identify.Code);
                    if (member != null)
                    {
                        _code = member.Code;
                        Element.Set(this.hidbranch, member.FkBranch);
                        Element.Set(this.hidlevel, member.Level);
                        Element.Set(this.user_fccode, _code);
                        Element.Set(this.user_name, member.Name);
                        Element.Set(this.user_tel, member.Mobile);
                    }
                    else
                        JS.Move("로그인 후 이용해주세요.", "/member/login/");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        protected void btnEdit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Model.Member member = new Model.Member();
                member.Id = Common.User.Identify.Id;
                member.Code = Common.User.Identify.Code;
                member.FkBranch = Element.Get(this.hidbranch);
                member.Pwd = Element.Get(this.user_password);
                member.Level = Element.Get(this.hidlevel);
                member.Name = ""; // Element.Get(this.user_name);
                member.Mobile = ""; // Element.Get(this.user_tel);
                member.ProfileImg = "";
                member.BackgroundImg = "";
                using (Business.Member biz = new Business.Member(Common.User.AppSetting.Connection))
                {
                    bool result = biz.UserModify_202206(member);
                    if (result)
                        JS.Move("회원정보 수정이 완료되었습니다.", "./");
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }
    }
}