﻿using MLib.DataBase;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace OrangeSummer.Access
{
    /// <summary>
    /// 전윤기 - 2020.06.20
    /// 롤렛이벤트 Access
    /// </summary>
    public class Roulette : IDisposable
    {
        private string _connection = string.Empty;

        /// <summary>
        /// 롤렛이벤트 생성자
        /// </summary>
        public Roulette(string connection)
        {
            _connection = connection;
        }
        public bool UserCheck_202206(string member)
        {
            bool result = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FK_MEMBER", member));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ROULETTE_CHECK_202206", parameters))
            {
                if (dt.Rows.Count >= 1)
                    result = true;
            }

            return result;
        }
        //
        public bool UserCheckLog_202206(Model.Roulette roulette)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FK_MEMBER", roulette.FkMember));
            parameters.Add(new SqlParameter("@RESULT", roulette.Result));

            return DBHelper.ExecuteNonQuery(_connection, "USP_ROULETTE_CHECK_LOG_202206", parameters);
        }


        #region [ 관리자 ]
        /// <summary>
        /// 롤렛이벤트 리스트
        /// </summary>
        public List<Model.Roulette> List(int page, int size)
        {
            List<Model.Roulette> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ROULETTE_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Roulette>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Roulette roulette = new Model.Roulette().getRoulette(dr);
                        lists.Add(roulette);
                    }
                }
            }

            return lists;
        }
        public List<Model.Roulette> List_202306(int page, int size)
        {
            List<Model.Roulette> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ROULETTE_LIST_202306", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Roulette>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Roulette roulette = new Model.Roulette().getRoulette(dr);
                        lists.Add(roulette);
                    }
                }
            }

            return lists;
        }

        /// <summary>
        /// 롤렛이벤트 리스트
        /// </summary>
        public List<Model.Roulette> Excel()
        {
            List<Model.Roulette> lists = null;
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ROULETTE_EXCEL"))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Roulette>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Roulette roulette = new Model.Roulette().getRoulette(dr);
                        //{
                        //    Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                        //    Id = dr["ID"].ToString().ToUpper(),
                        //    Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        //    FkMember = dr["FK_MEMBER"].ToString().ToUpper(),
                        //    Result = dr["RESULT"].ToString(),
                        //    RegistDate = dr["REGIST_DATE"].ToString(),
                        //    Member = new Model.Member()
                        //    {
                        //        Level = dr["LEVEL"].ToString(),
                        //        Code = dr["CODE"].ToString(),
                        //        Name = dr["MEMBER_NAME"].ToString(),
                        //        Mobile = dr["MOBILE"].ToString()
                        //    },
                        //    Branch = new Model.Branch()
                        //    {
                        //        Name = dr["BRANCH_NAME"].ToString()
                        //    }
                        //};

                        lists.Add(roulette);
                    }
                }
            }

            return lists;
        }
        #endregion

        #region [ 사용자 ]
        /// <summary>
        /// 롤렛 담첨자 카운트
        /// </summary>
        /// <returns></returns>
        public Boolean UserSuccess()
        {
            Boolean result = false;
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ROULETTE_SUCCESS"))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = Convert.ToInt32(dr["RESULT"].ToString())==1;
                }
            }

            return result;
        }
        public int UserSuccessCnt()
        {
            int result = 0;
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ROULETTE_SUCCESS_202306"))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = Convert.ToInt32(dr["RESULT"]);
                }
            }

            return result;
        }

        /// <summary>
        /// 룰렛 사용자 참여 조회
        /// </summary>
        public bool UserCheck(string member)
        {
            bool result = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FK_MEMBER", member));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ROULETTE_CHECK", parameters))
            {
                if (dt.Rows.Count == 1)
                    result = true;
            }

            return result;
        }
        public bool UserCheck_202306(string member)
        {
            bool result = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FK_MEMBER", member));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ROULETTE_CHECK_202306", parameters))
            {
                if (dt.Rows.Count >= 1)
                    result = true;
            }

            return result;
        }

        /// <summary>
        /// 룰렛 등록
        /// </summary>
        public bool UserRegist(Model.Roulette roulette)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", roulette.Id));
            parameters.Add(new SqlParameter("@FK_MEMBER", roulette.FkMember));
            parameters.Add(new SqlParameter("@RESULT", roulette.Result));

            return DBHelper.ExecuteNonQuery(_connection, "USP_ROULETTE_REGIST", parameters);
        }
        public bool UserRegist_202306(Model.Roulette roulette)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", roulette.Id));
            parameters.Add(new SqlParameter("@FK_MEMBER", roulette.FkMember));
            parameters.Add(new SqlParameter("@RESULT", roulette.Result));

            return DBHelper.ExecuteNonQuery(_connection, "USP_ROULETTE_REGIST_202306", parameters);
        }
        #endregion


        public string getDbDate()
        {
            string result = "";
            using (DataTable dt = DBHelper.ExecuteDataTableInQuery(_connection, "SELECT CONVERT(VARCHAR, GETDATE(), 102) RESULT"))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = dr["RESULT"].ToString();
                }
            }

            return result;
        }

        public void Dispose()
        {
            _connection = null;
        }
    }

}
