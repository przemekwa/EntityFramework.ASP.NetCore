using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    [Route("api/[controller]")]
    public class BlogController : Controller
    {

        public BlogContext _blogContext { get; set; }

        public BlogController(IConfiguration config)
        {
            _blogContext = new BlogContext(config["Data:Blog:ConnectionString"]);
        }

        [Route("{name}")]
        public IEnumerable<Blog> Add(string name)
        {
            try
            {
                using (_blogContext)
                {
                    var g = _blogContext.Database.EnsureCreated();


                    _blogContext.Blogs.Add(new Blog
                    {
                        Title = name
                    });

                    _blogContext.SaveChanges();

                    return _blogContext.Blogs.ToList();
                }
                  
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

    }
}
