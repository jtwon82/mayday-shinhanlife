using System;
using System.Data;
using MLib.Util;

namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.20
    /// 롤렛이벤트 Model
    /// </summary>
    public class Roulette
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public int Sort { get; set; }
        public string FkMember { get; set; }
        public string Result { get; set; }
        public string RegistDate { get; set; }
        public Member Member { get; set; }
        public Branch Branch { get; set; }

        public Roulette getRoulette(DataRow dr)
        {
            return new Model.Roulette()
            {
                Total = Convert.ToInt32(dr["TOTAL"].ToString()),
                Id = dr["ID"].ToString().ToUpper(),
                Sort = Convert.ToInt32(dr["SORT"].ToString()),
                FkMember = dr["FK_MEMBER"].ToString().ToUpper(),
                Result = dr["RESULT"].ToString(),
                RegistDate = dr["REGIST_DATE"].ToString(),
                Member = new Model.Member()
                {
                    Level = dr["LEVEL"].ToString(),
                    Code = dr["CODE"].ToString(),
                    Name = dr["MEMBER_NAME"].ToString(),
                    Mobile = dr["MOBILE"].ToString()
                },
                Branch = new Model.Branch()
                {
                    Name = dr["BRANCH_NAME"].ToString()
                }
            };
            //{
            //    Total = Check.getValueInt(dr, "TOTAL"), // Convert.ToInt32(dr["TOTAL"].ToString()),
            //    Id = Check.getValue(dr, "ID"),
            //    FkMember = Check.getValue(dr, "ID"),
            //    FkBranch = Check.getValue(dr, "FK_BRANCH"),
            //    FkTravel = Check.getValue(dr, "FK_TRAVEL"),
            //    Sort = Check.getValueInt(dr, "SORT"), //Convert.ToInt32(dr["SORT"].ToString()),
            //    Code = Check.getValue(dr, "CODE"),
            //    Pwd = Check.getValue(dr, "PWD"),
            //    PwdDecode = Check.getValue(dr, "PWD_DECODE"),
            //    Reset = Check.getValue(dr, "RESET"),
            //    Level = Check.getValue(dr, "LEVEL_NAME"), //dr["LEVEL"].ToString(),
            //    LevelName = Check.getValue(dr, "LEVEL_NAME"), //dr["LEVEL_NAME"].ToString(),
            //    Name = Check.getValue(dr, "MEMBER_NAME"), //dr["NAME"].ToString(),
            //    MemberName = Check.getValue(dr, "MEMBER_NAME"), //dr["NAME"].ToString(),
            //    Mobile = Check.getValue(dr, "MOBILE"), //dr["MOBILE"].ToString(),
            //    DelYn = Check.getValue(dr, "DEL_YN"), //dr["DEL_YN"].ToString(),
            //    RegistDate = Check.getValue(dr, "REGIST_DATE"), //dr["REGIST_DATE"].ToString(),
            //    ProfileImg = Check.getValue(dr, "PROFILE_IMG"), //dr["PROFILE_IMG"].ToString(),
            //    BackgroundImg = Check.getValue(dr, "BACKGROUND_IMG"), //dr["BACKGROUND_IMG"].ToString(),
            //    Branch = new Model.Branch()
            //    {
            //        Name = Check.getValue(dr, "BRANCH_NAME"), //dr["BRANCH_NAME"].ToString()
            //    },
            //    Travel = new Model.Travel()
            //    {
            //    },
            //};

        }
    }
}
