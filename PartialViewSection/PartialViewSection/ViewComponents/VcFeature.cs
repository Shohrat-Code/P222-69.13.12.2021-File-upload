using Microsoft.AspNetCore.Mvc;
using PartialViewSection.Data;
using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.ViewComponents
{
    public class VcFeature: ViewComponent
    {
        private readonly AppDbContext _context;

        public VcFeature(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<Feature> model = _context.Features.ToList();
            return View(model);
        }
    }
}
