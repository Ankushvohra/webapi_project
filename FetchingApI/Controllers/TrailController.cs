using FetchingApI.Models;
using FetchingApI.Repository.Irepository;
using Microsoft.AspNetCore.Mvc;

namespace FetchingApI.Controllers
{
    public class TrailController : Controller
    {
        private readonly Itrail _itrail;
        public TrailController(Itrail trail)
        {
            _itrail = trail;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _itrail.GetAllAsync(SD.TrailApi) });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _itrail.deleteAsync(SD.TrailApi, id);
            if (status)
                return Json(new { success = true, message = "Data successfully deleted" });
            else
                return Json(new { success = false, message = "Something went wrong while deleting" });

        }
        #endregion
    }
}
