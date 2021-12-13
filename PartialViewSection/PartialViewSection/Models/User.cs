using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
