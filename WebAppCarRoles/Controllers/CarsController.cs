using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCarRoles.Models;

namespace WebAppCarRoles.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars

        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "ReadCar, CreateCar")]
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "CreateCar")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "CreateCar")]
        public ActionResult Create(Car car)
        {
            if(ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }



    }
}