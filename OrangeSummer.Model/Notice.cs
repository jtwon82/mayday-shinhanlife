﻿namespace OrangeSummer.Model
{
    /// <summary>
    /// 전윤기 - 2020.06.19
    /// 공지사항 Model
    /// </summary>
    public class Notice
    {
        public int Total { get; set; }
        public string Id { get; set; }
        public int Sort { get; set; }
        public string FkAdmin { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Url { get; set; }
        public string AttImage { get; set; }
        public string AttFile { get; set; }
        public string AttFileName { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
        public string UseYn { get; set; }
        public string DelYn { get; set; }
        public string RegistDate { get; set; }
        public Admin Admin { get; set; }
    }
}
