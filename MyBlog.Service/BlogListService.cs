using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model;
using MyBlog.IService;
using MyBlog.IRepository;

namespace MyBlog.Service
{
    public class BlogListService:BaseService<BlogList>,IBlogListService
    {
        private readonly IBlogListRepository _iBlogListRepository;
        public BlogListService(IBlogListRepository iBlogListRepository)
        {
            base._iBaseRepository = iBlogListRepository;
            _iBlogListRepository = iBlogListRepository;
        }
    }
}
