
using MLib.Util;
using System;
using System.Data;

namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 지점관리 Model
    /// </summary>
    public class Branch
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public int Sort { get; set; }
        public string FkAdmin { get; set; }
        public string FkTravel { get; set; }
        public string Name { get; set; }
        public string DelYn { get; set; }
        public string RegistDate { get; set; }

        public Admin Admin { get; set; }
        public Travel Travel { get; set; }
        public Branch getBranch(DataRow dr)
        {
            return new Model.Branch()
            {
                Total = Check.getValueInt(dr, "TOTAL"),
                //Id = dr["ID"].ToString().ToUpper(),
                Sort = Check.getValueInt(dr, "SORT"),
                FkAdmin = Check.getValue(dr, "FK_ADMIN"), //dr["FK_ADMIN"].ToString(),
                FkTravel = Check.getValue(dr, "FK_TRAVEL"), //dr["FK_TRAVEL"].ToString(),
                Name = Check.getValue(dr, "BRANCH_NAME"), //dr["BRANCH_NAME"].ToString(),
                DelYn = Check.getValue(dr, "DEL_YN"), //dr["DEL_YN"].ToString(),
                RegistDate = Check.getValue(dr, "REGIST_DATE"), //dr["REGIST_DATE"].ToString()
            };
            //{
            //    Total = Check.getValueInt(dr, "TOTAL"), // Convert.ToInt32(dr["TOTAL"].ToString()),
            //    Id = dr["ID"].ToString().ToUpper(),
            //    FkMember = Check.getValue(dr, "ID"),
            //    FkBranch = Check.getValue(dr, "FK_BRANCH"),
            //    Sort = Convert.ToInt32(dr["SORT"].ToString()),
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
