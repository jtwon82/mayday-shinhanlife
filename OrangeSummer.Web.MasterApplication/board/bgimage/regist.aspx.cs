using MLib.Attach;
using MLib.Data;
using MLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web.MasterApplication.board.bgimage
{
    public partial class regist : System.Web.UI.Page
    {
        protected string _command = string.Empty;
        protected string _admName = string.Empty;
        protected string _registDate = string.Empty;

        private string _type = "MAIN";
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
                string id = Check.IsNone(Request["id"], false);

                if (!Check.IsNone(id))
                {
                    Model.Banner banner = null;
                    using (Business.Banner biz = new Business.Banner(Common.Master.AppSetting.Connection))
                    {
                        banner = biz.DetailBackground(id, "");
                        if (banner != null)
                        {
                            _command = "mod";
                            _registDate = banner.RegistDate;
                            _admName = banner.Admin.Name;

                            Element.Set(this.Type, banner.Type);
                            Element.Set(this.title, banner.Title);
                            Element.Set(this.mobiled, banner.AttMobile);
                            Element.Set(this.useyn, banner.UseYn);
                            this.imobile.ImageUrl = Common.Master.AppSetting.AwsUrl(banner.AttMobile);
                            this.imobile.Visible = true;

                            this.btnModify.Visible = true;
                            this.btnDelete.Visible = true;
                        }
                        else
                        {
                            _command = "add";
                            this.btnRegist.Visible = true;
                        }
                    }
                }
                else
                {
                    _command = "add";
                    this.btnRegist.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        protected void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                string pc = string.Empty;
                string mobile = string.Empty;
                string ext = string.Empty;

                ext = System.IO.Path.GetExtension(this.mobile.PostedFile.FileName).ToLower();
                if (!Check.IsNone(ext))
                {
                    if (ext != ".jpg" && ext != ".png")
                        JS.Back("jpg, png파일만 업로드 가능합니다.");

                    HttpUpload upload2 = new HttpUpload(this.mobile.PostedFile);
                    upload2.Attached();
                    if (upload2.Result)
                        mobile = upload2.FIleFullPath();
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }

                Model.Banner banner = new Model.Banner();
                banner.Id = Tool.UniqueNewGuid;
                banner.FkAdmin = Common.Master.Identify.Id;
                banner.Type = Element.Get(this.Type);
                banner.Title = Element.Get(this.title);
                banner.AttPc = pc;
                banner.AttMobile = mobile;
                banner.UseYn = Element.Get(this.useyn);
                using (Business.Banner biz = new Business.Banner(Common.Master.AppSetting.Connection))
                {
                    bool result = biz.RegistBackground(banner);
                    if (result)
                        Tool.RR("./");
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Check.IsNone(Request["id"], true);
                string pc = string.Empty;
                string mobile = string.Empty;
                string mobiled = Element.Get(this.mobiled);
                string ext = string.Empty;

                // 모바일 이미지
                ext = System.IO.Path.GetExtension(this.mobile.PostedFile.FileName).ToLower();
                if (!Check.IsNone(ext))
                {
                    if (ext != ".jpg" && ext != ".png")
                        JS.Back("jpg, png파일만 업로드 가능합니다.");

                    HttpUpload upload2 = new HttpUpload(this.mobile.PostedFile);
                    upload2.Attached();
                    if (upload2.Result)
                        mobile = upload2.FIleFullPath();
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }
                else
                    mobile = mobiled;

                Model.Banner banner = new Model.Banner();
                banner.Id = id;
                banner.Type = Element.Get(this.Type);
                banner.Title = Element.Get(this.title);
                banner.AttMobile = mobile;
                banner.UseYn = Element.Get(this.useyn);
                using (Business.Banner biz = new Business.Banner(Common.Master.AppSetting.Connection))
                {
                    bool result = biz.ModifyBackground(banner);
                    if (result)
                        JS.Move("수정되었습니다.", $"regist.aspx?id={id}{Parameters()}");
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Check.IsNone(Request["id"], true);
                using (Business.Banner biz = new Business.Banner(Common.Master.AppSetting.Connection))
                {
                    bool result = biz.DeleteBackground(id, _type);
                    if (result)
                        Tool.RR($"./?command=list{Parameters()}");
                    else
                        JS.Back("처리중 에러가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        /// <summary>
        /// 파라메터 조합
        /// </summary>
        /// <returns></returns>
        protected string Parameters()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("&page=" + Check.IsNone(Request["page"], "1"));

            return sb.ToString();
        }
    }
}