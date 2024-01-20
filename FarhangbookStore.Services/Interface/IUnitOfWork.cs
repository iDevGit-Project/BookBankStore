using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericCRUDClass<TBL_Product> productUW { get; }
        GenericCRUDClass<TBL_ProductBrand> productBrandUW { get; }
        GenericCRUDClass<TBL_ProductCategory> productCategoryUW { get; }
        GenericCRUDClass<TBL_ProductFaviorate> productFaviorateUW { get; }
        GenericCRUDClass<TBL_ProductGallery> productGalleryUW { get; }
        GenericCRUDClass<TBL_ProductPrice> productPriceUW { get; }
        GenericCRUDClass<TBL_ProductReating> productReatingUW { get; }
        GenericCRUDClass<TBL_ProductReview> productReviewUW { get; }
        GenericCRUDClass<TBL_PropertyName> productPropertyNameUW { get; }
        GenericCRUDClass<TBL_ProductWriter> productWriterUW { get; }
        GenericCRUDClass<TBL_PropertyName_Category> productPropertyNameCategoryUW { get; }
        GenericCRUDClass<TBL_PropertyValue> productPropertyValueUW { get; }
        void Save();
        void SaveAsync();

        IEntityTransaction BeginTransaction();
    }
}
