using System;
using System.Collections.Generic;

namespace OrangeSummer.Business
{
    /// <summary>
    /// 전윤기 - 2020.06.20
    /// Wrod이벤트 Business
    /// </summary>
    public class Word : IDisposable
    {
        private Access.Word _word = null;

        /// <summary>
        /// Wrod이벤트 생성자
        /// </summary>
        public Word(string connection)
        {
            _word = new Access.Word(connection);
        }

        #region [ 관리자 ]
        /// <summary>
        /// Wrod이벤트 리스트
        /// </summary>
        public List<Model.Word> List(int page, int size)
        {
            return _word.List(page, size);
        }
        public List<Model.Word> List2(int page, int size)
        {
            return _word.List2(page, size);
        }

        /// <summary>
        /// Wrod이벤트 리스트
        /// </summary>
        public List<Model.Word> Excel()
        {
            return _word.Excel();
        }
        public List<Model.Word> Excel2()
        {
            return _word.Excel2();
        }

        /// <summary>
        /// Wrod이벤트 랭킹
        /// </summary>
        public List<Model.Word> Ranking()
        {
            return _word.Ranking();
        }
        public List<Model.Word> Ranking2()
        {
            return _word.Ranking2();
        }
        #endregion

        #region [ 사용자 ]
        public string UserVote(string member, string vote)
        {
            return _word.UserVote(member, vote);
        }
        public string UserVote2(string member, string vote)
        {
            return _word.UserVote2(member, vote);
        }
        #endregion

        /// <summary>
        /// Wrod이벤트 소멸자
        /// </summary>
        public void Dispose()
        {
            _word = null;
        }
    }
}
