using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.ViewModels
{
    public class VmHome : VmLayout
    {
        public List<Product> Slider { get; set; }
        public List<Feature> Features { get; set; }
        public List<Product> Products { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Partner> Partners { get; set; }
    }
}
