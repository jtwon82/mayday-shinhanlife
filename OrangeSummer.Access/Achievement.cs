using MLib.DataBase;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using MLib.Util;
using System.Text;

namespace OrangeSummer.Access
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 업적관리 Access
    /// </summary>
    public class Achievement : IDisposable
    {
        private string _connection = string.Empty;

        /// <summary>
        /// 업적관리 생성자
        /// </summary>
        public Achievement(string connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 업적관리(임시) 등록
        /// </summary>
        public DataTable Regist(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.ExecuteDataTableInQuery(_connection, "DELETE FROM [ACHIEVEMENT_TEMP12]");

            StringBuilder query_insert= new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [ACHIEVEMENT_TEMP12] (");
            query_insert.Append($"[ORDERBY], [DATE], [SECTOR_NAME], [BRANCH_NAME], [CODE], [NAME], [LEVEL]");
            query_insert.Append($", [PERSON_CMIP], [PERSON_CAMP], [PERSON_CANP]");
            query_insert.Append($", [SL_CMIP2], [SL_CMIP3], [SL_CMIP], [BRANCH_CMIP]");
            query_insert.Append($", [PERSON2_CMIP], [PERSON2_CAMP], [PERSON2_CANP]");
            query_insert.Append($", [PERSON_RANK], [SL_RANK2], [SL_RANK3], [SL_RANK], [BRANCH_RANK], [PERSON2_RANK]");
            query_insert.Append($")");

            query_select.Append($" SELECT * FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '' [DATE], '' [SECTOR_NAME], '' [BRANCH_NAME], '' [CODE], '' [NAME], '' [LEVEL]");
            query_select.Append($", 0 [PERSON_CMIP], 0 [PERSON_CAMP], 0 [PERSON_CANP]");
            query_select.Append($", 0 [SL_CMIP2], 0 [SL_CMIP3], 0 [SL_CMIP], 0 [BRANCH_CMIP]");
            query_select.Append($", 0 [PERSON2_CMIP], 0 [PERSON2_CAMP], 0 [PERSON2_CANP]");
            query_select.Append($", 0 [PERSON_RANK], 0 [SL_RANK2], 0 [SL_RANK3], 0 [SL_RANK], 0 [BRANCH_RANK], 0 [PERSON2_RANK]");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if(index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY], '{dr[id++].ToString()}' [DATE], '{dr[id++].ToString()}' [SECTOR_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_NAME], '{dr[id++].ToString()}' [CODE], '{dr[id++].ToString()}' [NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [LEVEL] ");

                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_CMIP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_CAMP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_CANP] ");

                    query_union.Append($", '{dr[id++].ToString()}' [SL_CMIP2] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SL_CMIP3] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SL_CMIP] ");

                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_CMIP] ");

                    query_union.Append($", '{dr[id++].ToString()}' [PERSON2_CMIP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON2_CAMP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON2_CANP] ");

                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_RANK] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SL_RANK2] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SL_RANK3] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SL_RANK] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_RANK] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON2_RANK] ");

                    //bool result = DBHelper.ExecuteNonQuery(_connection, "ADM_ACHIEVEMENT_REGIST", parameters);

                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");
            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
            
            return DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_CHECK12");
        }

        public DataTable Regist_new(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            // DBHelper.ExecuteNonInQuery(_connection, "ADM_ACHIEVEMENT_DELETE");
            DBHelper.ExecuteDataTableInQuery(_connection, "TRUNCATE TABLE ACHIEVEMENT_TEMP_202302 ");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [ACHIEVEMENT_TEMP_202302] (");
            query_insert.Append($"ORDERBY,DATE,CODE,BRANCH_NAME,MEMBER_NAME,LEVEL_NAME,COST,COST2,CANP,REWARD,CMIP,PERSON_RANK,BRANCH_RANK");
            query_insert.Append($")");

            query_select.Append($" SELECT ");
            query_select.Append($"ORDERBY,DATE,CODE,BRANCH_NAME,MEMBER_NAME,LEVEL_NAME,COST,COST2,CANP,REWARD,CMIP,PERSON_RANK,BRANCH_RANK ");
            query_select.Append($"FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '' [DATE] ");
            query_select.Append($", '' [SCOT], '' [BRANCH_NAME], '' [CODE], '' [MEMBER_NAME], '' [LEVEL_NAME]");
            query_select.Append($", 0 [COST], 0 [COST2], 0 [CANP], 0 [REWARD]");
            query_select.Append($", 0 [CMIP], 0 [PERSON_RANK], 0 [BRANCH_RANK]");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY], '{dr[id++].ToString()}' [DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SCOT] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CODE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [MEMBER_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [LEVEL_NAME] ");

                    query_union.Append($", '{dr[id++].ToString()}' [COST] ");
                    query_union.Append($", '{dr[id++].ToString()}' [COST2] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CANP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [REWARD] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CMIP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_RANK] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_RANK] ");

                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");
            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_CHECK_202302");
        }
        public DataTable Regist_202306(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            // DBHelper.ExecuteNonInQuery(_connection, "ADM_ACHIEVEMENT_DELETE");
            DBHelper.ExecuteDataTableInQuery(_connection, "TRUNCATE TABLE ACHIEVEMENT_TEMP_202306 ");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [ACHIEVEMENT_TEMP_202306] (");
            query_insert.Append($"ORDERBY,DATE,CODE,BRANCH_NAME,MEMBER_NAME,LEVEL_NAME,COST,COST2,CANP,REWARD,CMIP,PERSON_RANK,BRANCH_RANK");
            query_insert.Append($")");

            query_select.Append($" SELECT ");
            query_select.Append($"ORDERBY,DATE,CODE,BRANCH_NAME,MEMBER_NAME,LEVEL_NAME,COST,COST2,CANP,REWARD,CMIP,PERSON_RANK,BRANCH_RANK ");
            query_select.Append($"FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '' [DATE] ");
            query_select.Append($", '' [SCOT], '' [BRANCH_NAME], '' [CODE], '' [MEMBER_NAME], '' [LEVEL_NAME]");
            query_select.Append($", 0 [COST], 0 [COST2], 0 [CANP], 0 [REWARD]");
            query_select.Append($", 0 [CMIP], 0 [PERSON_RANK], 0 [BRANCH_RANK]");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY], '{dr[id++].ToString()}' [DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [SCOT] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CODE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [MEMBER_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [LEVEL_NAME] ");

                    query_union.Append($", '{dr[id++].ToString()}' [COST] ");
                    query_union.Append($", '{dr[id++].ToString()}' [COST2] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CANP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [REWARD] ");
                    query_union.Append($", '{dr[id++].ToString()}' [CMIP] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PERSON_RANK] ");
                    query_union.Append($", '{dr[id++].ToString()}' [BRANCH_RANK] ");

                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");
            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_CHECK_202302");
        }

        public DataTable RegistPromotion(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.ExecuteDataTableInQuery(_connection, "DELETE FROM [REWRAD_PROMOTION_TEMP]");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [REWRAD_PROMOTION_TEMP] (");
            query_insert.Append($"[ORDERBY], [CODE], [DATE], [TYPE_NAME], [UPDATE_DATE], [PRICE]");
            query_insert.Append($")");

            query_select.Append($" SELECT * FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '0' [CODE], '0' [DATE], '0' [TYPE_NAME], '0' [UPDATE_DATE], '0' [PRICE]");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY] ");
                    id++; id++;
                    query_union.Append($", '{dr[id++].ToString()}' [CODE] ");
                    id++;
                    query_union.Append($", '{dr[id++].ToString()}' [DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [TYPE_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [UPDATE_DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PRICE] ");

                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");
            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_PROMOTION_CHECK");
        }

        public DataTable Regist_202206(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.ExecuteDataTableInQuery(_connection, "DELETE FROM [ACHIEVEMENT_TEMP_202206]");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [ACHIEVEMENT_TEMP_202206] (");
            query_insert.Append($"[ORDERBY], [DATE] ");
            query_insert.Append($", [SECTOR_NAME], [BRANCH_NAME], [CODE], [NAME], [LEVEL]");
            query_insert.Append($", PERSON_CMIP, PERSON_CANP, PERSON_CNT, SL_CANP2, SL_CMIP2, SL_CANP3, SL_CMIP3, SL_CANP, SL_CMIP, BRANCH_CANP, BRANCH_CMIP, BRANCH_CMIP2, BRANCH_CANP2, PERSON2_CANP, PERSON2_CMIP, PERSON2_CNT, PERSON_RANK, SL_RANK2, SL_RANK3, SL_RANK, BRANCH_RANK, PERSON2_RANK ");
            query_insert.Append($")");

            query_select.Append($" SELECT * FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '' [DATE] ");
            query_select.Append($", '' [SECTOR_NAME], '' [BRANCH_NAME], '' [CODE], '' [NAME], '' [LEVEL] ");
            query_select.Append($", '' PERSON_CMIP, '' PERSON_CANP, '' PERSON_CNT, '' SL_CANP2, '' SL_CMIP2, '' SL_CANP3, '' SL_CMIP3, '' SL_CANP, '' SL_CMIP, '' BRANCH_CANP, '' BRANCH_CMIP, '' BRANCH_CMIP2, '' BRANCH_CANP2, '' PERSON2_CANP, '' PERSON2_CMIP, '' PERSON2_CNT, 0 PERSON_RANK, 0 SL_RANK2, 0 SL_RANK3, 0 SL_RANK, 0 BRANCH_RANK, 0 PERSON2_RANK ");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY], '{dr[id++].ToString()}' [DATE]");
                    query_union.Append($", '{dr[id++].ToString()}' [SECTOR_NAME], '{dr[id++].ToString()}' [BRANCH_NAME], '{dr[id++].ToString()}' [CODE], '{dr[id++].ToString()}' [NAME] , '{dr[id++].ToString()}' [LEVEL] ");

                    query_union.Append($", '{dr[id++].ToString()}' PERSON_CMIP   ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON_CANP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON_CNT	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CANP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CMIP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CANP3	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CMIP3	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CANP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_CMIP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CANP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CMIP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CMIP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CANP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON2_CANP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON2_CMIP	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON2_CNT	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON_RANK	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_RANK2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_RANK3	 ");
                    query_union.Append($", '{dr[id++].ToString()}' SL_RANK	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_RANK	 ");
                    query_union.Append($", '{dr[id++].ToString()}' PERSON2_RANK	 ");


                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        //new Log().Info("" + query_union.ToString());

                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");

            string tmp = query_insert.ToString() + query_union.ToString();
            //new Log().Info($"{tmp}");

            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_CHECK_202206");
        }

        public DataTable RegistNsm_202206(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.ExecuteDataTableInQuery(_connection, "DELETE FROM [ACHIEVEMENT_NSM_202206]");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [ACHIEVEMENT_NSM_202206] (");
            query_insert.Append($"[ORDERBY], [DATE] ");
            query_insert.Append($", BRANCH_NAME, BRANCH_CMIP2, BRANCH_CANP2, BRANCH_RANK ");
            query_insert.Append($")");

            query_select.Append($" SELECT * FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '' [DATE] ");
            query_select.Append($", '' BRANCH_NAME, '' BRANCH_CMIP2, '' BRANCH_CANP2, 0 BRANCH_RANK ");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY], '{dr[id++].ToString()}' [DATE]");
                    
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_NAME	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CMIP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_CANP2	 ");
                    query_union.Append($", '{dr[id++].ToString()}' BRANCH_RANK	 ");


                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        //new Log().Info("" + query_union.ToString());

                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");

            string tmp = query_insert.ToString() + query_union.ToString();

            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_NSM_CHECK_202206");
        }

        public List<Model.Achievement> List_202206(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST_202206", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> ListNsm_202206(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST_NSM_202206", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public DataTable RegistCharge(DataTable dt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            DBHelper.ExecuteDataTableInQuery(_connection, "DELETE FROM [REWRAD_CHARGE_TEMP]");

            StringBuilder query_insert = new StringBuilder();
            StringBuilder query_select = new StringBuilder();
            StringBuilder query_union = new StringBuilder();
            query_insert.Append($"INSERT INTO [REWRAD_CHARGE_TEMP] (");
            query_insert.Append($"[ORDERBY], [CODE], [DATE], [TYPE_NAME], [UPDATE_DATE], [PRICE]");
            query_insert.Append($")");

            query_select.Append($" SELECT * FROM ( SELECT ");
            query_select.Append($"0 [ORDERBY], '0' [CODE], '0' [DATE], '0' [TYPE_NAME], '0' [UPDATE_DATE], '0' [PRICE]");
            query_select.Append($"");

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (index % 500 == 1) query_union.Append(query_select);
                    int id = 0;

                    query_union.Append($" UNION ALL SELECT  ");
                    query_union.Append($"{index} [ORDERBY] ");
                    id++; id++;
                    query_union.Append($", '{dr[id++].ToString()}' [CODE] ");
                    id++;
                    query_union.Append($", '{dr[id++].ToString()}' [DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [TYPE_NAME] ");
                    query_union.Append($", '{dr[id++].ToString()}' [UPDATE_DATE] ");
                    query_union.Append($", '{dr[id++].ToString()}' [PRICE] ");

                    if (index % 500 == 0)
                    {
                        query_union.Append(") A WHERE [ORDERBY]>0");
                        DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());
                        query_union.Clear();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                index++;
            }

            query_union.Append(") A WHERE [ORDERBY]>0");
            DBHelper.ExecuteDataTableInQuery(_connection, query_insert.ToString() + query_union.ToString());

            return DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_CHARGE_CHECK");
        }

        /// <summary>
        /// 업적관리 리스트
        /// </summary>
        public List<Model.Achievement> List(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement()
                        {
                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Id = dr["ID"].ToString().ToUpper(),
                            Sort = Convert.ToInt32(dr["SORT"].ToString()),
                            Date = dr["DATE"].ToString(),
                            Part = dr["PART"].ToString(),
                            FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                            Code = dr["CODE"].ToString(),
                            Name = dr["NAME"].ToString(),
                            Level = dr["LEVEL"].ToString(),
                            PersonSum = dr["PERSON_SUM"].ToString(),

                            PersonCmip = Check.IsNone(dr["PERSON_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CMIP"].ToString()).ToString("#,##0"),
                            PersonCamp = Check.IsNone(dr["PERSON_CAMP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CAMP"].ToString()).ToString("#,##0"),
                            PersonCanp = Check.IsNone(dr["PERSON_CANP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CANP"].ToString()).ToString("#,##0"),
                            PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),

                            Person2Cmip = Check.IsNone(dr["PERSON2_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CMIP"].ToString()).ToString("#,##0"),
                            Person2Camp = Check.IsNone(dr["PERSON2_CAMP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CAMP"].ToString()).ToString("#,##0"),
                            Person2Canp = Check.IsNone(dr["PERSON2_CANP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CANP"].ToString()).ToString("#,##0"),
                            Person2Rank = Check.IsNone(dr["PERSON2_RANK"].ToString()) ? "" : dr["PERSON2_RANK"].ToString(),

                            PersonRank2 = Check.IsNone(dr["PERSON_RANK2"].ToString()) ? "" : dr["PERSON_RANK2"].ToString(),
                            LeaderCmip = Check.IsNone(dr["LEADER_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["LEADER_CMIP"].ToString()).ToString("#,##0"),
                            LeaderRank = Check.IsNone(dr["LEADER_RANK"].ToString()) ? "" : dr["LEADER_RANK"].ToString(),
                            BranchCmip = Check.IsNone(dr["BRANCH_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["BRANCH_CMIP"].ToString()).ToString("#,##0"),
                            BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString(),
                            SlCmip = Check.IsNone(dr["SL_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP"].ToString()).ToString("#,##0"),
                            SlRank = Check.IsNone(dr["SL_RANK"].ToString()) ? "" : dr["SL_RANK"].ToString(),

                            SlCmip2 = Check.IsNone(dr["SL_CMIP2"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP2"].ToString()).ToString("#,##0"),
                            SlCmip3 = Check.IsNone(dr["SL_CMIP3"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP3"].ToString()).ToString("#,##0"),
                            SlRank2 = Check.IsNone(dr["SL_RANK2"].ToString()) ? "" : dr["SL_RANK2"].ToString(),
                            SlRank3 = Check.IsNone(dr["SL_RANK3"].ToString()) ? "" : dr["SL_RANK3"].ToString(),

                            Branch = new Model.Branch()
                            {
                                Name = dr["BRANCH_NAME"].ToString()
                            }
                        };

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> List_new(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }
        public List<Model.Achievement> List_202302(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST_202302", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }
        public List<Model.Achievement> List_202306(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_ACHIEVEMENT_LIST_202306", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> ListRewradPromotion(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_PROMOTION_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement()
                        {
                            //TOTAL|ROW|CODE|BRANCH_CODE|BRANCH_NAME|MEMBER_NAME|LEVEL_NAME|DATE|TYPE_NAME|PRICE|ORDERBY

                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Code = dr["CODE"].ToString().ToUpper(),
                            MemberName = dr["MEMBER_NAME"].ToString().ToUpper(),
                            LevelName = dr["LEVEL_NAME"].ToString().ToUpper(),
                            Date = dr["DATE"].ToString(),
                            TypeName = dr["TYPE_NAME"].ToString().ToUpper(),
                            Price = dr["PRICE"].ToString().ToUpper(),
                            UpdateDate = dr["UPDATE_DATE"].ToString().ToUpper(),

                            Branch = new Model.Branch()
                            {
                                Name = dr["BRANCH_NAME"].ToString()
                            }
                        };

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }
        public List<Model.Achievement> ListRewradPromotion_202306(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_PROMOTION_LIST_202306", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> ListRewradCharge(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_CHARGE_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement()
                        {
                            //TOTAL|ROW|CODE|BRANCH_CODE|BRANCH_NAME|MEMBER_NAME|LEVEL_NAME|DATE|TYPE_NAME|PRICE|ORDERBY

                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Code = dr["CODE"].ToString().ToUpper(),
                            MemberName = dr["MEMBER_NAME"].ToString().ToUpper(),
                            LevelName = dr["LEVEL_NAME"].ToString().ToUpper(),
                            Date = dr["DATE"].ToString(),
                            TypeName = dr["TYPE_NAME"].ToString().ToUpper(),
                            Price = dr["PRICE"].ToString().ToUpper(),
                            UpdateDate = dr["UPDATE_DATE"].ToString().ToUpper(),

                            Branch = new Model.Branch()
                            {
                                Name = dr["BRANCH_NAME"].ToString()
                            }
                        };

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }
        public List<Model.Achievement> ListRewradCharge_202306(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@ORDERBY", orderby));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_REWRAD_CHARGE_LIST_202306", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }


        /// <summary>
        /// 업적관리 리스트
        /// </summary>
        public Model.Achievement UserList(string code)
        {
            Model.Achievement achievement = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_LIST", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    achievement = new Model.Achievement()
                    {
                        Id = dr["ID"].ToString().ToUpper(),
                        Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        Date = dr["DATE"].ToString(),
                        Part = dr["PART"].ToString(),
                        FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                        Code = dr["CODE"].ToString(),
                        Name = dr["NAME"].ToString(),
                        Level = dr["LEVEL"].ToString(),
                        PersonSum = dr["PERSON_SUM"].ToString(),
                        PersonCmip = Check.IsNone(dr["PERSON_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CMIP"].ToString()).ToString("#,##0"),
                        PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),
                        LeaderCmip = Check.IsNone(dr["LEADER_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["LEADER_CMIP"].ToString()).ToString("#,##0"),
                        LeaderRank = Check.IsNone(dr["LEADER_RANK"].ToString()) ? "" : dr["LEADER_RANK"].ToString(),
                        BranchCmip = Check.IsNone(dr["BRANCH_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["BRANCH_CMIP"].ToString()).ToString("#,##0"),
                        BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString(),
                        SlCmip = Check.IsNone(dr["SL_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP"].ToString()).ToString("#,##0"),
                        SlRank = Check.IsNone(dr["SL_RANK"].ToString()) ? "" : dr["SL_RANK"].ToString()
                    };
                }
            }

            return achievement;
        }

        /// <summary>
        /// 업적관리 리스트 List 
        /// </summary>
        public List<Model.Achievement> UserList2(string code, string level)
        {
            List<Model.Achievement> achievement = new List<Model.Achievement>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            parameters.Add(new SqlParameter("@LEVEL", level));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_LIST12", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement T = new Model.Achievement()
                        {
                            //Id = dr["ID"].ToString().ToUpper(),
                            //Sort = Convert.ToInt32(dr["SORT"].ToString()),
                            Date = dr["DATE"].ToString(),
                            ItsMe = dr["ITS_ME"].ToString(),
                            //Part = dr["PART"].ToString(),
                            //FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                            //Code = dr["CODE"].ToString(),
                            //Name = dr["NAME"].ToString(),
                            //Level = dr["LEVEL"].ToString(),
                            PersonSum = dr["PERSON_SUM"].ToString(),
                            PersonCmip = Check.IsNone(dr["PERSON_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CMIP"].ToString()).ToString("#,##0"),
                            PersonCamp = Check.IsNone(dr["PERSON_CAMP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CAMP"].ToString()).ToString("#,##0"),
                            PersonCanp = Check.IsNone(dr["PERSON_CANP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CANP"].ToString()).ToString("#,##0"),
                            PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),
                            PersonRank2 = Check.IsNone(dr["PERSON_RANK2"].ToString()) ? "" : dr["PERSON_RANK2"].ToString(),

                            Person2Cmip = Check.IsNone(dr["PERSON2_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CMIP"].ToString()).ToString("#,##0"),
                            Person2Camp = Check.IsNone(dr["PERSON2_CAMP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CAMP"].ToString()).ToString("#,##0"),
                            Person2Canp = Check.IsNone(dr["PERSON2_CANP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON2_CANP"].ToString()).ToString("#,##0"),
                            Person2Rank = Check.IsNone(dr["PERSON2_RANK"].ToString()) ? "" : dr["PERSON2_RANK"].ToString(),
                            
                            //LeaderCmip = Check.IsNone(dr["LEADER_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["LEADER_CMIP"].ToString()).ToString("#,##0"),
                            //LeaderRank = Check.IsNone(dr["LEADER_RANK"].ToString()) ? "" : dr["LEADER_RANK"].ToString(),
                            BranchCmip = Check.IsNone(dr["BRANCH_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["BRANCH_CMIP"].ToString()).ToString("#,##0"),
                            BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString(),
                            SlCmip = Check.IsNone(dr["SL_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP"].ToString()).ToString("#,##0"),
                            SlCmip2 = Check.IsNone(dr["SL_CMIP2"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP2"].ToString()).ToString("#,##0"),
                            SlCmip3 = Check.IsNone(dr["SL_CMIP3"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP3"].ToString()).ToString("#,##0"),
                            SlRank = Check.IsNone(dr["SL_RANK"].ToString()) ? "" : dr["SL_RANK"].ToString(),
                            SlRank2 = Check.IsNone(dr["SL_RANK2"].ToString()) ? "" : dr["SL_RANK2"].ToString(),
                            SlRank3 = Check.IsNone(dr["SL_RANK3"].ToString()) ? "" : dr["SL_RANK3"].ToString()
                        };
                        achievement.Add(T);
                    }
                }
            }

            return achievement;
        }

        
        public List<Model.Achievement> UserList_new(string code, string level)
        {
            List<Model.Achievement> achievement = new List<Model.Achievement>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            parameters.Add(new SqlParameter("@LEVEL", level));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_LIST12", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement T = new Model.Achievement()
                        {
                            Date = dr["DATE"].ToString(),
                            ItsMe = dr["ITS_ME"].ToString(),
                            Cost2 = Check.IsNone(dr["COST2"].ToString()) ? "" : Convert.ToDecimal(dr["COST2"].ToString()).ToString("#,##0"),
                            Cost = Check.IsNone(dr["COST"].ToString()) ? "" : Convert.ToDecimal(dr["COST"].ToString()).ToString("#,##0"),
                            Canp = Check.IsNone(dr["CANP"].ToString()) ? "" : Convert.ToDecimal(dr["CANP"].ToString()).ToString("#,##0"),
                            Reward = Check.IsNone(dr["REWARD"].ToString()) ? "" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),
                            Cmip = Check.IsNone(dr["CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["CMIP"].ToString()).ToString("#,##0"),
                            PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),
                            BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString()
                        };
                        achievement.Add(T);
                    }
                }
            }

            return achievement;
        }


        public List<Model.Achievement> UserList_202206(string code, string level)
        {
            List<Model.Achievement> achievement = new List<Model.Achievement>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            parameters.Add(new SqlParameter("@LEVEL", level));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_LIST_202206", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement T = new Model.Achievement().getAchievement(dr);
                        achievement.Add(T);
                    }
                }
            }

            return achievement;
        }
        public List<Model.Achievement> UserListNsm_202206(string type)
        {
            List<Model.Achievement> achievement = new List<Model.Achievement>();
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@CODE", code));
            //parameters.Add(new SqlParameter("@LEVEL", level));

            string sql = "";
            if (type == "")
            {
                sql = "select top 5 * from ACHIEVEMENT_NSM_202206 order by BRANCH_RANK";
            }
            else if (type == "list")
            {
                sql = "select * from ACHIEVEMENT_NSM_202206 where SORT not in (select top 5 SORT from ACHIEVEMENT_NSM_202206) order by BRANCH_RANK";
            }

            using (DataTable dt = DBHelper.ExecuteDataTableInQuery(_connection, sql))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement T = new Model.Achievement().getAchievement(dr);
                        achievement.Add(T);
                    }
                }
            }

            return achievement;
        }

        /// <summary>
        /// 업적 랭킹
        /// </summary>
        public List<Model.Achievement> UserRanking(int page, int size, string part)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            if (part.Contains("SL"))
            {
                parameters.Add(new SqlParameter("@PART", "SL"));
                parameters.Add(new SqlParameter("@LEVEL", part));
            }
            else
            {
                parameters.Add(new SqlParameter("@PART", part));
                parameters.Add(new SqlParameter("@LEVEL", ""));
            }
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_RANKING", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement()
                        {
                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Id = dr["ID"].ToString().ToUpper(),
                            Sort = Convert.ToInt32(dr["SORT"].ToString()),
                            Date = dr["DATE"].ToString(),
                            Part = dr["PART"].ToString(),
                            FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                            Code = dr["CODE"].ToString(),
                            Name = dr["NAME"].ToString(),
                            Level = dr["LEVEL"].ToString(),
                            PersonSum = dr["PERSON_SUM"].ToString(),
                            PersonCmip = Check.IsNone(dr["PERSON_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_CMIP"].ToString()).ToString("#,##0"),
                            PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),
                            LeaderCmip = Check.IsNone(dr["LEADER_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["LEADER_CMIP"].ToString()).ToString("#,##0"),
                            LeaderRank = Check.IsNone(dr["LEADER_RANK"].ToString()) ? "" : dr["LEADER_RANK"].ToString(),
                            BranchCmip = Check.IsNone(dr["BRANCH_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["BRANCH_CMIP"].ToString()).ToString("#,##0"),
                            BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString(),
                            SlCmip = Check.IsNone(dr["SL_CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP"].ToString()).ToString("#,##0"),
                            SlRank = Check.IsNone(dr["SL_RANK"].ToString()) ? "" : dr["SL_RANK"].ToString(),
                            SlCmip2 = Check.IsNone(dr["SL_CMIP2"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP2"].ToString()).ToString("#,##0"),
                            SlRank2 = Check.IsNone(dr["SL_RANK2"].ToString()) ? "" : dr["SL_RANK2"].ToString(),
                            SlCmip3 = Check.IsNone(dr["SL_CMIP3"].ToString()) ? "" : Convert.ToDecimal(dr["SL_CMIP3"].ToString()).ToString("#,##0"),
                            SlRank3 = Check.IsNone(dr["SL_RANK3"].ToString()) ? "" : dr["SL_RANK3"].ToString(),
                            Branch = new Model.Branch()
                            {
                                Name = dr["BRANCH_NAME"].ToString()
                            }
                        };

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> UserRanking_202206(int page, int size, string part)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            if (part.Contains("SL"))
            {
                parameters.Add(new SqlParameter("@PART", "SL"));
                parameters.Add(new SqlParameter("@LEVEL", part));
            }
            else
            {
                parameters.Add(new SqlParameter("@PART", part));
                parameters.Add(new SqlParameter("@LEVEL", ""));
            }
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_RANKING_202206", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }
        public List<Model.Achievement> UserRanking_202306(int page, int size, string part)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            if (part.Contains("SL"))
            {
                parameters.Add(new SqlParameter("@PART", "SL"));
                parameters.Add(new SqlParameter("@LEVEL", part));
            }
            else
            {
                parameters.Add(new SqlParameter("@PART", part));
                parameters.Add(new SqlParameter("@LEVEL", ""));
            }
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_RANKING_202306", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement().getAchievement(dr);
                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public List<Model.Achievement> UserRanking_new(int page, int size, string part)
        {
            List<Model.Achievement> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));

            parameters.Add(new SqlParameter("@PART", part));
            parameters.Add(new SqlParameter("@LEVEL", ""));

            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_ACHIEVEMENT_NEW_RANKING", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Achievement>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Achievement achievement = new Model.Achievement()
                        {
                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Date = dr["DATE"].ToString(),
                            Code = dr["CODE"].ToString(),

                            LevelName = dr["LEVEL_NAME"].ToString(),
                            MemberName = dr["MEMBER_NAME"].ToString(),
                            BranchName = dr["BRANCH_NAME"].ToString(),

                            Cost2 = Check.IsNone(dr["COST2"].ToString()) ? "" : Convert.ToDecimal(dr["COST2"].ToString()).ToString("#,##0"),
                            Cost = Check.IsNone(dr["COST"].ToString()) ? "" : Convert.ToDecimal(dr["COST"].ToString()).ToString("#,##0"),
                            Canp = Check.IsNone(dr["CANP"].ToString()) ? "" : Convert.ToDecimal(dr["CANP"].ToString()).ToString("#,##0"),
                            Reward = Check.IsNone(dr["REWARD"].ToString()) ? "" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),
                            Cmip = Check.IsNone(dr["CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["CMIP"].ToString()).ToString("#,##0"),

                            PersonRank = Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : dr["PERSON_RANK"].ToString(),
                            BranchRank = Check.IsNone(dr["BRANCH_RANK"].ToString()) ? "" : dr["BRANCH_RANK"].ToString()
                        };

                        lists.Add(achievement);
                    }
                }
            }

            return lists;
        }

        public void Dispose()
        {
            _connection = null;
        }
    }
}
