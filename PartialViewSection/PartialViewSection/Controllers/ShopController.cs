using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartialViewSection.Data;
using PartialViewSection.Utilities;
using PartialViewSection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public ShopController(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public IActionResult Index()
        {
            Shopping shopping = new Shopping(_httpContext);

            VmShop model = new VmShop()
            {
                Socials = _context.Socials.ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Banner = _context.Banners.FirstOrDefault(b => b.Page == "shop"),
                Products = _context.Products.ToList(),
                BasketCount = shopping.GetBasketCount(),
                BasketProductIds = shopping.BasketProductId()
            };

            return View(model);
        }

        public IActionResult AddToCard(int id)
        {
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1)
            };

            string card = Request.Cookies["card"];
            string newCard = "";
            if (string.IsNullOrEmpty(card))
            {
                newCard = id.ToString();
            }
            else
            {
                List<string> cardIds = card.Split("-").ToList();
                bool isExist = cardIds.Any(c => c == id.ToString());
                if (!isExist)
                {
                    newCard = card + "-" + id;
                }
                else
                {
                    cardIds.Remove(id.ToString());
                    newCard = string.Join('-', cardIds);
                }
            }

            Response.Cookies.Append("card", newCard, options);

            return RedirectToAction("Index");
        }

        public IActionResult Cart(int id)
        {
            string card = Request.Cookies["card"];
            VmCart model = new VmCart()
            {
                Socials = _context.Socials.ToList(),
                Setting=_context.Settings.FirstOrDefault()
            };

            Shopping shopping = new Shopping(_httpContext);

            model.Products = _context.Products.Where(p => shopping.BasketProductId().Any(i => i == p.Id)).ToList();
            model.BasketCount = shopping.GetBasketCount();

            return View(model);
        }
    }
}
