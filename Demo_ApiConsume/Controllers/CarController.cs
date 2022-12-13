using Demo_ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo_ApiConsume.Controllers
{
    public class CarController : Controller
    {
        public async Task<IActionResult> Index()
        {
			List<CarListViewModel> carList = new List<CarListViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://car-data.p.rapidapi.com/cars?limit=50&page=0"),
				Headers =
	{
		{ "X-RapidAPI-Key", "cf34604c81mshc9842433b4a1ee3p1f332bjsn50fd177b3ab1" },
		{ "X-RapidAPI-Host", "car-data.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				carList = JsonConvert.DeserializeObject<List<CarListViewModel>>(body);
				return View(carList);
			}
        }
    }
}
