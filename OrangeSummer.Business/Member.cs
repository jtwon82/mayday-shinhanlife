using System;
using System.Collections.Generic;
using System.Data;

namespace OrangeSummer.Business
{
    /// <summary>
    /// 전윤기 - 2020.06.18
    /// 회원관리 Business
    /// </summary>
    public class Member : IDisposable
    {
        private Access.Member _member = null;

        /// <summary>
        /// 회원관리 생성자
        /// </summary>
        public Member(string connection)
        {
            _member = new Access.Member(connection);
        }

        public List<Model.Banner> BackgroundInfo()
        {
            return _member.BackgroundInfo();
        }

        #region [ 관리자 ]
        /// <summary>
        /// 회원관리 리스트
        /// </summary>
        public List<Model.Member> List(int page, int size, string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            return _member.List(page, size, branch, level, code, mobile, sdate, edate, name);
        }
        public List<Model.Member> List202302(int page, int size, string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            return _member.List202302(page, size, branch, level, code, mobile, sdate, edate, name);
        }

        /// <summary>
        /// 회원관리 엑셀
        /// </summary>
        public List<Model.Member> Excel(string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            return _member.Excel(branch, level, code, mobile, sdate, edate, name);
        }
        public List<Model.Member> Excel202302(string branch, string level, string code, string mobile, string sdate, string edate, string name)
        {
            return _member.Excel202302(branch, level, code, mobile, sdate, edate, name);
        }

        /// <summary>
        /// 회원관리 조회
        /// </summary>
        public Model.Member Detail(string id)
        {
            return _member.Detail(id);
        }
        public Model.Member Detail202302(string id)
        {
            return _member.Detail202302(id);
        }

        /// <summary>
        /// 회원관리 삭제
        /// </summary>
        public bool Delete(string id)
        {
            return _member.Delete(id);
        }

        /// <summary>
        /// 회원관리 비밀번호 재설정
        /// </summary>
        public bool Reset(string id, string change_pwd)
        {
            return _member.Reset(id, change_pwd);
        }

        /// <summary>
        /// 회원관리 수정
        /// </summary>
        public bool Modify(Model.Member member)
        {
            return _member.Modify(member);
        }
        #endregion

        #region [ 사용자 ]
        /// <summary>
        /// 회원 조회
        /// </summary>
        public Model.Member UserDetail(string id)
        {
            return _member.UserDetail(id);
        }
        public Model.Member UserDetail_new(string id)
        {
            return _member.UserDetail_new(id);
        }
        public DataSet UserMyRewradDetail(string code)
        {
            return _member.UserMyRewradDetail(code);
        }
        public DataSet UserMyRewradDetail202302(string code)
        {
            return _member.UserMyRewradDetail202302(code);
        }
        public Model.Member UserDetail_202206(string id)
        {
            return _member.UserDetail_202206(id);
        }
        public Model.Member UserDetail202302(string code)
        {
            return _member.UserDetail202302(code);
        }
        public Model.Member UserDetail_202306(string code)
        {
            return _member.UserDetail_202306(code);
        }
        /// <summary>
        /// 회원 조회
        /// </summary>
        public Model.Member UserDetailV2(Model.Member member)
        {
            return _member.UserDetailV2(member);
        }

        /// <summary>
        /// 회원 코드 중복체크
        /// </summary>
        public string UserCheckPno(string pno)
        {
            return _member.UserCheckPno(pno);
        }

        /// <summary>
        /// 회원 코드 중복체크
        /// </summary>
        public string UserCheck(string code, string name)
        {
            return _member.UserCheck(code, name);
        }
        public string UserCheck_202206(string code, string name)
        {
            return _member.UserCheck_202206(code, name);
        }

        /// <summary>
        /// 회원 코드 중복체크
        /// </summary>
        public string UserCheckV3(string code, string name)
        {
            return _member.UserCheckV3(code, name);
        }

        /// <summary>
        /// 회원 로그인
        /// </summary>
        public Model.Member UserLogin(string code, string pwd)
        {
            return _member.UserLogin(code, pwd);
        }
        public Model.Member UserLogin_202206(string code, string pwd)
        {
            return _member.UserLogin_202206(code, pwd);
        }

        /// <summary>
        /// 회원 등록
        /// </summary>
        public bool UserRegist(Model.Member member)
        {
            return _member.UserRegist(member);
        }
        public bool UserRegist_202206(Model.Member member)
        {
            return _member.UserRegist_202206(member);
        }
        public bool UserRegist202302(Model.Member member)
        {
            return _member.UserRegist202302(member);
        }

        /// <summary>
        /// 회원 수정
        /// </summary>
        public bool UserModify(Model.Member member)
        {
            return _member.UserModify(member);
        }
        public bool UserModify_202206(Model.Member member)
        {
            return _member.UserModify_202206(member);
        }

        /// <summary>
        /// 회원 여행지 수정
        /// </summary>
        public bool UserTravel(string id, string travel)
        {
            return _member.UserTravel(id, travel);
        }
        #endregion

        /// <summary>
        /// 회원관리 소멸자
        /// </summary>
        public void Dispose()
        {
            _member = null;
        }
    }
}