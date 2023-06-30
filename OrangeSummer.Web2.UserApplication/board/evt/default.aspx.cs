using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2.UserApplication.board.evt
{
    public partial class _default : System.Web.UI.Page
    {
        protected string _result = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (Access.Roulette biz = new Access.Roulette(Common.User.AppSetting.Connection))
                {
                    Random random = new Random();
                    bool check = true;

                    // 일자별 당첨인원 채크
                    if (biz.UserSuccessCnt()<=20)
                    {
                        // 기간내 당첨여부 채크
                        check = biz.UserCheck_202306(Common.User.Identify.Id);
                        if (check)
                            _result = "lose_1";
                        else
                        {
                            if (random.Next(1, 100)  <= 10)
                                _result = "win";
                            else
                                _result = "lose_2";
                        }
                    }
                    else
                        _result = "lose_3";
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }
    }
}