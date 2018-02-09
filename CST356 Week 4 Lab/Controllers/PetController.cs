using CST356_Week_4_Lab.Data;
using CST356_Week_4_Lab.Data.Entities;
using CST356_Week_4_Lab.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST356_Week_4_Lab.Controllers
{
    public class PetController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;
            return View(GetAllPetsForUser(userId));
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                CreatePet(MapToPet(petViewModel));

                return RedirectToAction("List", new { UserId = petViewModel.UserId });
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            int userId = DeletePet(id);

            if (userId != 0)
                return RedirectToAction("List", new { userId = userId });
            else
                return RedirectToAction("List", "User", null);
        }

        public ActionResult Details(int id)
        {
            var pet = GetPet(id);

            return View(pet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = GetPet(id);
            ViewBag.UserId = pet.UserId;

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdatePet(petViewModel);

                return RedirectToAction("List", new { UserId = petViewModel.UserId });
            }

            return View();
        }

        // ----- Private functions ----- //

        private Pet MapToPet(PetViewModel petViewModel)
        {
            return new Pet
            {
                Id = petViewModel.Id,
                Name = petViewModel.Name,
                Age = petViewModel.Age,
                NextCheckup = petViewModel.NextCheckup,
                VetName = petViewModel.VetName,
                UserId = petViewModel.UserId
            };
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
            return new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                NextCheckup = pet.NextCheckup,
                VetName = pet.VetName,
                UserId = pet.UserId
            };
        }

        private void CopyToPet(PetViewModel petViewModel, Pet pet)
        {
            pet.Id = petViewModel.Id;
            pet.Name = petViewModel.Name;
            pet.Age = petViewModel.Age;
            pet.NextCheckup = petViewModel.NextCheckup;
            pet.VetName = petViewModel.VetName;
            pet.UserId = petViewModel.UserId;
        }

        private PetViewModel GetPet(int id)
        {
            var db = new MyDbContext();

            return MapToPetViewModel(db.Pets.Find(id));
        }

        private List<PetViewModel> GetAllPetsForUser(int userId)
        {
            var db = new MyDbContext();

            var userPets = new List<PetViewModel>();

            foreach (var p in db.Pets)
            {
                if (p.UserId == userId)
                    userPets.Add(MapToPetViewModel(p));
            }

            return userPets;
        }

        private void CreatePet(Pet pet)
        {
            var db = new MyDbContext();

            db.Pets.Add(pet);
            db.SaveChanges();
        }

        private int DeletePet(int id)
        {
            var db = new MyDbContext();

            var pet = db.Pets.Find(id);

            if (pet != null)
            {
                int userId = pet.UserId;
                db.Pets.Remove(pet);
                db.SaveChanges();
                return userId;
            }
            else
                return 0;
        }

        private void UpdatePet(PetViewModel petViewModel)
        {
            var db = new MyDbContext();

            var pet = db.Pets.Find(petViewModel.Id);

            CopyToPet(petViewModel, pet);

            db.SaveChanges();
        }
    }
}