using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MLib.Util;

namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.16
    /// 관리자 Model
    /// </summary>
    public class Admin
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public int Sort { get; set; }
        public string FkAdmin { get; set; }
        public string Usr { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public string Reset { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UseYn { get; set; }
        public string DelYn { get; set; }
        public string RegistDate { get; set; }

        public Admin Adm { get; set; }

        public Admin getAdmin(DataRow dr)
        {
            return new Model.Admin()
            {
                Id = dr["ID"].ToString().ToUpper(),
                Sort = Check.getValueInt(dr, "SORT"), // Convert.ToInt32(dr["SORT"].ToString()),
                FkAdmin = Check.getValue(dr, "FK_ADMIN"),
                Usr = Check.getValue(dr, "USR"),
                Pwd = Check.getValue(dr, "PWD"),
                Phone = Check.getValue(dr, "PHONE"),
                Reset = Check.getValue(dr, "RESET"),
                Name = Check.getValue(dr, "NAME"), //dr["NAME"].ToString
                Email = Check.getValue(dr, "EMAIL"),
                UseYn = Check.getValue(dr, "USE_YN"),
                DelYn = Check.getValue(dr, "DEL_YN"), //dr["DEL_YN"].ToString(),
                RegistDate = Check.getValue(dr, "REGIST_DATE"), //dr["REGIST_DATE"].ToString(),

            };
        }
    }
}