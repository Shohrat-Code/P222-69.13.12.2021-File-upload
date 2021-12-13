using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartialViewSection.Data;
using PartialViewSection.Models;
using PartialViewSection.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmHome model = new VmHome
            {
                Slider = _context.Products.OrderByDescending(p => p.CreatedDate).Take(3).ToList(),
                Features = _context.Features.ToList(),
                Partners = _context.Partners.ToList(),
                Products = _context.Products.OrderByDescending(p => p.CreatedDate).ToList(),
                Feedbacks = _context.Feedbacks.ToList(),
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault()
            };

            //HttpContext.Session.SetString("IsAlive", "s;kfjng;frvjskdfnb");
            //CookieOptions options = new CookieOptions()
            //{
            //    Expires = DateTime.Now.AddYears(1)
            //};

            //Response.Cookies.Append("card", "1-2", options);

            return View(model);
        }
    }
}
