using Microsoft.AspNetCore.Mvc;
using Base.Utils.Fetch;
using Core.Entities;
using Base.Config;

namespace Web.Controllers
{
    public class TourController : Controller
    {
        public async Task<IActionResult> Details(Guid id)
        {
            
            var tourResponse = await FetchService.Instance.GetAsync<Tour>($"{GlobalConfig.BASE_URL}/tour/{id}");

            if (!tourResponse.Success)
            {
                return NotFound("Không tìm thấy Tour.");
            }


            var tripsResponse = await FetchService.Instance.GetAsync<List<Trip>>($"{GlobalConfig.BASE_URL}/trip/tour/{id}");

            if (!tripsResponse.Success)
            {
                tripsResponse.Data = new List<Trip>();
            }


            ViewBag.Tour = tourResponse.Data;
            return View(tripsResponse.Data);
        }
    }
}
