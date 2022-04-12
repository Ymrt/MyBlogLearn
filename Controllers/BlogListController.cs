using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
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
        public async Task<ActionResult> GetBlogList()
        {
           var data = await _iBlogListService.QueryAsync();
            return Ok(data);
        }
    }
}
