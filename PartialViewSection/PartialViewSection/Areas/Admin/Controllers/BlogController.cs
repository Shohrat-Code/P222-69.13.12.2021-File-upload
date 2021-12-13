using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialViewSection.Data;
using PartialViewSection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewSection.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Blogs.OrderByDescending(o => o.CreatedDate).Include(u => u.User)
                        .Include(c => c.BlogCategory)
                        .Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Category = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {
            //return Content(model.MainImageFile.FileName + "-" + model.MainImageFile.ContentType + "-" + model.MainImageFile.Length);

            if (ModelState.IsValid)
            {
                if (model.MainImageFile.ContentType == "image/jpeg" || model.MainImageFile.ContentType == "image/png")
                {
                    if (model.MainImageFile.Length <= 2097152)
                    {

                        //Create Blog
                        string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.MainImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.MainImageFile.CopyTo(stream);
                        }

                        model.MainImage = fileName;
                        model.CreatedDate = DateTime.Now;
                        model.UserId = 1;

                        _context.Blogs.Add(model);
                        _context.SaveChanges();


                        //Create Tag to blog
                        if (model.TagToBlogsId!=null && model.TagToBlogsId.Count>0)
                        {
                            foreach (var item in model.TagToBlogsId)
                            {
                                TagToBlog tagToBlog = new TagToBlog();
                                tagToBlog.TagId = item;
                                tagToBlog.BlogId = model.Id;
                                _context.TagToBlogs.Add(tagToBlog);
                                _context.SaveChanges();
                            }
                        }

                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only less than 2 mb.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                    return View(model);
                }
            }

            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                ///
            }

            Blog blog = _context.Blogs.Find(id);

            if (blog==null)
            {
                ///
            }

            //List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(t=>t.BlogId==id).ToList();
            //foreach (var item in tagToBlogs)
            //{
            //    _context.TagToBlogs.Remove(item);
            //}
            //_context.SaveChanges();

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
