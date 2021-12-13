using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [Column(TypeName ="ntext")]
        public string Content { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250)]
        public string Video { get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
    }
}
