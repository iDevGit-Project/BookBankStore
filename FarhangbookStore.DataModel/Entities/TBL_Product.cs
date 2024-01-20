using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_Product
    {
        [Key]
        public int Productid { get; set; }

        [Display(Name = "نام کتاب به فارسی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمنتر از {1} باشد .")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد .")]
        public string ProductFaTitle { get; set; }

        [Display(Name = "نام کتاب به انگلیسی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمنتر از {1} باشد .")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد .")]
        public string ProductEnTitle { get; set; }

        //توضیحات کتاب
        public string Description { get; set; }

        //انتشارات
        public string Publishers { get; set; }

        //نوبت چاپ
        public string Published { get; set; }

        //پایه تحصیلی
        public string Circulation { get; set; }

        //نویسنده - ناشر
        public string Writer { get; set; }

        //قیمت کتاب
        public string Price { get; set; }

        //شابک
        public string ISBN { get; set; }

        public string ProductImage { get; set; }
        public string ProductImageAlt { get; set; }
        public string ProductImageTitle { get; set; }

        // تنظیم ویژگی مربوط به کلمات کلیدی به جهت سئو
        public string Keywords { get; set; }

        // تنظیم ویژگی مربوط به توضیحات صفحات به جهت سئو
        public string MetaDescription { get; set; }

        // تنظیم ویژگی مربوط به نامک جهت توصیف کردن محتوای صفحه به جهت سئو
        public string SlugNamaak { get; set; }

        //تعداد فروش
        public int ProductSell { get; set; }

        //امتیاز محصول
        public byte ProductGrade { get; set; }

        //برچسب های محصول
        public string ProductTag { get; set; }

        //تاریخ درج محصول
        [Display(Name = "تاریخ ثبت محصول")]
        public DateTime ProductCreate { get; set; }

        //تاریخ بروزرسانی محصول
        [Display(Name = "تاریخ بروزرسانی محصول")]
        public DateTime ProductUpdate { get; set; }

        //وزن محصول
        //[MinLength(1, ErrorMessage = "{0} نمیتواند کمنتر از {1} باشد .")]
        //[MaxLength(10000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد .")]
        public int ProductWeith { get; set; }

        //محصول در سایت فعال باشد یا خیر؟
        public bool IsActive { get; set; }

        //فعال یا غیرفعالسازی محصول در سایت
        public bool IsDelete { get; set; }
        public int Categoryid { get; set; }
        public int Publisherid { get; set; }
        public int Writerid { get; set; }
        public int SizeBookid { get; set; }
        public int GroupBookid { get; set; }


        //[NotMapped]
        //public int mainprice { get; set; }

        //[NotMapped]
        //public int? sepcialprice { get; set; }


        #region ارتباط های جداول

        [ForeignKey("Categoryid")]
        public TBL_ProductCategory TBLProductCategorys { get; set; }

        [ForeignKey("Publisherid")]
        public TBL_ProductPublisher TBLProductPublishers { get; set; }

        [ForeignKey("Writerid")]
        public TBL_ProductWriter TBLProductWriters { get; set; }

        [ForeignKey("SizeBookid")]
        public TBL_ProductSizeBook TBLProductSizeBooks { get; set; }

        [ForeignKey("GroupBookid")]
        public TBL_ProductGroupBooks TBLProductGroupBooks { get; set; }
        //=================================================================
        //public List<TBL_ProductFaviorate> TBLProductFaviorates { get; set; }
        //public List<TBL_ProductReview> TBLProductReviews { get; set; }
        //public List<TBL_ProductGallery> TBLProductGalleries { get; set; }

        //[ForeignKey("brandid")]
        //public ProductBrand ProductBrand { get; set; }


        //public List<ProductQuestion> questions { get; set; }

        //public List<ProductComment> comments { get; set; }
        //public List<ProductPrice> ProductPrices { get; set; }
        //public List<ProductReating> ProductReatings { get; set; }
        #endregion

    }
}
