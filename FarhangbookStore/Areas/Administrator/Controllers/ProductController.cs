using FarhangbookStore.Common.PublicTools;
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
        private IProductSizeBookService _productSizeBookService;
        private IPublisherService _publisherService;
        private IWriterService _writerService;
		private ICategoryService _Categoryservice;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, ICategoryService Categoryservice, 
            IProductSizeBookService productSizeBookService, 
            IPublisherService publisherService, IWriterService writerService, IWebHostEnvironment webHostEnvironment)
		{
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

        #region متد مربوط به ثبت محصول جدید
        public IActionResult ShowallProduct()
        {
            return View(_productService.ShowallProduct());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.GetAllSubCategory = _Categoryservice.Showsubcategory();
            ViewBag.GetAllPublisher = _publisherService.ShowAllPublisher();
            ViewBag.GetAllWriter = _writerService.ShowAllWriter();
            ViewBag.GetAllSizeBook = _productSizeBookService.ShowAllSizeBook();
            //=================================
            return View();
            
        }

		[HttpPost]
		public IActionResult AddProduct(TBL_Product product, IFormFile file)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.GetAllSubCategory = _Categoryservice.Showsubcategory();
                ViewBag.GetAllPublisher = _publisherService.ShowAllPublisher();
                ViewBag.GetAllWriter = _writerService.ShowAllWriter();
                ViewBag.GetAllSizeBook = _productSizeBookService.ShowAllSizeBook();
                return View(product);
			}
			if (file == null)
			{
				ModelState.AddModelError("SliderImg", "لطفا یک تصویر برای محصول خود انتخاب نمایید .");
				return View(product);

			}

			string imgname = UploadImageExtension.CreateImage(file);
			if (imgname == "false")
			{
				TempData["Result"] = "false";
				return RedirectToAction(nameof(ShowallProduct));
			}
			product.ProductCreate = DateTime.Now;
			product.ProductUpdate = DateTime.Now;
			product.ProductImage = imgname;
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
