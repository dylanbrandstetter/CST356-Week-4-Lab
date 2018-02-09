using CST356_Week_4_Lab.Data;
using CST356_Week_4_Lab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST356_Week_4_Lab.Models.View;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                CreateUser(MapToUser(userViewModel));

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);

            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var user = GetUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult List()
        {
            return View(GetAllUsers());
        }

        // ----- Private functions ----- //

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                YearsInSchool = userViewModel.YearsInSchool,
                Age = userViewModel.Age,
                Occupation = userViewModel.Occupation
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                YearsInSchool = user.YearsInSchool,
                Age = user.Age,
                Occupation = user.Occupation
            };
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.Id = userViewModel.Id;
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.YearsInSchool = userViewModel.YearsInSchool;
            user.Age = userViewModel.Age;
            user.Occupation = userViewModel.Occupation;
        }

        private UserViewModel GetUser(int id)
        {
            var db = new MyDbContext();

            return MapToUserViewModel(db.Users.Find(id));
        }

        private List<UserViewModel> GetAllUsers()
        {
            var db = new MyDbContext();

            var users = new List<UserViewModel>();

            foreach (var u in db.Users)
            {
                users.Add(MapToUserViewModel(u));
            }

            return users;
        }

        private void CreateUser(User user)
        {
            var db = new MyDbContext();

            db.Users.Add(user);
            db.SaveChanges();
        }

        private void DeleteUser(int id)
        {
            var db = new MyDbContext();

            User user = db.Users.Find(id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        private void UpdateUser(UserViewModel userViewModel)
        {
            var db = new MyDbContext();

            var user = db.Users.Find(userViewModel.Id);

            CopyToUser(userViewModel, user);

            db.SaveChanges();
        }
    }
}