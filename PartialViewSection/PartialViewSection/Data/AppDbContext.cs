using Microsoft.EntityFrameworkCore;
using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<Feedback> Feedbacks{ get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Partner> Partners{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }
        public DbSet<Rating> Ratings{ get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToBlog> TagToBlogs { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
