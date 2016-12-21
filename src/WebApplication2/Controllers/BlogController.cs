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
        public string Add(string name)
        {
            try
            {
                using (_blogContext)
                {
                    var g = _blogContext.Database.EnsureCreated();
                    var id = _blogContext.Goros.LastOrDefault()?.Id;

                    if (id != null)
                    {
                        id++;
                    }

                    _blogContext.Goros.Add(new Blog
                    {
                        Id= id??0,
                        Title = name
                    });

                    _blogContext.SaveChanges();

                    return string.Empty;
                }
                  
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        [Route("")]
        public IEnumerable<Blog> Index()
        {
                var g = _blogContext.Database.EnsureCreated();

                var result = _blogContext.Goros.ToList();

                return result;
        }
    }
}
