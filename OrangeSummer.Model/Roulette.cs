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
                Result = dr["RESULT"].ToString().Split('_')[0],
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
        }
    }
}
