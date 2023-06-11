using FetchingApI.Models;
using FetchingApI.Repository.Irepository;
using Microsoft.AspNetCore.Mvc;

namespace FetchingApI.Controllers
{
    public class NationalparkController: Controller
    {
        private readonly InationalPark _inationalPark;
        public NationalparkController(InationalPark inationalPark)
        {
            _inationalPark = inationalPark;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            if(id == null) { return View(nationalPark); }
            //Edit
            nationalPark = await _inationalPark.GetAsync(SD.NationalparkApi, id.GetValueOrDefault());
            return View(nationalPark);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Upsert(NationalPark nationalPark)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    nationalPark.Picture = p1;
                }
                else
                {
                    var nationalParkInDb = await _inationalPark.GetAsync(SD.NationalparkApi, nationalPark.Id);
                    nationalPark.Picture = nationalParkInDb.Picture;
                }
                if (nationalPark.Id == 0)
                    await _inationalPark.CreateAsync(SD.NationalparkApi, nationalPark);
                else
                    await _inationalPark.UpdateAsync(SD.NationalparkApi, nationalPark);
                return RedirectToAction(nameof(Index));


            }
            return View(nationalPark);
        }
        #region APIs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _inationalPark.GetAllAsync(SD.NationalparkApi) });
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            var status = await _inationalPark.deleteAsync(SD.NationalparkApi,id);
            if (status)
                return Json(new { success = true, message = "Data sucessfully deleted !!!" });
            else
                return Json(new { success = false, message = "Data not Deleted" });
        }
        #endregion
    }
}
