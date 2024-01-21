using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.PublicExtentions;
using FarhangbookStore.Services.EntitiesService;
using FarhangbookStore.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FarhangbookStore.Areas.Administrator.Controllers
{
	[Area("Administrator")]
	public class ProductController : Controller
	{
        #region متد مربوط به پیکربندی کلیه آیتم های مربوط به کالای کتاب

        private IProductService _productService;
        private IGroupBooksService _groupBooksService;
        private IProductSizeBookService _productSizeBookService;
        private IPublisherService _publisherService;
        private IWriterService _writerService;
		private ICategoryService _Categoryservice;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, ICategoryService Categoryservice, 
            IGroupBooksService groupBooksService, IProductSizeBookService productSizeBookService, 
            IPublisherService publisherService, IWriterService writerService, IWebHostEnvironment webHostEnvironment)
		{
            // گروه بندی کتاب ها
            _groupBooksService = groupBooksService;
            // گروه بندی انتشارات
            _publisherService = publisherService;
            // گروه بندی مؤلفان
            _writerService = writerService;
            // گروه بندی سایز کتاب ها
            _productSizeBookService = productSizeBookService;
            // گروه بندی دسته بندی ها
            _Categoryservice = Categoryservice;

            _productService = productService;

            _webHostEnvironment = webHostEnvironment;
		}
		public IActionResult ShowAllPropertyname()
		{
			return View(_productService.ShowAllProperty());
        }

        #endregion

        #region متد بارگزاری فایل عکس در سرور و ثبت آدرس در پایگاه داده
        public async Task<IActionResult> UploadFile(IEnumerable<IFormFile> files)
        {
            var upload = Path.Combine(_webHostEnvironment.WebRootPath, "Admin\\images\\upload\\bookImage\\normalImage\\");
            var filename = "";
            foreach (var file in files)
            {
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fileStreamWebHost = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    await file.CopyToAsync(fileStreamWebHost);
                }
            }
            /////////تغییر سایز عکس و ذخیره
            InsertShowImageExtention.ImageResizer img = new InsertShowImageExtention.ImageResizer();
            img.Resize(upload + filename, _webHostEnvironment.WebRootPath + "\\Admin\\images\\upload\\bookImage\\thumbnailimage\\" + filename);
            return Json(
                new
                {
                    status = "success",
                    imagename = filename
                }
                );
        }
        #endregion

        #region متد مربوط به پیکربندی محصولات
        public IActionResult ShowallProduct()
        {
            return View(_productService.ShowallProduct());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.GetAllCategory = _Categoryservice.ShowAllCategory();
            ViewBag.GetAllSubCategory = _Categoryservice.Showsubcategory();
            ViewBag.GetAllSubThreeCategory = _Categoryservice.showAllSubThreeCategory();
            ViewBag.GetAllGroupBooks = _groupBooksService.ShowAllGroupBooks();
            ViewBag.GetAllPublisher = _publisherService.ShowAllPublisher();
            ViewBag.GetAllWriter = _writerService.ShowAllWriter();
            ViewBag.GetAllSizeBook = _productSizeBookService.ShowAllSizeBook();
            //=================================
            return View();
            
        }

        [HttpPost]
        public IActionResult AddProduct(TBL_Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GetAllCategory = _Categoryservice.ShowAllCategory();
                ViewBag.GetAllSubCategory = _Categoryservice.Showsubcategory();
                ViewBag.GetAllSubThreeCategory = _Categoryservice.showAllSubThreeCategory();
                ViewBag.GetAllGroupBooks = _groupBooksService.ShowAllGroupBooks();
                ViewBag.GetAllPublisher = _publisherService.ShowAllPublisher();
                ViewBag.GetAllWriter = _writerService.ShowAllWriter();
                ViewBag.GetAllSizeBook = _productSizeBookService.ShowAllSizeBook();

                return View(product);
            }
            //if (filePicture == null)
            //{
            //    ModelState.AddModelError("ProductImage", "لطفا یک تصویر برای محصول خود انتخاب نمایید .");
            //    addProducts.ProductImage = "Book.png";
            //    return View(addProducts);
            //}

            //string imgname = UploadImageExtension.CreateImage(filePicture);
            //if (imgname == "false")
            //{
            //    TempData["Result"] = "false";
            //    return RedirectToAction(nameof(ShowallProduct));
            //}
            product.ProductCreate = DateTime.Now;
            product.ProductUpdate = DateTime.Now;
            //addProducts.ProductImage = imgname;
            int productid = _productService.AddProduct(product);
            TempData["Result"] = productid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowallProduct));
        }
        #endregion

        #region متد ثبت خصوصیات و ویژه گی ها

        [HttpGet]		
		public IActionResult AddProprtyName()
		{
			// از این متد برای نمایش زیردسته ها در هنگام ثبت خصوصیات و ویژه گی ها برای زیردسته استفاده می شود
            ViewBag.Category = _Categoryservice.Showsubcategory();
            return View();
        }

		[HttpPost]
        public IActionResult AddProprtyName(TBL_PropertyName propertyName, List<int> Categoryid)
        {
			if (!ModelState.IsValid)
			{
                ViewBag.Category = _Categoryservice.Showsubcategory();
			}
            if (_productService.ExistPropertyName(propertyName.PropertyTitle, 0))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است .");
                return View(propertyName);
            }

            int nameid = _productService.AddProprtyName(propertyName);
            if (nameid <= 0)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }

            List<TBL_PropertyName_Category> Addpc = new List<TBL_PropertyName_Category>();

            foreach (var item in Categoryid)
            {
                Addpc.Add(new TBL_PropertyName_Category
                {
                    Categoryid = item,
                    PropertyNameId = nameid,

                });
            }

            bool res = _productService.AddPropertyForCategory(Addpc);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyname));
        }

        #endregion

        #region متد ویرایش خصوصیات و ویژه گی های موجود در دسته بندی ها
        [HttpGet]
        public IActionResult UpdatePropertyName(int id)
        {
            ViewBag.Category = _Categoryservice.Showsubcategory();
            ViewBag.Property = _productService.ShowPropertyNameForUpdate(id);
            return View(_productService.FindPropertyBuyeid(id));
        }

        [HttpPost]
        public IActionResult UpdatePropertyName(TBL_PropertyName propertyName, List<int> Categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _Categoryservice.Showsubcategory();
                ViewBag.Property = _productService.ShowPropertyNameForUpdate(propertyName.PropertyNameId);
                return View();
            }
            if (_productService.ExistPropertyName(propertyName.PropertyTitle, propertyName.PropertyNameId))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است .");
                return View(propertyName);
            }
            bool updateprop = _productService.UpdatePropertyName(propertyName);
            if (!updateprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }
            bool deleteprop = _productService.DeleteProperyForCategory(propertyName.PropertyNameId);
            if (!deleteprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyname));
            }
            List<TBL_PropertyName_Category> categories = new List<TBL_PropertyName_Category>();
            foreach (var item in Categoryid)
            {
                categories.Add(new TBL_PropertyName_Category
                {
                    Categoryid = item,
                    PropertyNameId = propertyName.PropertyNameId,

                });
            }
            bool addpropertyforcategory = _productService.AddPropertyForCategory(categories);
            TempData["Result"] = addpropertyforcategory ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyname));
        }
        #endregion

    }
}
