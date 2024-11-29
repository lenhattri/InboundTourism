using Base.Utils.Fetch;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Base.Config;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
          
            if (TempData["BookingID"] != null)
            {
                 
                    ViewBag.ShowBookingConfirmation = true;
                
            }

         
            var response = await FetchService.Instance.GetAsync<List<Tour>>($"{GlobalConfig.BASE_URL}/tour");

            if (response.Success)
            {
                var tours = response.Data;

                
                var tourWithLocationsList = new List<TourWithLocations>();

                foreach (var tour in tours)
                {
                    
                    var tourLocationsResponse = await FetchService.Instance.GetAsync<List<TourLocation>>($"{GlobalConfig.BASE_URL}/tourlocation/tour/{tour.TourID}");
                    List<Location> locations = new List<Location>();

                    if (tourLocationsResponse.Success)
                    {
                        var tourLocations = tourLocationsResponse.Data;

                       
                        foreach (var tourLocation in tourLocations)
                        {
                            var locationResponse = await FetchService.Instance.GetAsync<Location>($"{GlobalConfig.BASE_URL}/location/{tourLocation.LocationID}");
                            if (locationResponse.Success)
                            {
                                locations.Add(locationResponse.Data);
                            }
                        }
                    }

                  
                    var tourWithLocations = new TourWithLocations
                    {
                        Tour = tour,
                        Locations = locations
                    };

                    tourWithLocationsList.Add(tourWithLocations);
                }

                
                return View(tourWithLocationsList);
            }

            ViewBag.ErrorMessage = "Không thể tải danh sách các tour.";
            return View(new List<TourWithLocations>());
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
