using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.ViewModels
{
    public class VmCart : VmLayout
    {
        public List<Product> Products { get; set; }
    }
}
