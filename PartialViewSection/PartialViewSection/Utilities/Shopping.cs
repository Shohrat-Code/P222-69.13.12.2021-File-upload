using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Utilities
{
    public class Shopping
    {
        private readonly IHttpContextAccessor _httpContext;

        public Shopping(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public int GetBasketCount()
        {
            string card = _httpContext.HttpContext.Request.Cookies["card"];
            int basketCount = 0;
            if (!string.IsNullOrEmpty(card))
            {
                basketCount = card.Split("-").Length;
            }

            return basketCount;
        }

        public List<int> BasketProductId()
        {
            List<int> ids = new List<int>();
            string card = _httpContext.HttpContext.Request.Cookies["card"];
            if (!string.IsNullOrEmpty(card))
            {
                string[] idsArr = card.Split("-");
                foreach (var item in idsArr)
                {
                    ids.Add(Convert.ToInt32(item));
                }
            }

            return ids;
        }
    }
}
