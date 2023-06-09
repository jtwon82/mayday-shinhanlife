﻿using MLib.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrangeSummer.Web.MasterApplication.dash
{
    public partial class _default : System.Web.UI.Page
    {
        protected string _mtotal = string.Empty;
        protected string _mnew = string.Empty;
        protected string _aperson = string.Empty;
        protected string _apersoncamp = string.Empty;
        protected string _assl = string.Empty;
        protected string _agsl = string.Empty;
        protected string _aesl = string.Empty;
        protected string _abranch = string.Empty;
        protected string _pbranch = string.Empty;
        protected string _pname = string.Empty;
        protected string _SLbranch = string.Empty;
        protected string _SLname = string.Empty;
        protected string _SLbranch2 = string.Empty;
        protected string _SLname2 = string.Empty;
        protected string _SLbranch3 = string.Empty;
        protected string _SLname3 = string.Empty;
        protected string _bbranch = string.Empty;
        protected string _bname = string.Empty;
        protected Model.Achievement _achievement = new Model.Achievement();
        protected Model.Member _member = new Model.Member();
        protected Model.Member _member2 = new Model.Member();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PostLoad();
            }
        }

        private void PostLoad()
        {
            try
            {
                #region [ 업적현황 ]
                using (Business.Dash biz = new Business.Dash(Common.Master.AppSetting.Connection))
                {
                    DataSet ds = biz.Summary202302();

                    _member.Branch = new Model.Branch();
                    _member2.Branch = new Model.Branch();

                    try
                    {   // 회원 현황
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            _mtotal = Check.getValue(dr, "TOTAL", "#,##0"); // Convert.ToDecimal(dr["TOTAL"].ToString()).ToString("#,##0");
                            _mnew = Check.getValue(dr, "NEW", "#,##0"); // Convert.ToDecimal(dr["NEW"].ToString()).ToString("#,##0");
                        }
                        else
                        {
                            _mtotal = "0";
                            _mnew = "0";
                        }

                        // 업적 현황
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[1].Rows[0];
                            _achievement = new Model.Achievement().getAchievement(dr);

                            try
                            {
                                _aperson = Check.getValue(dr, "PERSON", "#,##0"); // Convert.ToDecimal(dr["PERSON"].ToString()).ToString("#,##0");
                                _apersoncamp = Check.getValue(dr, "PERSONCAMP", "#,##0"); // Convert.ToDecimal(dr["PERSONCAMP"].ToString()).ToString("#,##0");
                                _assl = Check.getValue(dr, "SSL", "#,##0"); // Convert.ToDecimal(dr["SSL"].ToString()).ToString("#,##0");
                                _agsl = Check.getValue(dr, "GSL", "#,##0"); // Convert.ToDecimal(dr["GSL"].ToString()).ToString("#,##0");
                                _aesl = Check.getValue(dr, "ESL", "#,##0"); // Convert.ToDecimal(dr["ESL"].ToString()).ToString("#,##0");
                                _abranch = Check.getValue(dr, "BRANCH", "#,##0"); // Convert.ToDecimal(dr["BRANCH"].ToString()).ToString("#,##0");
                            }
                            catch (Exception e) { }
                        }
                        else
                        {
                            _achievement = new Model.Achievement();
                            _aperson = "0";
                            _assl = "0";
                            _agsl = "0";
                            _aesl = "0";
                            _abranch = "0";
                        }

                        // 개인 1위
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[2].Rows[0];
                            _member = new Model.Member().getMember(dr);

                            try
                            {
                                _pbranch = Check.getValue(dr, "BRANCH_NAME"); //dr["BRANCH_NAME"].ToString().Replace("지점", "");
                                _pname = Check.getValue(dr, "NAME"); //dr["NAME"].ToString();
                            }
                            catch (Exception e) { }
                        }
                        else
                        {
                            _member = new Model.Member();
                            _member.Branch = new Model.Branch();
                            _pbranch = "0";
                            _pname = "0";
                        }

                        // 지점
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[3].Rows[0];
                            _member2 = new Model.Member().getMember(dr);

                            try
                            {
                                _SLbranch2 = Check.getValue(dr, "BRANCH_NAME"); //dr["BRANCH_NAME"].ToString().Replace("지점", "");
                                _SLname2 = Check.getValue(dr, "NAME"); //dr["NAME"].ToString();
                            }
                            catch (Exception e) { }
                        }
                        else
                        {
                            _member2 = new Model.Member();
                            _member2.Branch = new Model.Branch();
                            _SLbranch2 = "0";
                            _SLname2 = "0";
                        }

                    }catch(Exception e)
                    {

                    }

                    //// G SL 1위
                    //if (ds.Tables[4].Rows.Count > 0)
                    //{
                    //    DataRow dr = ds.Tables[4].Rows[0];
                    //    _SLbranch3 = dr["BRANCH_NAME"].ToString().Replace("지점", "");
                    //    _SLname3 = dr["NAME"].ToString();
                    //}
                    //else
                    //{
                    //    _SLbranch3 = "0";
                    //    _SLname3 = "0";
                    //}

                    //// E SL 1위
                    //if (ds.Tables[5].Rows.Count > 0)
                    //{
                    //    DataRow dr = ds.Tables[5].Rows[0];
                    //    _SLbranch = dr["BRANCH_NAME"].ToString().Replace("지점", "");
                    //    _SLname = dr["NAME"].ToString();
                    //}
                    //else
                    //{
                    //    _SLbranch = "0";
                    //    _SLname = "0";
                    //}

                    //// 지점 1위
                    //if (ds.Tables[6].Rows.Count > 0)
                    //{
                    //    DataRow dr = ds.Tables[6].Rows[0];
                    //    _bbranch = dr["BRANCH_NAME"].ToString().Replace("지점", "");
                    //    _bname = dr["NAME"].ToString();
                    //}
                    //else
                    //{
                    //    _bbranch = "0";
                    //    _bname = "0";
                    //}
                }
                #endregion

                #region [ 공지사항 ]
                using (Business.Notice biz = new Business.Notice(Common.Master.AppSetting.Connection))
                {
                    List<Model.Notice> list = biz.Main();
                    if (list != null)
                    {
                        this.rptNoticeList.DataSource = list;
                        this.rptNoticeList.DataBind();
                    }
                }
                #endregion

                #region [ 이벤트 ]
                using (Business.Event biz = new Business.Event(Common.Master.AppSetting.Connection))
                {
                    List<Model.Event> list = biz.Main();
                    if (list != null)
                    {
                        this.rptEventList.DataSource = list;
                        this.rptEventList.DataBind();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MLib.Util.Error.WebHandler(ex);
            }
        }
    }
}