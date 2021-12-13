using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialViewSection.Data;
using PartialViewSection.Utilities;
using PartialViewSection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public BlogController(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public IActionResult Index()
        {
            Shopping shopping = new Shopping(_httpContext);
            VmBlog model = new VmBlog() {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                BasketCount = shopping.GetBasketCount(),
                Banner = _context.Banners.FirstOrDefault(b => b.Page == "blog"),
                Blogs = _context.Blogs.Include("Comments").Include("User").ToList(),
                BlogCategories=_context.BlogCategories.ToList(),
                Tags=_context.Tags.ToList()
            }; 
            
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            Shopping shopping = new Shopping(_httpContext);
            VmBlog model = new VmBlog()
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                BasketCount = shopping.GetBasketCount(),
                Banner = _context.Banners.FirstOrDefault(b => b.Page == "blog"),
                Blogs = _context.Blogs.Include("Comments").Include("User").ToList(),
                BlogCategories = _context.BlogCategories.ToList(),
                Tags = _context.Tags.ToList()
            };

            return View(model);

        }
    }
}
