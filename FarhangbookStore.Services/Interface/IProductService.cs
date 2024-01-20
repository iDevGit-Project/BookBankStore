using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.DataModel.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
	public interface IProductService
	{
        #region سرویس های جدول خصوصیات و ویژه ها به دسته بندی های کتاب

        List<TBL_PropertyName> ShowAllProperty();
		int AddProprtyName(TBL_PropertyName tblPropertyName);
		bool ExistPropertyName(string name, int id);
		bool AddPropertyForCategory(List<TBL_PropertyName_Category> categories);
		List<ViewModel_UpdatePropertyName> ShowPropertyNameForUpdate(int propertynameid);
		bool UpdatePropertyName(TBL_PropertyName propertyName);
		bool DeleteProperyForCategory(int propid);
		TBL_PropertyName FindPropertyBuyeid(int id);

		#endregion

		#region سرویس های جدول کالای کتاب
		List<TBL_Product> ShowallProduct();
        int AddProduct(TBL_Product product);
        TBL_Product FindProductBuyeid(int productid);
        bool UpdateProduct(TBL_Product product);
        int FindCategoryForProduct(int product);

        #endregion
    }
}
