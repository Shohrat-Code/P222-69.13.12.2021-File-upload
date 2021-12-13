using Microsoft.AspNetCore.Mvc;
using PartialViewSection.Data;
using PartialViewSection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmLayout model = new VmLayout() {
                Socials=_context.Socials.ToList(),
                Setting=_context.Settings.FirstOrDefault()
            };
            return View(model);
        }
    }
}
