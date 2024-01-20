using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.EntitiesService;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class GroupBooksController : Controller
    {
        #region متد مربوط به پیکربندی گروه بندی کتاب
        private IGroupBooksService _groupBooksService;
        public GroupBooksController(IGroupBooksService groupBooksService)
        {
            _groupBooksService = groupBooksService;
        }
        public IActionResult ShowAllGroupBooks()
        {
            return View(_groupBooksService.ShowAllGroupBooks());
        }
        #endregion

        #region متد ثبت اطلاعات گروه بندی کتاب

        [HttpGet]
        public IActionResult AddGroupBooks(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddGroupBooks(TBL_ProductGroupBooks gBooks)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllGroupBooks));
            }
            if (_groupBooksService.ExistGroupBooks(gBooks.GroupBookTitle, 0))
            {
                ModelState.AddModelError("GroupBookTitle", "خطا... اطلاعات گروه کتاب وارد شده تکراری است .");
                return View(gBooks);
            }
            int cateid = _groupBooksService.AddGroupBooks(gBooks);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(AddGroupBooks));
        }
        #endregion

        #region متد مربوط به ویرایش گروه بندی کتاب

        [HttpGet]
        public IActionResult UpdateGroupBooks(int id)
        {
            return PartialView("_ModalUpdateGroupBooks", _groupBooksService.FindGroupBooksById(id));
        }

        [HttpPost]
        public IActionResult UpdateGroupBooks(TBL_ProductGroupBooks gBooks)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllGroupBooks));
            }
            if (_groupBooksService.ExistGroupBooks(gBooks.GroupBookTitle, gBooks.GroupBookid))
            {
                return RedirectToAction(nameof(ShowAllGroupBooks));
            }
            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            // نامی دلخواه است getUpdatePublishedid متد 
            bool getUpdatePublishedid = _groupBooksService.UpdateGroupBooks(gBooks);
            int sendjson = getUpdatePublishedid ? 2 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به حذف گروه بندی کتاب

        [HttpGet]
        public IActionResult DeleteGroupBooks(int id)
        {

            return PartialView("_ModalDidableGroupBooks", _groupBooksService.FindGroupBooksById(id));
        }

        [HttpPost]
        public IActionResult DeleteGroupBooks(TBL_ProductGroupBooks gBooks)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllGroupBooks));
            }

            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            bool getDeletegBooksid = _groupBooksService.DeleteGroupBooks(gBooks);
            int sendjson = getDeletegBooksid ? 3 : 4;
            return Json(sendjson);
        }
        #endregion
    }
}
