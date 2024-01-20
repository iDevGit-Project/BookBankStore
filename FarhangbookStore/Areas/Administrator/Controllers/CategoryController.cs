using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.EntitiesService;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        #region متد های کلاس سازنده کنترلر دسته بندی

        private ICategoryService _CategoryService;
        public CategoryController(ICategoryService Categoryservice)
        {
            _CategoryService = Categoryservice;
        }
        public IActionResult showAllCategory()
        {
            return View(_CategoryService.ShowAllCategory());
        }
        #endregion

        #region متد مربوط به ثبت دسته بندی
        // در صورتی که بخواهیم از انتقال فرم جهت ثبت اطلاعات استفاده کنیم از این ویژه گی بهره می بریم
        [HttpGet]
        public IActionResult AddCategory(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(TBL_ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = category.SubCategory;
                return View(category);
            }

            if (_CategoryService.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, 0))
            {
                //return Json(5);
                ModelState.AddModelError("CategoryFaTitle", "خطا... دسته بندی وارد شده تکراری است .");
                ViewBag.id = category.SubCategory;
                return View(category);
            }
            int cateid = _CategoryService.AddCategory(category);
            TempData["Result"] = cateid > 0 ? "true" : "false";

            return RedirectToAction(nameof(AddCategory));
        }
        #endregion

        #region متد مربوط به ویرایش دسته بندی

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {

            return PartialView("_ModalUpdateCategory", _CategoryService.findcategorybuyeid(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(TBL_ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(showAllCategory));
            }
            if (_CategoryService.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, category.Categoryid))
            {
                return RedirectToAction(nameof(showAllCategory));
            }
            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            // نامی دلخواه است getUpdateCategoryid متد 
            bool getUpdateCategoryid = _CategoryService.UpdateCategory(category);
            int sendjson = getUpdateCategoryid ? 2 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به حذف دسته بندی

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {

            return PartialView("_ModalDidableCategory", _CategoryService.findcategorybuyeid(id));
        }

        [HttpPost]
        public IActionResult DeleteCategory(TBL_ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(showAllCategory));
            }

            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            bool getDeleteCategoryid = _CategoryService.DeleteCategory(category);
            int sendjson = getDeleteCategoryid ? 3 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به نمایش زیردسته دوم
        [HttpGet]
        public IActionResult ShowAllSubCategory(int id)
        {
            ViewBag.id = id;
            return View(_CategoryService.showAllSubCategory(id));
        }
        #endregion

        #region متد مربوط به ویرایش دسته بندی سطح دوم

        [HttpGet]
        public IActionResult UpdateSubTwoCategory(int id)
        {

            return PartialView("_ModalUpdateSubLastCategory", _CategoryService.findcategorybuyeid(id));
        }

        [HttpPost]
        public IActionResult UpdateSubTwoCategory(TBL_ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(ShowAllSubCategory));
            }
            if (_CategoryService.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, category.Categoryid))
            {
                return RedirectToAction(nameof(ShowAllSubCategory));
            }
            // در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
            // مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
            // نامی دلخواه است getUpdateCategoryid متد 
            bool getUpdateCategoryid = _CategoryService.UpdateCategory(category);
            int sendjson = getUpdateCategoryid ? 2 : 4;
            return Json(sendjson);
        }
        #endregion

        #region متد مربوط به نمایش زیردسته سوم
        [HttpGet]
        public IActionResult ShowAllSubCategorythree(int id)
        {
            ViewBag.id = id;
            return View(_CategoryService.showAllSubCategory(id));
        }
		#endregion

		#region متد مربوط به ویرایش دسته بندی سطح سوم

		[HttpGet]
		public IActionResult UpdateSubThreeCategory(int id)
		{

			return PartialView("_ModalUpdateSubLastCategory", _CategoryService.findcategorybuyeid(id));
		}

		[HttpPost]
		public IActionResult UpdateSubThreeCategory(TBL_ProductCategory category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(ShowAllSubCategory));
			}
			if (_CategoryService.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, category.Categoryid))
			{
				return RedirectToAction(nameof(ShowAllSubCategory));
			}
			// در برنامه می باشد که با اعداد 1و2و3و4 مشخص شده است SweetAlert این متد برای نمایش پیغام های کلاس
			// مراجعه کنید OpenModal.js جهت اطلاعات بیشتر به فایل جاوااسکریپت مربوط به پروژه به نام
			// نامی دلخواه است getUpdateCategoryid متد 
			bool getUpdateCategoryid = _CategoryService.UpdateCategory(category);
			int sendjson = getUpdateCategoryid ? 2 : 4;
			return Json(sendjson);
		}
		#endregion
	}
}
