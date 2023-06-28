﻿using MLib.Util;
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
                                sb2.Append("<dl class='rank2'>");
                                sb2.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>");
                                sb2.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.BranchName}</em></span></dt>");
                                sb2.Append($"		<dd>{item.BranchCanp}</dd>");
                                sb2.Append("	</dl>");
                            }
                            else if (item.BranchRank == "1")
                            {
                                sb1.Append("<dl class='rank1'>");
                                sb1.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>");
                                sb1.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.BranchName}</em></span></dt>");
                                sb1.Append($"		<dd>{item.BranchCanp}</dd>");
                                sb1.Append("	</dl>");
                            }
                            else if (item.BranchRank == "3")
                            {
                                sb3.Append("<dl class='rank3'>");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankingbox_ico.png' alt=''></span>");
                                sb3.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.BranchName}</em></span></dt>");
                                sb3.Append($"		<dd>{item.BranchCanp}</dd>");
                                sb3.Append("	</dl>");
                            }
                            else if (Int32.Parse(item.BranchRank) < 11)
                            {
                                sb3.Append("<dl>");
                                sb3.Append("	<span class='icon'><img src='/resources/img/sub/ranking/rankinglist_ico.png' alt=''></span>");
                                sb3.Append($"		<dt><em>{item.BranchRank}위</em><span class='myName'><em>{item.BranchName}</em></span></dt>");
                                sb3.Append($"       <dd>{item.BranchCanp}</dd>");
                                sb3.Append("</dl>");
                            }
                            else
                            {
                                sb4.Append("<dl>");
                                sb4.Append("<span class='icon'><img src = '/resources/img/sub/ranking/rankinglist_ico.png' alt=''></span>");
                                sb4.Append($"<dt>{item.BranchRank}위</dt>");
                                sb4.Append($"<dd>{item.BranchCanp}</dd>");
                                sb4.Append("</dl>");
                            }
                            
                            index++;
                        }

                        sb.Append("<!-- 지점부문 -->");
                        sb.Append("<ul class='rankingUnit'>");
                        sb.Append("	<li>[날짜 기준] " + _date + "</li>");
                        //sb.Append("	<li>[ 단위 ]  캠페인 환산 CMIP</li>");
                        sb.Append("	<li>[ 단위 ] 환산 CANP</li>");
                        sb.Append("</ul>");
                        if (sb1.ToString() != "" || sb2.ToString() != "" || sb3.ToString() != "")
                        {
                            sb.Append("<div class=\"rankingBox point\">");
                            sb.Append(sb1.ToString() + sb2.ToString() + sb3.ToString());
                            sb.Append("</div>");
                        }
                        if (sb4.ToString() != "")
                        {
                            sb.Append("<div class=\"rankingList point\">");
                            sb.Append(sb4.ToString());
                            sb.Append("</div>");
                        }
                        _branch = sb.ToString();

                        Common.User.Paging paging = new Common.User.Paging("./", page, 10, 5, _total, "#tab6-move");
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