using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("api/[controller]")]
    public class BlogController : Controller
    {

        public BlogContext _blogContext { get; set; }

        public BlogController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        [HttpGet]
        public IEnumerable<Goro> Index()
        {
            
                var g = _blogContext.Database.EnsureCreated();

                var blog = new Goro
                {
                    Title = "http://blogprogramistu.net"
                };

                var r = _blogContext.Goros.Add(blog);

                
                _blogContext.SaveChanges();

                var result = _blogContext.Goros.ToList();

                return result;
        

         
        }
    }
}
