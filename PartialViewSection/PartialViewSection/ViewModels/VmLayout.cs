using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.ViewModels
{
    public class VmLayout
    {
        public List<Social> Socials{ get; set; }
        public Setting Setting { get; set; }
        public int BasketCount { get; set; }
        public List<int> BasketProductIds { get; set; }
    }
}
