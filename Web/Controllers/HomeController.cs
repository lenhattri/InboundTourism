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
            // Check if there's a booking confirmation to display
            if (TempData["BookingID"] != null)
            {
                var bookingId = Guid.Parse(TempData["BookingID"].ToString());

                // Fetch booking details
                var bookingResponse = await FetchService.Instance.GetAsync<Booking>($"{GlobalConfig.BASE_URL}/booking/{bookingId}");
                if (bookingResponse.Success)
                {
                    var booking = bookingResponse.Data;

                    // Fetch trip details
                    var tripResponse = await FetchService.Instance.GetAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{booking.TripID}");
                    var trip = tripResponse.Data;

                    // Fetch tour details
                    var tourResponse = await FetchService.Instance.GetAsync<Tour>($"{GlobalConfig.BASE_URL}/tour/{trip.TourID}");
                    var tour = tourResponse.Data;

                    ViewBag.Booking = booking;
                    ViewBag.Trip = trip;
                    ViewBag.Tour = tour;

                    // Set a flag to indicate that booking confirmation should be displayed
                    ViewBag.ShowBookingConfirmation = true;
                }
            }

            // Fetch the list of Tours
            var response = await FetchService.Instance.GetAsync<List<Tour>>($"{GlobalConfig.BASE_URL}/tour");

            if (response.Success)
            {
                var tours = response.Data;

                // For each tour, fetch its locations
                var tourWithLocationsList = new List<TourWithLocations>();

                foreach (var tour in tours)
                {
                    // Fetch TourLocations for the Tour
                    var tourLocationsResponse = await FetchService.Instance.GetAsync<List<TourLocation>>($"{GlobalConfig.BASE_URL}/tourlocation/tour/{tour.TourID}");
                    List<Location> locations = new List<Location>();

                    if (tourLocationsResponse.Success)
                    {
                        var tourLocations = tourLocationsResponse.Data;

                        // Fetch Location details for each TourLocation
                        foreach (var tourLocation in tourLocations)
                        {
                            var locationResponse = await FetchService.Instance.GetAsync<Location>($"{GlobalConfig.BASE_URL}/location/{tourLocation.LocationID}");
                            if (locationResponse.Success)
                            {
                                locations.Add(locationResponse.Data);
                            }
                        }
                    }

                    // Create a TourWithLocations object
                    var tourWithLocations = new TourWithLocations
                    {
                        Tour = tour,
                        Locations = locations
                    };

                    tourWithLocationsList.Add(tourWithLocations);
                }

                // Pass the tours with locations to the view
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
