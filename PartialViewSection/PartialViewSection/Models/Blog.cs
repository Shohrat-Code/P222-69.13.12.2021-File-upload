using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        [MaxLength(250)]
        public string MainImage { get; set; }
        [NotMapped]
        public IFormFile MainImageFile { get; set; }
        [ForeignKey("BlogCategory")]
        public int CategoryId{ get; set; }
        public BlogCategory BlogCategory { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
        [NotMapped]
        public List<int> TagToBlogsId { get; set; }
    }
}
