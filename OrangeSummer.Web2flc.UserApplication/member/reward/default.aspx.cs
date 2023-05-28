using MLib.Logger;
using MLib.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2flc.UserApplication.member.reward
{
    public partial class _default : System.Web.UI.Page
    {
        public string _json = null;
        public string _reward = "";

        public Model.Member _member = null;
        public Model.Achievement _achievement = null;
        public List<Model.Achievement> _promotionList = null;
        public List<Model.Achievement> _chargeList = null;

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
                _reward = Check.IsNone(Request["reward"], false);

                using (Business.Member biz = new Business.Member(OrangeSummer.Common.User.AppSetting.Connection))
                {
                    List<Model.Banner> list = biz.BackgroundInfo();
                    _json = JsonConvert.SerializeObject(list);
                }

                if (!Check.IsNone(Common.User.Identify.Id))
                {
                    using (Business.Member biz = new Business.Member(Common.Master.AppSetting.Connection))
                    {
                        _promotionList = new List<Model.Achievement>();
                        _chargeList = new List<Model.Achievement>();

                        DataSet ds = biz.UserMyRewradDetail202302(Common.User.Identify.Code);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            
                            DateTime Tdt = DateTime.Parse(dr["UPDATE_DATE"].ToString());
                            try
                            {
                                _achievement = new Model.Achievement()
                                {
                                    Date = $"{Tdt.ToString("yyyy")}년 {Tdt.ToString("MM")}월 ",
                                    Reward = Check.IsNone(dr["REWARD"].ToString()) ? "0" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),
                                    MyReward = Check.IsNone(dr["MY_REWARD"].ToString()) ? "0" : Convert.ToDecimal(dr["MY_REWARD"].ToString()).ToString("#,##0"),
                                    Promotion = Check.IsNone(dr["PROMOTION"].ToString()) ? "0" : Convert.ToDecimal(dr["PROMOTION"].ToString()).ToString("#,##0"),
                                    Charge = Check.IsNone(dr["CHARGE"].ToString()) ? "0" : Convert.ToDecimal(dr["CHARGE"].ToString()).ToString("#,##0")
                                };
                            }catch(Exception e)
                            {
                                _achievement = new Model.Achievement()
                                {
                                    Date = $"{Tdt.ToString("yyyy")}년 {Tdt.ToString("MM")}월 ",
                                    Reward="0",
                                    MyReward = "0",
                                    Promotion = "0",
                                    Charge = "0"
                                };
                            }
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt = ds.Tables[1];
                            
                            foreach (DataRow dr in dt.Rows)
                            {
                                Model.Achievement achievement = new Model.Achievement()
                                {
                                    Date = dr["DATE"].ToString(),
                                    TypeName = dr["TYPE_NAME"].ToString(),
                                    Price = Check.IsNone(dr["PRICE"].ToString()) ? "" : Convert.ToDecimal(dr["PRICE"].ToString()).ToString("#,##0")
                                };
                                
                                if(dr["GB"].ToString() == "PROMOTION")
                                {
                                    _promotionList.Add(achievement);
                                }
                                else
                                {
                                    _chargeList.Add(achievement);
                                }
                            }

                            if (_promotionList != null)
                            {
                                this.promotionList.DataSource = _promotionList;
                                this.promotionList.DataBind();
                            }
                            if (_chargeList != null)
                            {
                                this.chargeList.DataSource = _chargeList;
                                this.chargeList.DataBind();
                            }
                        }

                    }
                }
                else
                {
                    _member = new Model.Member();
                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

    }
}