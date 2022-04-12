using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlog.Model
{
    public class BlogList : BaseId
    {
        //nvarchar对中文支持比较好
        [SugarColumn(ColumnDataType = "nvarchar(30)")]
        public string Title { get; set; }

        [SugarColumn(ColumnDataType ="text")]
        public string Content { get; set; }

        public DateTime Time { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }

        public int TypeId { get; set; }
        public int AuthorId { get; set; }

        /// <summary>
        /// 类型，不映射到数据库
        /// </summary>
        [SugarColumn(IsIgnore =true)]
        public TypeInfo TypeInfo { get; set; }

        [SugarColumn(IsIgnore =true)]
        public AuthorInfo AuthorInfo { get; set; }
    }
}
