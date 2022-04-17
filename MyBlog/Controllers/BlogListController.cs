using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Utility.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogListController : ControllerBase
    {
        private readonly IBlogListService _iBlogListService;
        public BlogListController(IBlogListService iBlogListService)
        {
            this._iBlogListService = iBlogListService;
        }

        [HttpGet("BlogList")]
        public async Task<ActionResult<ApiResult>> GetBlogList()
        {
           var data = await _iBlogListService.QueryAsync();
            if (data == null) return ApiResultHelper.Error("没有更多文章");
            return ApiResultHelper.Success(data);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title,string content,int typeid)
        {
            //数据验证，略

            BlogList blogList = new BlogList
            {
                ViewCount = 0,
                Content = content,
                LikeCount = 0,
                Time = DateTime.Now,
                Title = title,
                TypeId = typeid,
                AuthorId = 1,
            };
            bool b = await _iBlogListService.CreateAsync(blogList);
            if (!b) return ApiResultHelper.Error("添加失败，服务器发生错误");
            return ApiResultHelper.Success(blogList);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _iBlogListService.DeleteAsync(id);
            if(!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success("删除成功");
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(int id,string title,string content,int typeid)
        {
            var blogNews = await _iBlogListService.FindAsync(id);
            if(blogNews == null) return ApiResultHelper.Error("文章不存在");
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.TypeId = typeid;
            bool b = await _iBlogListService.EditAsync(blogNews);
            if (!b) return ApiResultHelper.Error("编辑失败");
            return ApiResultHelper.Success(blogNews);
        }
    }
}
