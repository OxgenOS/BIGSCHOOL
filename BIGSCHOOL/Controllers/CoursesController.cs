using BIGSCHOOL.Models;
using BIGSCHOOL.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIGSCHOOL.Controllers
{
    public class CoursesController : Controller
    {  
        private readonly ApplicationDbContext dbContext;
        public CoursesController()
        {
            dbContext = new ApplicationDbContext();
        }     
        //[Authorize]
        // GET: Courses
        public ActionResult Create()
        {
                      var viewModel = new CourseViewModel
            {
                Categories = dbContext.Categories.ToList()
            };
            return View(viewModel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Plance = viewModel.Place
            };
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
