using MLib.Logger;
using MLib.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2.UserApplication.achieve.bm
{
    public partial class _default : System.Web.UI.Page
    {
        protected string _pc = string.Empty;
        protected string _mobile = string.Empty;
        protected string _title = string.Empty;
        protected string _contents = string.Empty;

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
                #region [ 업적 ]
                using (Access.Achievement biz = new Access.Achievement(Common.User.AppSetting.Connection))
                {
                    StringBuilder title = new StringBuilder();
                    StringBuilder contents = new StringBuilder();
                    List<Model.Achievement> achievement = null;

                    if (",신인FC".Contains("," + Common.User.Identify.LevelName))
                    {
                        achievement = biz.UserList_202306(Common.User.Identify.Code, "신인FC");
                    }
                    else
                    {
                        achievement = biz.UserList_202306(Common.User.Identify.Code, "FC");
                    }

                    if (achievement != null)
                    {
                        foreach (Model.Achievement item in achievement)
                        {
                            DateTime dt;
                            string cdate;
                            try
                            {
                                dt = DateTime.Parse(item.Date);
                                cdate = $"{dt.ToString("yyyy")}년 {dt.ToString("MM")}월 {dt.ToString("dd")}일";
                            }
                            catch (Exception e)
                            {
                                cdate = "";
                            }

                            if (",FC,신인FC,SL,E SL,G SL,S SL".Contains("," + OrangeSummer.Common.User.Identify.LevelName))
                            {
                                string itsMe = item.ItsMe == "0" ? "전 순위 업적" : item.ItsMe == "1" ? "썸머순위" : item.ItsMe == "2" ? "후 순위 업적" : "";

                                if (",신인FC".Contains("," + OrangeSummer.Common.User.Identify.LevelName))
                                {
                                    item.Cmip = item.Person2Cmip;
                                    item.Camp = item.Person2Camp;
                                    item.Canp = item.Person2Canp;
                                    item.Rank = item.Person2Rank;
                                    item.Cnt = item.Person2Cnt;
                                }
                                else
                                {
                                    item.Cmip = item.PersonCmip;
                                    item.Camp = item.PersonCamp;
                                    item.Canp = item.PersonCanp;
                                    item.Rank = item.PersonRank;
                                    item.Cnt = item.PersonCnt;
                                }

                                contents.AppendLine($"<div class='swiper-slide slide{item.ItsMe}'>");
                                contents.AppendLine($"	<div class='bmRanking_box personal'>");
                                contents.AppendLine($"		<p><span>{cdate} 기준</span>{itsMe}<em>{item.Rank}</em></p>");
                                contents.AppendLine($"		<dl class='canp'>");
                                contents.AppendLine($"			<dt><span>환산</span>CANP</dt>");
                                contents.AppendLine($"			<dd class='cmip'>{item.Canp}</dd>");
                                contents.AppendLine($"		</dl>");
                                contents.AppendLine($"		<dl class='cmip'>");
                                contents.AppendLine($"			<dt>원 CMIP</dt>");
                                contents.AppendLine($"			<dd>{item.Cmip}</dd>");
                                contents.AppendLine($"		</dl>");
                                contents.AppendLine($"		<dl class='number'>");
                                contents.AppendLine($"			<dt>건수</dt>");
                                contents.AppendLine($"			<dd class='cmip'>{item.Cnt}</dd>");
                                contents.AppendLine($"		</dl>");
                                contents.AppendLine($"	</div>");
                                if (item.ItsMe == "0")
                                {
                                    contents.AppendLine($"	<div class='swiper-button-next'><span>내순위<span></div>");
                                    contents.AppendLine($"	<div class='swiper-button-prev'></div>");
                                }
                                else if (item.ItsMe == "1")
                                {
                                    contents.AppendLine($"	<div class='swiper-button-next'><span>뒷순위<span></div>");
                                    contents.AppendLine($"	<div class='swiper-button-prev'><span>앞순위<span></div>");
                                }
                                else if (item.ItsMe == "2")
                                {
                                    contents.AppendLine($"	<div class='swiper-button-next'></div>");
                                    contents.AppendLine($"	<div class='swiper-button-prev'><span>내순위<span></div>");
                                }
                                contents.AppendLine($"</div>");

                            }
                        }

                        _title = title.ToString();
                        _contents = contents.ToString();
                    }
                }
                #endregion

                //#region [ 여행지 ]
                //using (Business.Member biz = new Business.Member(Common.User.AppSetting.Connection))
                //{
                //    Model.Member member = biz.UserDetail(Common.User.Identify.Id);
                //    if (member != null)
                //    {
                //        _pc = member.Travel.AttPc;
                //        _mobile = member.Travel.AttMobile;
                //    }
                //}
                //#endregion

                //#region [ 이벤트 배너 ]
                //using (Business.Banner biz = new Business.Banner(Common.User.AppSetting.Connection))
                //{
                //    List<Model.Banner> list = biz.UserList("MAIN");
                //    if (list != null)
                //    {
                //        this.rptBannerList.DataSource = list;
                //        this.rptBannerList.DataBind();
                //    }
                //}
                //#endregion
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
                Tool.RR("/manager/login");
            }
        }
    }
}