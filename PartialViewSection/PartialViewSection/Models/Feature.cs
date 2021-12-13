using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Icon { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string SubTitle { get; set; }
    }
}
