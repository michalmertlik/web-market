using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using market.Data;
using Microsoft.AspNetCore.Mvc;

namespace market.Controllers
{
	[ApiController]
	public class ApiController : ControllerBase
	{
		ApplicationDbContext _database;
		public ApiController(ApplicationDbContext db)
		{
			_database = db;
		}

		[HttpGet("children")]
		public ActionResult<List<Child>> Children()
		{
			return _database.Children.ToList();
		}
	}
}
