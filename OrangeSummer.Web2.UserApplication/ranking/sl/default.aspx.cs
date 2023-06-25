using MLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2.UserApplication.ranking.sl
{
    public partial class _default : System.Web.UI.Page
    {
        protected int _total = 0;
        protected string _date = string.Empty;
        protected string _person = string.Empty;
        protected string _sl = string.Empty;
        protected string _branch = string.Empty;
        protected string _paging = string.Empty;
        protected string _tab = string.Empty;

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
                int page = Check.IsNone(Request["page"], 1);
                _tab = Check.IsNone(Request["tab"], "");
                StringBuilder sb = new StringBuilder();

                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                StringBuilder sb3 = new StringBuilder();
                StringBuilder sb4 = new StringBuilder();
                StringBuilder uniqueChk = new StringBuilder();
                using (Business.Achievement biz = new Business.Achievement(Common.User.AppSetting.Connection))
                {
                    #region [ SL ]
                    sb.Clear();
                    sb1.Clear();
                    sb2.Clear();
                    sb3.Clear();
                    sb4.Clear();

                    List<Model.Achievement> sls = biz.UserRanking_202306(1, 100, "E SL");
                    if (sls != null)
                    {
                        DateTime dt = DateTime.Parse(sls[0].Date);
                        _date = $"{dt.ToString("yyyy")}년 {dt.ToString("MM")}월 {dt.ToString("dd")}일";
                        int index = 1;
                        foreach (Model.Achievement item in sls)
                        {
                            string key = $"{item.SlRank}|{item.SlCmip}";
                            if (uniqueChk.ToString().Contains(key))
                            {
                                continue;
                            }
                            uniqueChk.Append(key);

                            if (item.SlRank == "2")
                            {
                                sb2.Append("<dl class='rank2'>");
                                sb2.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb2.Append($"	<dt><em>{item.SlRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb2.Append($"	<dd>{item.SlCmip}</dd>\n");
                                sb2.Append("</dl>");
                            }
                            else if (item.SlRank == "1")
                            {
                                sb1.Append("<dl class='rank1'>");
                                sb1.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb1.Append($"	<dt><em>{item.SlRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb1.Append($"	<dd>{item.SlCmip}</dd>\n");
                                sb1.Append("</dl>");
                            }
                            else if (item.SlRank == "3")
                            {
                                sb3.Append("<dl class='rank3'>");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb3.Append($"	<dt><em>{item.SlRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb3.Append($"	<dd>{item.SlCmip}</dd>\n");
                                sb3.Append("</dl>");
                            }
                            else if (Int32.Parse(item.SlRank) < 11)
                            {
                                sb3.Append("<dl>");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb3.Append($"	<dt><em>{item.SlRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb3.Append($"	<dd>{item.SlCmip}</dd>\n");
                                sb3.Append("</dl>");
                            }
                            else
                            {
                                sb4.Append("<dl>");
                                sb4.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb4.Append($"	<dt><em>{item.SlRank}위</em></dt>\n");
                                sb4.Append($"	<dd>{item.SlCmip}</dd>\n");
                                sb4.Append("</dl>");
                            }
                            index++;
                        }
                    }

                    sb.Append("<ul class='rankingUnit'>");
                    sb.Append("	<li>[날짜 기준] " + _date + "</li>");
                    sb.Append("	<li>[ 단위 ] 환산 CANP</li>");
                    sb.Append("</ul>");
                    if (sb1.ToString() != "" || sb2.ToString() != "" || sb3.ToString() != "")
                    {
                        sb.Append("<div class=\"rankingBox\">");
                        sb.Append(sb1.ToString() + sb2.ToString() + sb3.ToString());
                        sb.Append("</div>");
                    }
                    if (sb4.ToString() != "")
                    {
                        sb.Append("<div class=\"rankingList\">");
                        sb.Append(sb4.ToString());
                        sb.Append("</div>");
                    }
                    _sl = sb.ToString();

                    #endregion

                }
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }
    }
}