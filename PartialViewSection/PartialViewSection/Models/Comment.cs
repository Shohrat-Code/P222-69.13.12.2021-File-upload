using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Website { get; set; }
        [Column(TypeName ="ntext")]
        public string Text { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
