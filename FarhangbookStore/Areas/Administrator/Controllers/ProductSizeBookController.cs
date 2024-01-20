using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductSizeBookController : Controller
    {
        #region متد مربوط به پیکربندی سایز کتاب

        private IProductSizeBookService _sizeBookService;
        public ProductSizeBookController(IProductSizeBookService sizeBookService)
        {
            _sizeBookService = sizeBookService;
        }
        public IActionResult ShowAllSizeBook()
        {
            return View(_sizeBookService.ShowAllSizeBook());
        }

        #endregion

        #region متد ثبت اطلاعات سایز کتاب

        [HttpGet]
        public IActionResult AddSizeBook(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSizeBook(TBL_ProductSizeBook sizeBook)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllSizeBook));
            }
            if (_sizeBookService.ExistSizeBook(sizeBook.SizeBookName, sizeBook.SizeBookRange, 0))
            {
                ModelState.AddModelError("PublisherFaTitle", "خطا... اطلاعات سایز کتاب وارد شده تکراری است .");
                return View(sizeBook);
            }
            int cateid = _sizeBookService.AddSizeBook(sizeBook);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(AddSizeBook));
        }
        #endregion

        #region متد مربوط به ویرایش سایز کتاب

        [HttpGet]
        public IActionResult UpdateSizeBook(int id)
        {
            return PartialView("_ModalUpdateSizeBook", _sizeBookService.FindSizeBookById(id));
        }

        [HttpPost]
        public IActionResult UpdateSizeBook(TBL_ProductSizeBook sizeBook)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllSizeBook));
            }
            if (_sizeBookService.ExistSizeBook(sizeBook.SizeBookName, sizeBook.SizeBookRange, sizeBook.SizeBookid))
            {
                return RedirectToAction(nameof(ShowAllSizeBook));
            }
            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            // نامی دلخواه است getUpdatePublishedid متد 
            bool getUpdateSizeBookid = _sizeBookService.UpdateSizeBook(sizeBook);
            int sendjson = getUpdateSizeBookid ? 2 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به حذف سایز کتاب

        [HttpGet]
        public IActionResult DeleteSizeBook(int id)
        {

            return PartialView("_ModalDidableSizeBook", _sizeBookService.FindSizeBookById(id));
        }

        [HttpPost]
        public IActionResult DeleteSizeBook(TBL_ProductSizeBook sizeBook)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllSizeBook));
            }

            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            bool getDeleteSizeBookid = _sizeBookService.DeleteSizeBook(sizeBook);
            int sendjson = getDeleteSizeBookid ? 3 : 4;
            return Json(sendjson);
        }
        #endregion
    }
}
