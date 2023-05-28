using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLib.Util;
using Newtonsoft.Json;

namespace OrangeSummer.Web2flc.UserApplication.board.notice
{
    public partial class _default : System.Web.UI.Page
    {
        public string _json = null;

        protected int _total = 0;
        protected string _paging = string.Empty;
        private int _size = 10;
        private int _block = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageLoad();
            }
        }

        /// <summary>
        /// 관리자 리스트
        /// </summary>
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
                using (Business.Notice biz = new Business.Notice(Common.User.AppSetting.Connection))
                {
                    List<Model.Notice> list = biz.UserList(1, 10, "NOTICE");
                    if (list != null)
                    {
                        this.rptNoticeList.DataSource = list;
                        this.rptNoticeList.DataBind();
                    }

                    list = biz.UserList(page, _size, "NORMAL");
                    if (list != null)
                    {
                        this.rptList.DataSource = list;
                        this.rptList.DataBind();
                        _total = list[0].Total;
                    }

                    Common.User.Paging paging = new Common.User.Paging("./", page, _size, _block, _total);
                    _paging = paging.ToString();
                }

                #region [ 이벤트 배너 ]
                using (Business.Banner biz = new Business.Banner(Common.User.AppSetting.Connection))
                {
                    List<Model.Banner> list = biz.UserList("NOTICE");
                    if (list != null)
                    {
                        this.rptBannerList.DataSource = list;
                        this.rptBannerList.DataBind();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }

        /// <summary>
        /// 관리자 리스트 번호
        /// </summary>
        protected string ListNumber(object obj, int index)
        {
            int page = Check.IsNone(Request["page"], 1);
            int number = (Convert.ToInt32(obj) - _size * (page - 1) - index);
            return number.ToString();
        }

        /// <summary>
        /// 파라메터 조합
        /// </summary>
        /// <returns></returns>
        protected string Parameters()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("&page=" + Check.IsNone(Request["page"], "1"));

            return sb.ToString();
        }
    }
}