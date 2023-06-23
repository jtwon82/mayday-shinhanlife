using MLib.DataBase;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using MLib.Util;
using MLib.Logger;
using System.Text;

namespace OrangeSummer.Access
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 회원관리 Access
    /// </summary>
    public class Member
    {
        private string _connection = string.Empty;

        /// <summary>
        /// 회원관리 생성자
        /// </summary>
        public Member(string connection)
        {
            _connection = connection;
        }

        public List<Model.Banner> BackgroundInfo()
        {
            List<Model.Banner> lists = null;
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_BANNER_INFO"))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Banner>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Banner bn = new Model.Banner()
                        {
                            Type = dr["TYPE"].ToString(),
                            AttMobile = dr["ATT_MOBILE"].ToString()
                        };
                        lists.Add(bn);
                    }
                }
            }
            return lists;
        }

        #region [ 관리자 ]
        /// <summary>
        /// 회원관리 리스트
        /// </summary>
        public List<Model.Member> List(int page, int size, string branch, string level, string code, string mobile
            , string sdate, string edate, string name)
        {
            List<Model.Member> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_MOBILE", mobile));
            parameters.Add(new SqlParameter("@KEY_SDATE", sdate));
            parameters.Add(new SqlParameter("@KEY_EDATE", edate));
            parameters.Add(new SqlParameter("@KEY_MAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_LIST", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Member>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Member member = new Model.Member()
                        {
                            Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                            Id = dr["ID"].ToString().ToUpper(),
                            Sort = Convert.ToInt32(dr["SORT"].ToString()),
                            FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                            FkTravel = dr["FK_TRAVEL"].ToString().ToUpper(),
                            Code = dr["CODE"].ToString(),
                            Pwd = dr["PWD"].ToString(),
                            Reset = dr["RESET"].ToString(),
                            Level = dr["LEVEL"].ToString(),
                            Name = dr["NAME"].ToString(),
                            Mobile = dr["MOBILE"].ToString(),
                            DelYn = dr["DEL_YN"].ToString(),
                            RegistDate = dr["REGIST_DATE"].ToString(),
                            Branch = new Model.Branch()
                            {
                                Name = dr["BRANCH_NAME"].ToString()
                            }
                        };

                        lists.Add(member);
                    }
                }
            }

            return lists;
        }
        public List<Model.Member> List202302(int page, int size, string branch, string level, string code, string mobile
            , string sdate, string edate, string name)
        {
            List<Model.Member> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", page));
            parameters.Add(new SqlParameter("@SIZE", size));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_MOBILE", mobile));
            parameters.Add(new SqlParameter("@KEY_SDATE", sdate));
            parameters.Add(new SqlParameter("@KEY_EDATE", edate));
            parameters.Add(new SqlParameter("@KEY_MAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_LIST_202302", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Member>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Member member = new Model.Member().getMember(dr);
                        lists.Add(member);
                    }
                }
            }

            return lists;
        }

        /// <summary>
        /// 회원관리 엑셀
        /// </summary>
        public List<Model.Member> Excel(string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            List<Model.Member> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_MOBILE", mobile));
            parameters.Add(new SqlParameter("@KEY_SDATE", sdate));
            parameters.Add(new SqlParameter("@KEY_EDATE", edate));
            parameters.Add(new SqlParameter("@KEY_NAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_EXCEL", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Member>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Member member = new Model.Member().getMember(dr);
                        lists.Add(member);
                    }
                }
            }

            return lists;
        }
        public List<Model.Member> Excel202302(string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            List<Model.Member> lists = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PAGE", 1));
            parameters.Add(new SqlParameter("@SIZE", -1));
            parameters.Add(new SqlParameter("@KEY_BRANCH", branch));
            parameters.Add(new SqlParameter("@KEY_LEVEL", level));
            parameters.Add(new SqlParameter("@KEY_CODE", code));
            parameters.Add(new SqlParameter("@KEY_MOBILE", mobile));
            parameters.Add(new SqlParameter("@KEY_SDATE", sdate));
            parameters.Add(new SqlParameter("@KEY_EDATE", edate));
            parameters.Add(new SqlParameter("@KEY_MAME", name));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_LIST_202302", parameters))
            {
                if (dt.Rows.Count > 0)
                {
                    lists = new List<Model.Member>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.Member member = new Model.Member().getMember(dr);
                        lists.Add(member);
                    }
                }
            }

            return lists;
        }

        /// <summary>
        /// 회원관리 조회
        /// </summary>
        public Model.Member Detail(string id)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_DETAIL", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    member = new Model.Member()
                    {
                        Id = dr["ID"].ToString().ToUpper(),
                        Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                        FkTravel = dr["FK_TRAVEL"].ToString().ToUpper(),
                        Code = dr["CODE"].ToString(),
                        Pwd = dr["PWD"].ToString(),
                        Reset = dr["RESET"].ToString(),
                        Level = dr["LEVEL"].ToString(),
                        Name = dr["NAME"].ToString(),
                        Mobile = dr["MOBILE"].ToString(),
                        AdvertYn = dr["ADVERT_YN"].ToString(),
                        DelYn = dr["DEL_YN"].ToString(),
                        RegistDate = dr["REGIST_DATE"].ToString(),
                        Branch = new Model.Branch()
                        {
                            Name = dr["BRANCH_NAME"].ToString()
                        },
                        Travel = new Model.Travel()
                        {
                            Name = dr["TRAVEL_NAME"].ToString()
                        },
                        ProfileImg = dr["PROFILE_IMG"].ToString(),
                        BackgroundImg = dr["BACKGROUND_IMG"].ToString()
                    };
                }
            }

            return member;
        }
        public Model.Member Detail202302(string id)
        {
            Model.Member member = null;
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@CODE", code));
            //using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "ADM_MEMBER_DETAIL_202302", parameters))

            using (DataTable dt = DBHelper.ExecuteDataTableInQuery(_connection, $"exec ADM_MEMBER_DETAIL_202302 '{id}' "))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    member = new Model.Member().getMember(dr);
                }
            }

            return member;
        }

        /// <summary>
        /// 회원관리 삭제
        /// </summary>
        public bool Delete(string id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));

            return DBHelper.ExecuteNonQuery(_connection, "ADM_MEMBER_DELETE", parameters);
        }

        /// <summary>
        /// 회원관리 비밀번호 재설정
        /// </summary>
        public bool Reset(string id, string change_pwd)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            parameters.Add(new SqlParameter("@CHANGE_PWD", change_pwd));

            return DBHelper.ExecuteNonQuery(_connection, "ADM_MEMBER_RESET", parameters);
        }

        /// <summary>
        /// 회원 수정
        /// </summary>
        public bool Modify(Model.Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", member.Id));
            parameters.Add(new SqlParameter("@FK_BRANCH", member.FkBranch));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@DEL_YN", member.DelYn));

            return DBHelper.ExecuteNonQuery(_connection, "ADM_MEMBER_MODIFY", parameters);
        }
        #endregion

        #region [ 사용자 ]
        /// <summary>
        /// 회원 조회
        /// </summary>
        public Model.Member UserDetail(string id)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_DETAIL", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    member = new Model.Member()
                    {
                        Id = dr["ID"].ToString().ToUpper(),
                        Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                        FkTravel = dr["FK_TRAVEL"].ToString().ToUpper(),
                        Code = dr["CODE"].ToString(),
                        Pwd = dr["PWD"].ToString(),
                        Reset = dr["RESET"].ToString(),
                        Level = dr["LEVEL"].ToString(),
                        LevelName = dr["LEVEL_NAME"].ToString(),
                        Name = dr["NAME"].ToString(),
                        Mobile = dr["MOBILE"].ToString(),
                        DelYn = dr["DEL_YN"].ToString(),
                        RegistDate = dr["REGIST_DATE"].ToString(),
                        ProfileImg = dr["PROFILE_IMG"].ToString(),
                        BackgroundImg = dr["BACKGROUND_IMG"].ToString(),
                        Branch = new Model.Branch()
                        {
                            Name = dr["BRANCH_NAME"].ToString()
                        },
                        Travel = new Model.Travel()
                        {
                            AttPc = dr["BRANCH_ATT_PC"].ToString(),
                            AttMobile = dr["BRANCH_ATT_MOBILE"].ToString()
                        }
                    };
                }
            }

            return member;
        }

        public Model.Member UserDetail_new(string id)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_DETAIL_NEW", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    DateTime Tdt = DateTime.Parse( string.IsNullOrEmpty(dr["DATE"].ToString())?"0": dr["DATE"].ToString());

                    member = new Model.Member()
                    {
                        Id = dr["ID"].ToString().ToUpper(),
                        Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        Code = dr["CODE"].ToString(),
                        Pwd = dr["PWD"].ToString(),
                        Reset = dr["RESET"].ToString(),
                        Level = dr["LEVEL"].ToString(),
                        LevelName = dr["LEVEL_NAME"].ToString(),
                        Name = dr["NAME"].ToString(),
                        Mobile = dr["MOBILE"].ToString(),
                        DelYn = dr["DEL_YN"].ToString(),
                        RegistDate = dr["REGIST_DATE"].ToString(),
                        ProfileImg = dr["PROFILE_IMG"].ToString(),
                        BackgroundImg = dr["BACKGROUND_IMG"].ToString(),
                        Reward = Check.IsNone(dr["REWARD"].ToString()) ? "" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),

                        // DATE | COST2 | COST | CANP | REWARD | CMIP | PERSON_RANK | BRANCH_RANK | MY_REWARD

                        Branch = new Model.Branch()
                        {
                            Name = dr["BRANCH_NAME"].ToString()
                        },
                        Travel = new Model.Travel()
                        {
                            AttPc = dr["BRANCH_ATT_PC"].ToString(),
                            AttMobile = dr["BRANCH_ATT_MOBILE"].ToString()
                        },
                        Achievement = new Model.Achievement()
                        {
                            Date = $"{Tdt.ToString("yyyy")}년 {Tdt.ToString("MM")}월 {Tdt.ToString("dd")}일",
                            Cost2 = Check.IsNone(dr["COST2"].ToString()) ? "" : Convert.ToDecimal(dr["COST2"].ToString()).ToString("#,##0"),
                            Cost = Check.IsNone(dr["COST"].ToString()) ? "" : Convert.ToDecimal(dr["COST"].ToString()).ToString("#,##0"),
                            Canp = Check.IsNone(dr["CANP"].ToString()) ? "" : Convert.ToDecimal(dr["CANP"].ToString()).ToString("#,##0"),
                            Reward = Check.IsNone(dr["REWARD"].ToString()) ? "" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),
                            Cmip = Check.IsNone(dr["CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["CMIP"].ToString()).ToString("#,##0"),
                            PersonRank = dr["PERSON_RANK"].ToString(),
                            BranchRank = dr["BRANCH_RANK"].ToString(),
                            MyReward = Check.IsNone(dr["MY_REWARD"].ToString()) ? "0" : Convert.ToDecimal(dr["MY_REWARD"].ToString()).ToString("#,##0")
                        }
                    };
                }
            }

            return member;
        }

        public DataSet UserMyRewradDetail(string code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            return DBHelper.ExecuteDataSet(_connection, "USP_MYREWRAD_DETAIL", parameters);
        }
        public DataSet UserMyRewradDetail202302(string code)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            return DBHelper.ExecuteDataSet(_connection, "USP_MYREWRAD_DETAIL_202302", parameters);
        }
        public Model.Member UserDetail_202206(string code)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_DETAIL_202206", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    member = new Model.Member().getMember(dr);
                }
            }

            return member;
        }
        public Model.Member UserDetail202302(string code)
        {
            Model.Member member = null;

            StringBuilder query = new StringBuilder();
            query.Append($"SELECT T3.MEMBER_NAME MEMBER_NAME, T3.BRANCH_NAME, T3.MEMBER_NAME, T3.LEVEL_NAME ");
            query.Append($", dbo.UFNC_DECRYPT(T1.PWD)PWD, dbo.UFNC_DECRYPT(T1.PWD)PWD_DECODE, dbo.UFNC_DECRYPT(T1.[MOBILE]) AS [MOBILE] ");
            query.Append($", CASE WHEN T1.PROFILE_IMG IS NULL OR T1.PROFILE_IMG = '' THEN '/resources/img/index/main_person_img2.png' ELSE T1.PROFILE_IMG END PROFILE_IMG ");
            query.Append($", CASE WHEN T1.BACKGROUND_IMG IS NULL OR T1.BACKGROUND_IMG = '' THEN '/resources/img/index/backgroundImg.png' ELSE T1.BACKGROUND_IMG END BACKGROUND_IMG ");
            query.Append($", (SELECT SUM(PRICE)PRICE FROM( ");
            query.Append($"        SELECT 'PROMOTION'GB, A.* FROM REWRAD_PROMOTION A WHERE A.CODE = T1.CODE ");
            query.Append($"                    UNION ALL ");
            query.Append($"         SELECT 'CHARGE'GB, A.* FROM REWRAD_CHARGE A WHERE A.CODE = T1.CODE ");
            query.Append($"     )A ");
            query.Append($" ) MY_REWARD ");
            query.Append($", T1.*, T4.* ");
            query.Append($"FROM [MEMBER] AS T1 LEFT JOIN [MEMBER_BRANCH_202302] T3 ON T1.[CODE] = T3.[CODE] LEFT JOIN ACHIEVEMENT_202302 T4 ON T1.CODE = T4.CODE ");
            query.Append($"WHERE T1.[CODE] ='{code}' ");

            using (DataTable dt = DBHelper.ExecuteDataTableInQuery(_connection, query.ToString()))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        member = new Model.Member().getMember(dr);

                        string dateStr = "";

                        try
                        {
                            DateTime Tdt = DateTime.Parse(string.IsNullOrEmpty(dr["DATE"].ToString()) ? "0" : dr["DATE"].ToString());
                            dateStr = $"{Tdt.ToString("yyyy")}년 {Tdt.ToString("MM")}월 {Tdt.ToString("dd")}일";
                        }
                        catch (Exception e) { }

                        member.Achievement = new Model.Achievement()
                        {
                            Date = dateStr,
                            Cost2 = Check.IsNone(dr["COST2"].ToString()) ? "" : Convert.ToDecimal(dr["COST2"].ToString()).ToString("#,##0"),
                            Cost = Check.IsNone(dr["COST"].ToString()) ? "" : Convert.ToDecimal(dr["COST"].ToString()).ToString("#,##0"),
                            Canp = Check.IsNone(dr["CANP"].ToString()) ? "" : Convert.ToDecimal(dr["CANP"].ToString()).ToString("#,##0"),
                            Reward = Check.IsNone(dr["REWARD"].ToString()) ? "" : Convert.ToDecimal(dr["REWARD"].ToString()).ToString("#,##0"),
                            Cmip = Check.IsNone(dr["CMIP"].ToString()) ? "" : Convert.ToDecimal(dr["CMIP"].ToString()).ToString("#,##0"),
                            PersonRank= Check.IsNone(dr["PERSON_RANK"].ToString()) ? "" : Convert.ToDecimal(dr["PERSON_RANK"].ToString()).ToString("#,##0"),
                            BranchRank = dr["BRANCH_RANK"].ToString(),
                            MyReward = Check.IsNone(dr["MY_REWARD"].ToString()) ? "0" : Convert.ToDecimal(dr["MY_REWARD"].ToString()).ToString("#,##0")
                        };
                    }
                }
            }
            return member;
        }

        /// <summary>
        /// 회원 조회V2
        /// </summary>
        public Model.Member UserDetailV2(Model.Member _member)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", _member.Code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_CHECK", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];

                    string name = dr["NAME"].ToString();
                    string mobile = dr["MOBILE"].ToString();

                    if (name.Equals(_member.Name) && mobile.Equals(_member.Mobile) ) 
                    {
                        List<SqlParameter> parameters2 = new List<SqlParameter>();
                        parameters2.Add(new SqlParameter("@ID", dr["ID"].ToString().ToUpper()));
                        using (DataTable dt2 = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_DETAIL", parameters2))
                        {
                            if (dt2.Rows.Count == 1)
                            {
                                DataRow dr2 = dt2.Rows[0];
                                member = new Model.Member()
                                {
                                    Pwd = dr2["PWD"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return member;
        }

        /// <summary>
        /// 회원 전화번호 중복체크
        /// </summary>
        public string UserCheckPno(string pno)
        {
            string result = "FAIL";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MOBILE", pno));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_CHECK_PNO", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = dr["RESULT"].ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// 회원 코드 중복체크
        /// </summary>
        public string UserCheck(string code, string name)
        {
            string result = "FAIL";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NAME", name));
            parameters.Add(new SqlParameter("@CODE", code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_CHECK_202302", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = dr["RESULT"].ToString();
                }
            }

            return result;
        }
        public string UserCheck_202206(string code, string name)
        {
            string result = "FAIL";
            List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@NAME", name));
            parameters.Add(new SqlParameter("@CODE", code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_CHECK_202206", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = Check.getValue(dr, "RESULT");
                }
            }

            return result;
        }

        /// <summary>
        /// 회원 코드 중복체크V3
        /// </summary>
        public string UserCheckV3(string code, string name)
        {
            string result = "FAIL";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NAME", name));
            parameters.Add(new SqlParameter("@CODE", code));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_CHECKV3", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    result = dr["RESULT"].ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// 회원 로그인
        /// </summary>
        public Model.Member UserLogin(string code, string pwd)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            parameters.Add(new SqlParameter("@PWD", pwd));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_LOGIN", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];

                    member = new Model.Member()
                    {
                        Id = dr["ID"].ToString().ToUpper(),
                        Sort = Convert.ToInt32(dr["SORT"].ToString()),
                        FkBranch = dr["FK_BRANCH"].ToString().ToUpper(),
                        FkTravel = dr["FK_TRAVEL"].ToString().ToUpper(),
                        Code = dr["CODE"].ToString(),
                        Pwd = dr["PWD"].ToString(),
                        Reset = dr["RESET"].ToString(),
                        Level = dr["LEVEL"].ToString(),
                        LevelName = dr["LEVEL_NAME"].ToString(),
                        Name = dr["NAME"].ToString(),
                        Mobile = dr["MOBILE"].ToString(),
                        DelYn = dr["DEL_YN"].ToString(),
                        RegistDate = dr["REGIST_DATE"].ToString(),
                        ProfileImg = dr["PROFILE_IMG"].ToString(),
                        BackgroundImg = dr["BACKGROUND_IMG"].ToString(),
                        Branch = new Model.Branch()
                        {
                            Name = dr["BRANCH_NAME"].ToString()
                        }
                    };
                }
            }

            return member;
        }
        public Model.Member UserLogin_202206(string code, string pwd)
        {
            Model.Member member = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", code));
            parameters.Add(new SqlParameter("@PWD", pwd));
            using (DataTable dt = DBHelper.ExecuteDataTable(_connection, "USP_MEMBER_LOGIN_202206", parameters))
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];

                    member = new Model.Member().getMember(dr);
                }
            }

            return member;
        }

        /// <summary>
        /// 회원 등록
        /// </summary>
        public bool UserRegist(Model.Member member)
        {
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@ID", member.Id));
            //parameters.Add(new SqlParameter("@FK_BRANCH", ""));
            //parameters.Add(new SqlParameter("@FK_TRAVEL", ""));
            //parameters.Add(new SqlParameter("@CODE", member.Code));
            //parameters.Add(new SqlParameter("@PWD", member.Pwd));
            //parameters.Add(new SqlParameter("@RESET", "N"));
            //parameters.Add(new SqlParameter("@LEVEL", ""));
            //parameters.Add(new SqlParameter("@NAME", member.Name));
            //parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            //parameters.Add(new SqlParameter("@ADVERT_YN", member.AdvertYn));
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", member.Id));
            parameters.Add(new SqlParameter("@FK_BRANCH", member.Id));
            parameters.Add(new SqlParameter("@FK_TRAVEL", member.Id));
            parameters.Add(new SqlParameter("@CODE", member.Code));
            parameters.Add(new SqlParameter("@PWD", member.Pwd));
            parameters.Add(new SqlParameter("@RESET", member.Reset));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@NAME", member.Name));
            parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            parameters.Add(new SqlParameter("@ADVERT_YN", member.AdvertYn));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_REGIST", parameters);
        }
        public bool UserRegist_202206(Model.Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", member.Id));
            parameters.Add(new SqlParameter("@FK_BRANCH", member.Id));
            parameters.Add(new SqlParameter("@FK_TRAVEL", member.Id));
            parameters.Add(new SqlParameter("@CODE", member.Code));
            parameters.Add(new SqlParameter("@PWD", member.Pwd));
            parameters.Add(new SqlParameter("@RESET", member.Reset));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@NAME", member.Name));
            parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            parameters.Add(new SqlParameter("@ADVERT_YN", member.AdvertYn));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_REGIST_202206", parameters);
        }
        public bool UserRegist202302(Model.Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", member.Id));
            parameters.Add(new SqlParameter("@FK_BRANCH", member.Id));
            parameters.Add(new SqlParameter("@FK_TRAVEL", member.Id));
            parameters.Add(new SqlParameter("@CODE", member.Code));
            parameters.Add(new SqlParameter("@PWD", member.Pwd));
            parameters.Add(new SqlParameter("@RESET", member.Reset));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@NAME", member.Name));
            parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            parameters.Add(new SqlParameter("@ADVERT_YN", member.AdvertYn));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_REGIST_202302", parameters);
        }

        /// <summary>
        /// 회원 수정
        /// </summary>
        public bool UserModify(Model.Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", member.Id));
            parameters.Add(new SqlParameter("@FK_BRANCH", member.FkBranch));
            parameters.Add(new SqlParameter("@PWD", member.Pwd));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@NAME", member.Name));
            parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            parameters.Add(new SqlParameter("@PROFILE_IMG", member.ProfileImg));
            parameters.Add(new SqlParameter("@BACKGROUND_IMG", member.BackgroundImg));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_MODIFY", parameters);
        }
        public bool UserModify_202206(Model.Member member)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODE", member.Code));
            //parameters.Add(new SqlParameter("@FK_BRANCH", member.FkBranch));
            parameters.Add(new SqlParameter("@PWD", member.Pwd));
            parameters.Add(new SqlParameter("@LEVEL", member.Level));
            parameters.Add(new SqlParameter("@NAME", member.Name));
            parameters.Add(new SqlParameter("@MOBILE", member.Mobile));
            parameters.Add(new SqlParameter("@PROFILE_IMG", member.ProfileImg));
            parameters.Add(new SqlParameter("@BACKGROUND_IMG", member.BackgroundImg));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_MODIFY_202206", parameters);
        }

        /// <summary>
        /// 회원 여행지 수정
        /// </summary>
        public bool UserTravel(string id, string travel)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));
            parameters.Add(new SqlParameter("@FK_TRAVEL", travel));

            return DBHelper.ExecuteNonQuery(_connection, "USP_MEMBER_TRAVEL", parameters);
        }
        #endregion
    }
}
