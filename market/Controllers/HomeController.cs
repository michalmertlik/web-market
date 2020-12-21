using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using market.Data;
using market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace market.Controllers
{
	public class HomeController : Controller
	{
		ApplicationDbContext _database;
		ImageService _imageService;
		public HomeController(ApplicationDbContext db, ImageService imageService)
		{
			_database = db;
			_imageService = imageService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(_database.Children.ToList());
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Child model, IFormFile avatar)
		{
			if (model == null)
				return Redirect("/");

			Child child = new Child()
			{
				DisplayName = model.DisplayName,
				BirthDate = model.BirthDate,
				Price = model.Price,
				Nationality = model.Nationality,
				Weight = model.Weight,
				Race = model.Race,
				Gender = model.Gender,
				Virginity = model.Virginity,
				EyeColor = model.EyeColor,
				HairColor = model.HairColor,
				SkinTone = model.SkinTone
			};

			_database.Children.Add(child);
			_database.SaveChanges();

			if (avatar != null)
				_imageService.SaveImage($"{child.Id}.png", avatar.OpenReadStream());

			return Redirect("/");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (_database.Children.FirstOrDefault(s => s.Id == id) is Child child)
			{
				_database.Children.Remove(child);
				_database.SaveChanges();
			}
			return Redirect("/");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Child model = new Child();

			if (_database.Children.FirstOrDefault(s => s.Id == id) is Child child)
				model = child;

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Child model, IFormFile avatar)
		{
			if (_database.Children.Any(s => s.Id == model.Id))
			{
				_database.Children.Update(model);
				_database.SaveChanges();
			}

			if (avatar != null)
				_imageService.SaveImage($"{model.Id}.png", avatar.OpenReadStream());
			return Redirect("/");
		}
	}
}
