using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.EntitiesService;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class WriterController : Controller
    {
        #region متد مربوط به پیکربندی نویسنده گان
        private IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;

        }
        public IActionResult ShowAllWriter()
        {
            return View(_writerService.ShowAllWriter());
        }
        #endregion

        #region متد ثبت اطلاعات نویسنده یا مؤلف

        [HttpGet]
        public IActionResult AddWriter(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(TBL_ProductWriter writer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllWriter));
            }
            if (_writerService.ExistWriter(writer.WriterFaTitle, 0))
            {
                ModelState.AddModelError("WriterFaTitle", "خطا... دسته بندی وارد شده تکراری است .");
                return View(writer);
            }
            int cateid = _writerService.AddWriter(writer);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(AddWriter));
        }
		#endregion

		#region متد مربوط به ویرایش نویسنده یا مؤلف

		[HttpGet]
		public IActionResult UpdateWriter(int id)
		{
			return PartialView("_ModalUpdateWriter", _writerService.FindWriterById(id));
		}

		[HttpPost]
		public IActionResult UpdateWriter(TBL_ProductWriter writer)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(ShowAllWriter));
			}
			if (_writerService.ExistWriter(writer.WriterFaTitle, writer.Writerid))
			{
				return RedirectToAction(nameof(ShowAllWriter));
			}
			// در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
			// مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
			// نامی دلخواه است getUpdateCategoryid متد 
			bool getUpdateCategoryid = _writerService.UpdateWriter(writer);
			int sendjson = getUpdateCategoryid ? 2 : 4;
			return Json(sendjson);
		}
		#endregion

		#region متد مربوط به حذف نویسنده یا مؤلف

		[HttpGet]
		public IActionResult DeleteWriter(int id)
		{

			return PartialView("_ModalDidableWriter", _writerService.FindWriterById(id));
		}

		[HttpPost]
		public IActionResult DeleteWriter(TBL_ProductWriter productWriter)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(ShowAllWriter));
			}

			// در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
			// مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
			bool getDeleteWriterid = _writerService.DeleteWriter(productWriter);
			int sendjson = getDeleteWriterid ? 3 : 4;
			return Json(sendjson);
		}
		#endregion
	}
}
