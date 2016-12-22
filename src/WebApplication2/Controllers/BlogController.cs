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

        [Route("{name}")]
        public IEnumerable<Blog> Add(string name)
        {
            try
            {
                using (_blogContext)
                {
                    var g = _blogContext.Database.EnsureCreated();
                    

                    _blogContext.Goros.Add(new Blog
                    {
                        Title = name
                    });

                    _blogContext.SaveChanges();

                    return _blogContext.Goros.ToList();
                }
                  
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
