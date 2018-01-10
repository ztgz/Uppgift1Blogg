using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Uppgift1Blogg.Models;
using Uppgift1Blogg.ViewModel;

namespace Uppgift1Blogg.Controllers
{
    public class BlogController : Controller
    {
        private BloggContext _context;

        public BlogController(BloggContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            BlogPostsInfo model = new BlogPostsInfo();

            if (!id.HasValue)
            {
                model.BlogPosts = _context.BlogPost.OrderBy(bp => bp.Date).ToList();
            }
            else
            {
                model.BlogPosts = _context.BlogPost.Where(bp => bp.CategoryId == id).OrderBy(bp => bp.Date).ToList();
            }

            model.Categories = _context.Category.ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            BlogPostsInfo model = new BlogPostsInfo();

            model.Categories = _context.Category.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostsInfo blogPostInfo)
        {
            //If the form is correctly vaild...
            if (ModelState.IsValid)
            {
                //...get blogpost...
                BlogPost blogPost = blogPostInfo.BlogPost;

                //...add current date to blogg post...
                blogPost.Date = DateTime.Now;

                //..and add bloggPost to database
                _context.BlogPost.Add(blogPost);

                //...save the changes
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Create", blogPostInfo);
        }

        public IActionResult ViewPost(int id)
        {
            //Get the requested blog post
            BlogPost blogPost = _context.BlogPost.FirstOrDefault(bp => bp.Id == id);

            //If the blogPost does not exist...
            if (blogPost is null)
            {
                //... return index
                return RedirectToAction("Index");
            }

            //Info for the view
            BlogPostsInfo blogPostsInfo = new BlogPostsInfo();

            //Get all categories
            blogPostsInfo.Categories = _context.Category.ToList();
            
            //Add blogpost
            blogPostsInfo.BlogPost = blogPost;

            return View(blogPostsInfo);
        }
        
        [HttpGet]
        public IActionResult Search(string searchTxt)
        {
            BlogPostsInfo model = new BlogPostsInfo();

            //if user typed anything...
            if (!String.IsNullOrEmpty(searchTxt))
            {
                //...filter search
                model.BlogPosts = _context.BlogPost.Where(bp => bp.Header.ToLower().Contains(searchTxt.ToLower()))
                    .OrderBy(bp => bp.Date).ToList();
            }
            else
            {
                //...otherwise get all blogpost
                model.BlogPosts = _context.BlogPost.OrderBy(bp => bp.Date).ToList();
            }

            //Get all categories
            model.Categories = _context.Category.ToList();

            //Load index with search result
            return View("Index", model);
        }
    }
}