using MLib.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web2.UserApplication.ranking.point
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
                using (Access.Member biz = new Access.Member(OrangeSummer.Common.User.AppSetting.Connection))
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
                using (Access.Achievement biz = new Access.Achievement(Common.User.AppSetting.Connection))
                {

                    #region [ 지점 ]
                    sb.Clear();
                    sb1.Clear();
                    sb2.Clear();
                    sb3.Clear();
                    sb4.Clear();

                    List<Model.Achievement> branchs = biz.UserRanking_202306(page, 15, "BRANCH");
                    if (branchs != null)
                    {
                        DateTime dt = DateTime.Parse(branchs[0].Date);
                        _date = $"{dt.ToString("yyyy")}년 {dt.ToString("MM")}월 {dt.ToString("dd")}일";
                        _total = branchs[0].Total;
                        int index = 1;
                        foreach (Model.Achievement item in branchs)
                        {
                            string key = $"{item.BranchRank}|{item.BranchCanp}";
                            if (uniqueChk.ToString().Contains(key))
                            {
                                continue;
                            }
                            uniqueChk.Append(key);

                            if (item.BranchRank == "2")
                            {
                                sb2.Append("<dl class='rank2'>\n");
                                sb2.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb2.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.Branch.Name}</em></span></dt>\n");
                                sb2.Append($"		<dd>{item.BranchCanp}</dd>\n");
                                sb2.Append("	</dl>\n");
                            }
                            else if (item.BranchRank == "1")
                            {
                                sb1.Append("<dl class='rank1'>\n");
                                sb1.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb1.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.Branch.Name}</em></span></dt>\n");
                                sb1.Append($"		<dd>{item.BranchCanp}</dd>\n");
                                sb1.Append("	</dl>\n");
                            }
                            else if (item.BranchRank == "3")
                            {
                                sb3.Append("<dl class='rank3'>\n");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>\n");
                                sb3.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.Branch.Name}</em></span></dt>\n");
                                sb3.Append($"		<dd>{item.BranchCanp}</dd>\n");
                                sb3.Append("	</dl>\n");
                            }
                            else if (Int32.Parse(item.BranchRank) < 11)
                            {
                                sb3.Append("<dl>\n");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankinglist_ico.png' alt=''></span>\n");
                                sb3.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.Branch.Name}</em></span></dt>\n");
                                sb3.Append($"       <dd>{item.BranchCanp}</dd>\n");
                                sb3.Append("</dl>\n");
                            }
                            else
                            {
                                sb4.Append("<dl>\n");
                                sb4.Append("<span class='icon'><img src = '/resources/img/sub/ranking/rankinglist_ico.png' alt=''></span>\n");
                                sb4.Append($"<dt>{item.BranchRank}위</dt>\n");
                                sb4.Append($"<dd>{item.BranchCanp}</dd>\n");
                                sb4.Append("</dl>\n");
                            }
                            
                            index++;
                        }

                        sb.Append("<!-- 지점부문 -->\n");
                        sb.Append("<ul class='rankingUnit'>\n");
                        sb.Append("	<li>[날짜 기준] " + _date + "</li>\n");
                        //sb.Append("	<li>[ 단위 ]  캠페인 환산 CMIP</li>\n");
                        sb.Append("	<li>[ 단위 ] 환산 CANP</li>\n");
                        sb.Append("</ul>\n");
                        if (sb1.ToString() != "" || sb2.ToString() != "" || sb3.ToString() != "")
                        {
                            sb.Append("<div class=\"rankingBox  \">\n");
                            sb.Append(sb1.ToString() + sb2.ToString() + sb3.ToString());
                            sb.Append("</div>\n");
                        }
                        if (sb4.ToString() != "")
                        {
                            sb.Append("<div class=\"rankingList \">\n");
                            sb.Append(sb4.ToString());
                            sb.Append("</div>\n");
                        }
                        _branch = sb.ToString();

                        Common.User.Paging paging = new Common.User.Paging("./", page, 10, 5, _total, "#tab6-move\n");
                        _paging = paging.ToString();
                    }
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