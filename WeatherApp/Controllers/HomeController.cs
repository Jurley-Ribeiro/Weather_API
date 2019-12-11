using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			
		}

		public IActionResult Index()
		{
			var client = new OpenWeatherAPI.OpenWeatherAPI("7b678f7b3998ff5249745148d5c8a38a");

			var results = client.Query("London");

			return View(results);
		}
		[HttpPost]
		public IActionResult Index(string city)
		{
			var client = new OpenWeatherAPI.OpenWeatherAPI("7b678f7b3998ff5249745148d5c8a38a");
			try
			{
				if (city == null)
					city = "London";
				var results = client.Query(city);
				return View(results);
			}
			catch (Exception ex)
			{
				return View(ex.Message);
			}
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
