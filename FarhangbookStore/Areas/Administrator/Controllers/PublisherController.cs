using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.EntitiesService;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
	[Area("Administrator")]
	public class PublisherController : Controller
	{
		#region متد مربوط به پیکربندی ناشران

		private IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
			_publisherService = publisherService;
        }
        public IActionResult ShowAllPublisher()
		{
			return View(_publisherService.ShowAllPublisher());
		}

        #endregion

        #region متد ثبت اطلاعات ناشران

        [HttpGet]
        public IActionResult AddPublisher(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPublisher(TBL_ProductPublisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllPublisher));
            }
            if (_publisherService.ExistPublisher(publisher.PublisherFaTitle, publisher.PublisherEnTitle, 0))
            {
                ModelState.AddModelError("PublisherFaTitle", "خطا... اطلاعات ناشر وارد شده تکراری است .");
                return View(publisher);
            }
            int cateid = _publisherService.AddPublisher(publisher);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(AddPublisher));
        }
        #endregion

        #region متد مربوط به ویرایش ناشران

        [HttpGet]
        public IActionResult UpdatePublisher(int id)
        {
            return PartialView("_ModalUpdatePublisher", _publisherService.FindPublisherById(id));
        }

        [HttpPost]
        public IActionResult UpdatePublisher(TBL_ProductPublisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllPublisher));
            }
            if (_publisherService.ExistPublisher(publisher.PublisherFaTitle, publisher.PublisherEnTitle, publisher.Publisherid))
            {
                return RedirectToAction(nameof(ShowAllPublisher));
            }
            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            // نامی دلخواه است getUpdatePublishedid متد 
            bool getUpdatePublishedid = _publisherService.UpdatePublisher(publisher);
            int sendjson = getUpdatePublishedid ? 2 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به حذف ناشران

        [HttpGet]
        public IActionResult DeletePublisher(int id)
        {

            return PartialView("_ModalDidablePublisher", _publisherService.FindPublisherById(id));
        }

        [HttpPost]
        public IActionResult DeletePublisher(TBL_ProductPublisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllPublisher));
            }

            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            bool getDeletePublisherid = _publisherService.DeletePublisher(publisher);
            int sendjson = getDeletePublisherid ? 3 : 4;
            return Json(sendjson);
        }
        #endregion
    }
}
