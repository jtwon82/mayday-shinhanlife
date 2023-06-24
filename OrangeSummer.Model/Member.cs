using MLib.Util;
using System;
using System.Data;

namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 회원관리 Model
    /// </summary>
    public class Member
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public string FkMember { get; set; }
        public int Sort { get; set; }
        public string FkBranch { get; set; }
        public string FkTravel { get; set; }
        public string Code { get; set; }
        public string Pwd { get; set; }
        public string PwdDecode { get; set; }
        public string Reset { get; set; }
        public string Level { get; set; }
        public string LevelName { get; set; }
        public string Name { get; set; }
        public string MemberName { get; set; }
        public string Mobile { get; set; }
        public string AdvertYn { get; set; }
        public string DelYn { get; set; }
        public string RegistDate { get; set; }
        public string ProfileImg { get; set; }
        public string BackgroundImg { get; set; }
        public string Reward { get; set; }

        public Branch Branch { get; set; }
        public Travel Travel { get; set; }
        public string achieveUrl { get; set; }

        public Achievement Achievement { get; set; }
        public Member getMember(DataRow dr)
        {
            return new Model.Member()
            {
                Total = Check.getValueInt(dr, "TOTAL"), // Convert.ToInt32(dr["TOTAL"].ToString()),
                Id = Check.getValue(dr, "ID"),
                FkMember = Check.getValue(dr, "ID"),
                FkBranch = Check.getValue(dr, "FK_BRANCH"),
                FkTravel = Check.getValue(dr, "FK_TRAVEL"),
                Sort = Check.getValueInt(dr, "SORT"), //Convert.ToInt32(dr["SORT"].ToString()),
                Code = Check.getValue(dr, "CODE"),
                Pwd = Check.getValue(dr, "PWD"),
                PwdDecode = Check.getValue(dr, "PWD_DECODE"),
                Reset = Check.getValue(dr, "RESET"),
                Level = Check.getValue(dr, "LEVEL_NAME"), //dr["LEVEL"].ToString(),
                LevelName = Check.getValue(dr, "LEVEL_NAME"), //dr["LEVEL_NAME"].ToString(),
                Name = Check.getValue(dr, "MEMBER_NAME"), //dr["NAME"].ToString(),
                MemberName = Check.getValue(dr, "MEMBER_NAME"), //dr["NAME"].ToString(),
                Mobile = Check.getValue(dr, "MOBILE"), //dr["MOBILE"].ToString(),
                DelYn = Check.getValue(dr, "DEL_YN"), //dr["DEL_YN"].ToString(),
                RegistDate = Check.getValue(dr, "REGIST_DATE"), //dr["REGIST_DATE"].ToString(),
                ProfileImg = Check.getValue(dr, "PROFILE_IMG"), //dr["PROFILE_IMG"].ToString(),
                BackgroundImg = Check.getValue(dr, "BACKGROUND_IMG"), //dr["BACKGROUND_IMG"].ToString(),
                Branch = new Model.Branch()
                {
                    Name = Check.getValue(dr, "BRANCH_NAME"), //dr["BRANCH_NAME"].ToString()
                },
                Travel = new Model.Travel()
                {
                },
            };

        }
    }
}
