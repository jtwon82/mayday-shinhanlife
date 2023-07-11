using System;
using System.Collections.Generic;
using System.Data;

namespace OrangeSummer.Business
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 업적관리 Business
    /// </summary>
    public class Achievement : IDisposable
    {
        private Access.Achievement _achievement = null;

        /// <summary>
        /// 업적관리 생성자
        /// </summary>
        public Achievement(string connection)
        {
            _achievement = new Access.Achievement(connection);
        }

        #region [ 관리자 ]
        /// <summary>
        /// 업적관리 리스트
        /// </summary>
        public List<Model.Achievement> List(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.List(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> List_new(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.List_new(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> List_202302(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.List_202302(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> List_202306(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.List_202306(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> ListRewradPromotion(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.ListRewradPromotion(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> ListRewradCharge(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.ListRewradCharge(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> List_202206(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.List_202206(page, size, orderby, branch, level, code, name);
        }
        public List<Model.Achievement> ListNsm_202206(int page, int size, string orderby, string branch, string level, string code, string name)
        {
            return _achievement.ListNsm_202206(page, size, orderby, branch, level, code, name);
        }
        #endregion

        /// <summary>
        /// 업적관리(임시) 등록
        /// </summary>
        public DataTable Regist(DataTable dt)
        {
            return _achievement.Regist(dt);
        }
        public DataTable Regist_new(DataTable dt)
        {
            return _achievement.Regist_new(dt);
        }
        public DataTable Regist_202306(DataTable dt)
        {
            return _achievement.Regist_202306(dt);
        }
        public DataTable RegistPromotion(DataTable dt)
        {
            return _achievement.RegistPromotion(dt);
        }
        public DataTable RegistCharge(DataTable dt)
        {
            return _achievement.RegistCharge(dt);
        }
        public DataTable Regist_202206(DataTable dt)
        {
            return _achievement.Regist_202206(dt);
        }
        public DataTable RegistNsm_202206(DataTable dt)
        {
            return _achievement.RegistNsm_202206(dt);
        }

        #region [ 사용자 ]
        /// <summary>
        /// 업적 리스트
        /// </summary>
        public Model.Achievement UserList(string code)
        {
            return _achievement.UserList(code);
        }
        #endregion

        #region [ 사용자2 ]
        /// <summary>
        /// 업적 리스트
        /// </summary>
        public List<Model.Achievement> UserList2(string code, string level)
        {
            return _achievement.UserList2(code, level);
        }
        public List<Model.Achievement> UserList_new(string code, string level)
        {
            return _achievement.UserList_new(code, level);
        }
        public List<Model.Achievement> UserList_202206(string code, string level)
        {
            return _achievement.UserList_202206(code, level);
        }
        public List<Model.Achievement> UserList_202306(string code, string level)
        {
            return _achievement.UserList_202306(code, level);
        }
        public List<Model.Achievement> UserListNsm_202206(string type)
        {
            return _achievement.UserListNsm_202206( type);
        }
        #endregion
        
        //#region [ 사용자2 fc ]
        ///// <summary>
        ///// 업적 리스트
        ///// </summary>
        //public List<Model.Achievement> UserList2FC(string code)
        //{
        //    return _achievement.UserList2FC(code);
        //}
        //#endregion

        /// <summary>
        /// 업적 랭킹
        /// </summary>
        public List<Model.Achievement> UserRanking(int page, int size, string part)
        {
            return _achievement.UserRanking(page, size, part);
        }
        public List<Model.Achievement> UserRanking_new(int page, int size, string part)
        {
            return _achievement.UserRanking_new(page, size, part);
        }
        public List<Model.Achievement> UserRanking_202206(int page, int size, string part)
        {
            return _achievement.UserRanking_202206(page, size, part);
        }
        public List<Model.Achievement> UserRanking_202306(int page, int size, string part)
        {
            return _achievement.UserRanking_202306(page, size, part);
        }

        /// <summary>
        /// 업적관리 소멸자
        /// </summary>
        public void Dispose()
        {
            _achievement = null;
        }

    }
}
