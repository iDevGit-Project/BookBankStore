using FarhangbookStore.DataModel;
using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Interface;
using FarhangbookStore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        //==================================================================================
        private GenericCRUDClass<TBL_Product> _product;
        private GenericCRUDClass<TBL_ProductBrand> _productBrand;
        private GenericCRUDClass<TBL_ProductCategory> _productCategory;
        private GenericCRUDClass<TBL_ProductFaviorate> _productFaviorate;
        private GenericCRUDClass<TBL_ProductGallery> _productGallery;
        private GenericCRUDClass<TBL_ProductPrice> _productPrice;
        private GenericCRUDClass<TBL_ProductReating> _productReating;
        private GenericCRUDClass<TBL_ProductReview> _productReview;
        private GenericCRUDClass<TBL_PropertyName> _productPropertyName;
        private GenericCRUDClass<TBL_PropertyName_Category> _productNameCategory;
        private GenericCRUDClass<TBL_PropertyValue> _productValue;
        private GenericCRUDClass<TBL_ProductWriter> _productWriter ;
        //==================================================================================

        //ثبت کالای کتاب
        public GenericCRUDClass<TBL_Product> productUW
        {
            //فقط خواندنی
            get
            {
                if (_product == null)
                {
                    _product = new GenericCRUDClass<TBL_Product>(_context);
                }
                return _product;
            }
        }

        // ثبت عنوان برند کتاب
        public GenericCRUDClass<TBL_ProductBrand> productBrandUW
        {
            //فقط خواندنی
            get
            {
                if (_productBrand == null)
                {
                    _productBrand = new GenericCRUDClass<TBL_ProductBrand>(_context);
                }
                return _productBrand;
            }
        }

        //ثبت دسته بندی کتاب
        public GenericCRUDClass<TBL_ProductCategory> productCategoryUW
        {
            //فقط خواندنی
            get
            {
                if (_productCategory == null)
                {
                    _productCategory = new GenericCRUDClass<TBL_ProductCategory>(_context);
                }
                return _productCategory;
            }
        }

        //ثبت اضافه کردن به علاقه مندی های کتاب
        public GenericCRUDClass<TBL_ProductFaviorate> productFaviorateUW
        {
            //فقط خواندنی
            get
            {
                if (_productFaviorate == null)
                {
                    _productFaviorate = new GenericCRUDClass<TBL_ProductFaviorate>(_context);
                }
                return _productFaviorate;
            }
        }

        //ثبت تصویر کتاب
        public GenericCRUDClass<TBL_ProductGallery> productGalleryUW
        {
            //فقط خواندنی
            get
            {
                if (_productGallery == null)
                {
                    _productGallery = new GenericCRUDClass<TBL_ProductGallery>(_context);
                }
                return _productGallery;
            }
        }

        //ثبت قیمت کتاب
        public GenericCRUDClass<TBL_ProductPrice> productPriceUW
        {
            //فقط خواندنی
            get
            {
                if (_productPrice == null)
                {
                    _productPrice = new GenericCRUDClass<TBL_ProductPrice>(_context);
                }
                return _productPrice;
            }
        }

        //ثبت امتیاز کتاب
        public GenericCRUDClass<TBL_ProductReating> productReatingUW
        {
            //فقط خواندنی
            get
            {
                if (_productReating == null)
                {
                    _productReating = new GenericCRUDClass<TBL_ProductReating>(_context);
                }
                return _productReating;
            }
        }

        //ثبت مشخصات کتاب
        public GenericCRUDClass<TBL_ProductReview> productReviewUW
        {
            //فقط خواندنی
            get
            {
                if (_productReview == null)
                {
                    _productReview = new GenericCRUDClass<TBL_ProductReview>(_context);
                }
                return _productReview;
            }
        }

        //ثبت ویژه گی های کتاب
        public GenericCRUDClass<TBL_PropertyName> productPropertyNameUW
        {
            //فقط خواندنی
            get
            {
                if (_productPropertyName == null)
                {
                    _productPropertyName = new GenericCRUDClass<TBL_PropertyName>(_context);
                }
                return _productPropertyName;
            }
        }

        //ثبت ویژه گی برای دسته بندی کتاب
        public GenericCRUDClass<TBL_PropertyName_Category> productPropertyNameCategoryUW
        {
            //فقط خواندنی
            get
            {
                if (_productNameCategory == null)
                {
                    _productNameCategory = new GenericCRUDClass<TBL_PropertyName_Category>(_context);
                }
                return _productNameCategory;
            }
        }

        //ثبت مقادیر برای ویژه گی های کتاب
        public GenericCRUDClass<TBL_PropertyValue> productPropertyValueUW
        {
            //فقط خواندنی
            get
            {
                if (_productValue == null)
                {
                    _productValue = new GenericCRUDClass<TBL_PropertyValue>(_context);
                }
                return _productValue;
            }
        }

        //ثبت مقادیر برای درج اطلاعات چدید نویسنده کتاب
        public GenericCRUDClass<TBL_ProductWriter> productWriterUW
        {
            //فقط خواندنی
            get
            {
                if (_productWriter == null)
                {
                    _productWriter = new GenericCRUDClass<TBL_ProductWriter>(_context);
                }
                return _productWriter;
            }
        }

        //==================================================================================
        public IEntityTransaction BeginTransaction()
        {
            return new EntityTransaction(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
