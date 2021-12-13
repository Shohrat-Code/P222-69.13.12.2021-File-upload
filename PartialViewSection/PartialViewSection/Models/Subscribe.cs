using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
