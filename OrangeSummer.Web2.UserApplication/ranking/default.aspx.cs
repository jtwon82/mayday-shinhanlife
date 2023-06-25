using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLib.Util;
using Newtonsoft.Json;

namespace OrangeSummer.Web2.UserApplication.ranking
{
    public partial class _default : System.Web.UI.Page
    {
        public string _json = null;

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
                using (Business.Member biz = new Business.Member(OrangeSummer.Common.User.AppSetting.Connection))
                {
                    List<Model.Banner> list = biz.BackgroundInfo();
                    _json = JsonConvert.SerializeObject(list);
                }

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
                    #region [ 개인 ]
                    sb.Clear();
                    sb1.Clear();
                    sb2.Clear();
                    sb3.Clear();
                    sb4.Clear();

                    List<Model.Achievement> persons = biz.UserRanking_202306(1, 100, "PERSON");
                    if (persons != null)
                    {
                        DateTime dt = DateTime.Parse(persons[0].Date);
                        _date = $"{dt.ToString("yyyy")}년 {dt.ToString("MM")}월 {dt.ToString("dd")}일";
                        int index = 1;
                        foreach (Model.Achievement item in persons)
                        {
                            string key = $"{item.PersonRank}|";
                            if (uniqueChk.ToString().Contains(key))
                            {
                                continue;
                            }
                            uniqueChk.Append(key);

                            if (item.PersonRank == "2")
                            {
                                sb2.Append("<dl class='rank2'>\n");
                                sb2.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb2.Append($"	<dt><em>{item.PersonRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb2.Append($"	<dd>{item.Cost}</dd>\n");
                                sb2.Append("</dl>\n");
                            }
                            else if (item.PersonRank == "1")
                            {
                                sb1.Append("<dl class='rank1'>\n");
                                sb1.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb1.Append($"	<dt><em>{item.PersonRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb1.Append($"	<dd>{item.Cost}</dd>\n");
                                sb1.Append("</dl>\n");
                            }
                            else if (item.PersonRank == "3")
                            {
                                sb3.Append("<dl class='rank3'>\n");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb3.Append($"	<dt><em>{item.PersonRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb3.Append($"	<dd>{item.Cost}</dd>\n");
                                sb3.Append("</dl>\n");
                            }
                            else if (Int32.Parse(item.PersonRank) < 11)
                            {
                                sb3.Append("<dl>\n");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb3.Append($"	<dt><em>{item.PersonRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb3.Append($"	<dd>{item.Cost}</dd>\n");
                                sb3.Append("</dl>\n");
                            }
                            else {
                                sb4.Append("<dl>\n");
                                sb4.Append("<span class='icon'><img src = '/resources/img/sub/ranking/rankinglist_ico.png' alt=''></span>\n");
                                sb4.Append($"	<dt><em>{item.PersonRank}위</em><span class='myName'>{item.BranchName}<em> {item.MemberName}</em></span></dt>\n");
                                sb4.Append($"	<dd>{item.Cost}</dd>\n");
                                sb4.Append("</dl>\n");
                            }

                            index++;
                        }
                    }

                    sb.Append("<!-- 개인부문 -->\n");
                    sb.Append("<ul class='rankingUnit'>\n");
                    sb.Append("	<li>[날짜 기준] " + _date + "</li>\n");
                    sb.Append("	<li>[ 단위 ] 환산 CANP</li>\n");
                    sb.Append("</ul>\n");
                    if (sb1.ToString() != "" || sb2.ToString() != "" || sb3.ToString() != "") {
                        sb.Append("<div class=\"rankingBox\">\n");
                        sb.Append(sb1.ToString() + sb2.ToString() + sb3.ToString());
                        sb.Append("</div>\n");
                    }
                    if (sb4.ToString() != "")
                    {
                        sb.Append("<div class=\"rankingList\">\n");
                        sb.Append(sb4.ToString());
                        sb.Append("</div>\n");
                    }
                    _person = sb.ToString();

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