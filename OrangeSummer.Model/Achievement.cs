using MLib.Util;
using System;
using System.Data;

namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.19
    /// 업적관리 Model
    /// </summary>
    public class Achievement
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public string ItsMe { get; set; }
        public int Sort { get; set; }
        public string Date { get; set; }
        public string Part { get; set; }
        public string FkBranch { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public Branch Branch { get; set; }

        public string BranchName { get; set; }
        public string MemberName{ get; set; }
        public string LevelName{ get; set; }

        public string TypeName{ get; set; }
        public string Price{ get; set; }
        public string UpdateDate { get; set; }

        public string Cost2 { get; set; }
        public string Cost{ get; set; }
        public string Reward { get; set; }
        public string MyReward { get; set; }

        public string PersonSum { get; set; }
        public string PersonCmip { get; set; }
        public string PersonCamp { get; set; }
        public string PersonCanp { get; set; }
        public string PersonCnt { get; set; }
        public string PersonCanp2 { get; set; }
        
        public string PersonRank { get; set; }
        public string PersonRank2 { get; set; }

        public string BranchCanp { get; set; }
        public string BranchCanp2 { get; set; }
        public string BranchCmip { get; set; }
        public string BranchCmip2 { get; set; }
        public string BranchCnt{ get; set; }
        public string BranchPct { get; set; }
        public string BranchRank { get; set; }

        public string SlCanp{ get; set; }
        public string SlCmip { get; set; }
        public string SlCanp2 { get; set; }
        public string SlCmip2 { get; set; }
        public string SlCanp3 { get; set; }
        public string SlCmip3 { get; set; }
        public string SlRank { get; set; }
        public string SlRank2 { get; set; }
        public string SlRank3 { get; set; }

        public string Person2Cmip { get; set; }
        public string Person2Camp { get; set; }
        public string Person2Canp { get; set; }
        public string Person2Canp2 { get; set; }
        public string Person2Cnt { get; set; }
        public string Person2Rank { get; set; }
        public string Pct { get; set; }
        public string Cnt{ get; set; }

        public string Cmip { get; set; }
        public string Camp { get; set; }
        public string Canp { get; set; }
        public string Rank { get; set; }

        
        public string LeaderCmip { get; set; }
        public string LeaderRank { get; set; }
        //public string BranchRank { get; set; }
        //public string BranchCmip { get; set; }
        //public string SlRank { get; set; }
        //public string SlRank2 { get; set; }
        //public string SlRank3 { get; set; }
        //public string SlCmip { get; set; }
        //public string SlCmip2 { get; set; }
        //public string SlCmip3 { get; set; }
        //public Branch Branch { get; set; }

        public string Promotion { get; set; }
        public string Charge { get; set; }
        //public string Reward { get; set; }
        
        public Achievement getAchievement(DataRow dr)
        {
            return new Model.Achievement()
            {
                Total = Check.getValueInt(dr, "TOTAL"),
                ItsMe = Check.getValue(dr, "ITS_ME"),
                Date = Check.getValue(dr, "DATE"),
                Code = Check.getValue(dr, "CODE"),
                Name = Check.getValue(dr, "MEMBER_NAME"),
                MemberName = Check.getValue(dr, "MEMBER_NAME"),
                Level = Check.getValue(dr, "LEVEL_NAME"),
                LevelName = Check.getValue(dr, "LEVEL_NAME"),
                BranchName = Check.getValue(dr, "BRANCH_NAME"),
                Branch = new Model.Branch()
                {
                    Name = Check.getValue(dr, "BRANCH_NAME")
                },

                PersonCmip = Check.getValue(dr, "PERSON_CMIP", "#,##0"),
                PersonCanp = Check.getValue(dr, "PERSON_CANP", "#,##0"),
                PersonCnt = Check.getValueFormat(dr, "PERSON_CNT", "{0:0.0}"),

                SlCanp2= Check.getValue(dr, "SL_CANP2", "#,##0"),
                SlCmip2 = Check.getValue(dr, "SL_CMIP2", "#,##0"),
                SlCanp3= Check.getValue(dr, "SL_CANP3", "#,##0"),
                SlCmip3 = Check.getValue(dr, "SL_CMIP3", "#,##0"),
                SlCanp= Check.getValue(dr, "SL_CANP", "#,##0"),
                SlCmip = Check.getValue(dr, "SL_CMIP", "#,##0"),

                BranchCanp = Check.getValue(dr, "BRANCH_CANP", "#,##0"),
                BranchCmip = Check.getValue(dr, "BRANCH_CMIP", "#,##0"),
                BranchCmip2 = Check.getValueFormat(dr, "BRANCH_CMIP2", "{0:0.0}"),
                BranchCanp2 = Check.getValueFormat(dr, "BRANCH_CANP2", "{0:0.0}"),

                Person2Canp = Check.getValue(dr, "PERSON2_CANP", "#,##0"),
                Person2Cmip = Check.getValue(dr, "PERSON2_CMIP", "#,##0"),
                Person2Cnt= Check.getValue(dr, "PERSON2_CNT"),

                PersonRank = Check.getValue(dr, "PERSON_RANK"),
                SlRank2 = Check.getValue(dr, "SL_RANK2"),
                SlRank3 = Check.getValue(dr, "SL_RANK3"),
                SlRank = Check.getValue(dr, "SL_RANK"),
                BranchRank = Check.getValue(dr, "BRANCH_RANK"),
                Person2Rank = Check.getValue(dr, "PERSON2_RANK"),

                Cost2 = Check.getValue(dr, "COST2", "#,##0"),
                Cost = Check.getValue(dr, "COST", "#,##0"),
                Canp = Check.getValue(dr, "CANP", "#,##0"),
                Reward = Check.getValue(dr, "REWARD", "#,##0"),
                Cmip = Check.getValue(dr, "CMIP","#,##0"),

                TypeName = Check.getValue(dr, "TYPE_NAME"), //dr["TYPE_NAME"].ToString().ToUpper(),
                Price = Check.getValue(dr, "PRICE"), //dr["PRICE"].ToString().ToUpper(),
                UpdateDate = Check.getValue(dr, "UPDATE_DATE"), //dr["UPDATE_DATE"].ToString().ToUpper(),


            };
        }
    }
}