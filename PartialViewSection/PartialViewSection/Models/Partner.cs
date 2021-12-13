using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
