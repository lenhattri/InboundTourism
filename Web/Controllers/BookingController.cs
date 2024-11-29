using Microsoft.AspNetCore.Mvc;
using Base.Utils.Fetch;
using Core.Entities;
using Base.Config;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        // Hiển thị form đặt chỗ với thông tin chuyến đi
        [HttpGet]
        public async Task<IActionResult> Booking(Guid tripId)
        {
            try
            {
                // Lấy chi tiết chuyến đi
                var tripResponse = await FetchService.Instance.GetAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{tripId}");
                if (!tripResponse.Success)
                {
                    return NotFound("Không tìm thấy chuyến đi.");
                }
                var trip = tripResponse.Data;

                // Lấy chi tiết tour
                var tourResponse = await FetchService.Instance.GetAsync<Tour>($"{GlobalConfig.BASE_URL}/tour/{trip.TourID}");
                if (!tourResponse.Success)
                {
                    return NotFound("Không tìm thấy Tour liên quan.");
                }
                var tour = tourResponse.Data;

                // Lấy danh sách địa điểm của tour
                var locations = await GetLocationsForTour(tour.TourID);

                // Lấy tổng số vé đã được đặt
                var bookingsResponse = await FetchService.Instance.GetAsync<List<Booking>>($"{GlobalConfig.BASE_URL}/booking/trip/{tripId}");
                int totalBookedGuests = 0;
                if (bookingsResponse.Success)
                {
                    totalBookedGuests = bookingsResponse.Data.Sum(b => b.NumberOfGuests);
                }

                // Truyền dữ liệu vào ViewBag
                ViewBag.Trip = trip;
                ViewBag.Tour = tour;
                ViewBag.Locations = locations;
                ViewBag.TotalBookedGuests = totalBookedGuests; // Số vé đã đặt

                // Trả về form đặt chỗ
                return View(new Booking { TripID = tripId });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi không mong muốn
                ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.";
                return View(new Booking());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Booking(Guid tripId, Booking booking)
        {
            try
            {
                // Kiểm tra trạng thái Model
                if (!ModelState.IsValid)
                {
                    await AddViewBagDataForTripAndTour(tripId);
                    ViewBag.ErrorMessage = "Dữ liệu không hợp lệ. Vui lòng kiểm tra và thử lại.";
                    return View(booking);
                }

                // Lấy thông tin chi tiết chuyến đi
                var tripResponse = await FetchService.Instance.GetAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{tripId}");
                if (!tripResponse.Success)
                {
                    ModelState.AddModelError("", "Không tìm thấy chuyến đi. Vui lòng thử lại.");
                    await AddViewBagDataForTripAndTour(tripId);
                    return View(booking);
                }
                var trip = tripResponse.Data;

                // Lấy UserID từ Claims
                var userIdClaim = User.FindFirst("UserID");
                if (userIdClaim == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.");
                    return RedirectToAction("Login", "Auth");
                }

                // Tính toán tổng giá
                booking.UserID = Guid.Parse(userIdClaim.Value);
                booking.TripID = tripId;
                booking.BookingDate = DateTime.Now;
                booking.TotalPrice = booking.NumberOfGuests * trip.Price;

                // Gọi API để thêm booking
                var response = await FetchService.Instance.PostAsync<Booking>($"{GlobalConfig.BASE_URL}/booking", booking);
                if (response.Success)
                {
                    // Lưu thông tin booking vào TempData và chuyển hướng về Home
                    TempData["BookingID"] = booking.BookingID.ToString();
                    return RedirectToAction("Index", "Home");
                }

                // Nếu API trả lỗi
                ViewBag.ErrorMessage = response.ErrorMessage ?? "Đặt chỗ thất bại. Vui lòng thử lại.";
                await AddViewBagDataForTripAndTour(tripId);
                return View(booking);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi không mong muốn
                ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.";
                await AddViewBagDataForTripAndTour(tripId);
                return View(booking);
            }
        }

        // Lấy danh sách địa điểm của tour
        private async Task<List<Location>> GetLocationsForTour(Guid tourId)
        {
            var locations = new List<Location>();

            var tourLocationsResponse = await FetchService.Instance.GetAsync<List<TourLocation>>($"{GlobalConfig.BASE_URL}/tourlocation/tour/{tourId}");
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

            return locations;
        }

        // Truyền lại dữ liệu Trip và Tour vào ViewBag
        private async Task AddViewBagDataForTripAndTour(Guid tripId)
        {
            var tripResponse = await FetchService.Instance.GetAsync<Trip>($"{GlobalConfig.BASE_URL}/trip/{tripId}");
            if (tripResponse.Success)
            {
                ViewBag.Trip = tripResponse.Data;

                var tourResponse = await FetchService.Instance.GetAsync<Tour>($"{GlobalConfig.BASE_URL}/tour/{tripResponse.Data.TourID}");
                if (tourResponse.Success)
                {
                    ViewBag.Tour = tourResponse.Data;
                    ViewBag.Locations = await GetLocationsForTour(tourResponse.Data.TourID);
                }
            }
        }
    }
}
