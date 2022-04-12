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
    public class TypeInfoService:BaseService<TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoRepository _iTypeInfoRepository;
        public TypeInfoService(ITypeInfoRepository iTypeInfoRepository)
        {
            base._iBaseRepository = iTypeInfoRepository;
            _iTypeInfoRepository = iTypeInfoRepository;
        }
    }
}
