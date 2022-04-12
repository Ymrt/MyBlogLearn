using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public class BlogListRepository:BaseRepository<BlogList>,IBlogListRepository
    {

    }
}
