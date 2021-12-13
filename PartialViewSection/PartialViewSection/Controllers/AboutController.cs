using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartialViewSection.Data;
using PartialViewSection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            VmAbout model = new VmAbout()
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Banner = _context.Banners.FirstOrDefault(b => b.Page == "shop")
            };

            //ViewBag.Session = HttpContext.Session.GetString("IsAlive");

            //ViewBag.Cookie = Request.Cookies["card"];

            return View(model);
        }
    }
}
