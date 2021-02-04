using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobomanticsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace GlobomanticsWeb.Controllers
{
    public class LocationsController : Controller
    {
        private readonly static string COUNTRIES_KEY = "Globocations";

        private IMemoryCache countryCache;

        public LocationsController(IMemoryCache cache)
        {
            countryCache = cache;
        }
        public async Task<IActionResult> Index()
        {
            //get countries for search list
            var countries = await GetCountriesListAsync();
            ViewData["CountriesList"] = countries;

            //get the list of all locations from CosmosDb


            //pass locations and countries
            return View(null);
        }

        private async Task<List<string>> GetCountriesListAsync()
        {
            var countries = await countryCache.GetOrCreateAsync<List<string>>(
                COUNTRIES_KEY, (entry) => {
                    //TODO: Get countries from CosmosDB
                    
                    return Task.FromResult(new List<string>(new string[]{ "United States" }));
                });

            return countries;
           
        }

        [HttpPost]
        public IActionResult Add(LocationModel model)
        {
            if (ModelState.IsValid)
            {
                //Add a new item to CosmosDB


                return RedirectToAction("index");
            }
            else
            {
                return View();
            }

            
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string country)
        {
            //get all locations for a country

            var locations = new List<LocationModel>();
            return View(locations);
        }

    }
}