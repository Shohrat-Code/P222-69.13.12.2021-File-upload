using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
