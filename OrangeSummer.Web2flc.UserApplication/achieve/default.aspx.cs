using MLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2flc.UserApplication.achieve
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Check.IsNone(Common.User.Identify.Id))
                {
                    Model.Member member = null;
                    using (Access.Member biz = new Access.Member(Common.Master.AppSetting.Connection))
                    {
                        member = biz.UserDetail_202306(Common.User.Identify.Code);

                        if (member != null)
                        {
                            if (member.Achievement.Part == "SL")
                            {
                                Tool.RR("/achieve/sl/");
                            }
                            else if (member.Achievement.Part == "PERSON")
                            {
                                Tool.RR("/achieve/bm/");
                            }
                            else
                            {
                                Tool.RR("/achieve/point/");
                            }
                        }
                        else
                        {
                            Tool.RR("/member/login");
                        }
                    }
                }
                else
                {
                    Tool.RR("/member/login");
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

    }
}