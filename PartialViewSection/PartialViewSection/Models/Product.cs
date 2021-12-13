using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string About { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size{ get; set; }
        public List<Rating> Ratings{ get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
