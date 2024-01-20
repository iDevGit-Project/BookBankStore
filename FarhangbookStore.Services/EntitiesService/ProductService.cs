using FarhangbookStore.DataModel;
using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.DataModel.EntityViewModels;
using FarhangbookStore.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.EntitiesService
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _Context;
		public ProductService(ApplicationDbContext Context) 
		{ 
			_Context = Context;
		}

        #region کلیه متد های مربوط به جدول خصوصیات و ویژه گی های دسته بندی های کالای کتاب

        #region سرویس خصوصیات و ویژه گی ها

        public bool ExistPropertyname(string name, int id)
        {
            return _Context.TBLPropertyNames.Any(p => p.PropertyTitle == name && p.PropertyNameId != id);
        }

        public TBL_PropertyName FindPropertyBuyeid(int id)
        {
            return _Context.TBLPropertyNames.Find(id);
        }
        public bool ExistPropertyName(string name, int id)
        {
            return _Context.TBLPropertyNames.Any(p => p.PropertyTitle == name && p.PropertyNameId != id);
        }
        public List<TBL_PropertyName> ShowAllProperty()
        {
            return _Context.TBLPropertyNames.ToList();
        }

        #endregion

        #region متد ثبت خصوصیات و ویژه گی ها برای دسته بندی ها
        public bool AddPropertyForCategory(List<TBL_PropertyName_Category> categories)
        {
            try
            {
                _Context.TBLPropertyNameCategories.AddRange(categories);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region متد حذف خصوصیات و ویژه گی ها برای دسته بندی ها
        public bool DeleteProperyForCategory(int propid)
        {
            try
            {
                List<TBL_PropertyName_Category> categories = _Context.TBLPropertyNameCategories.Where(c => c.PropertyNameId == propid).ToList();
                _Context.TBLPropertyNameCategories.RemoveRange(categories);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        #endregion

        #region  متد ویرایش خصوصیات و ویژه گی ها موجود در دسته بندی ها
        public List<ViewModel_UpdatePropertyName> ShowPropertyNameForUpdate(int propertynameid)
        {
            // ترکیب دو جدول به صورت همزمان با استفاده از ویو مدل
            List<ViewModel_UpdatePropertyName> updates = (from pc in _Context.TBLPropertyNameCategories
                                                          join p in _Context.TBLPropertyNames on pc.PropertyNameId equals p.PropertyNameId
                                                          where (pc.PropertyNameId == propertynameid)
                                                          select new ViewModel_UpdatePropertyName
                                                          {
                                                              pncId = pc.pncId,
                                                              Categoryid = pc.Categoryid,
                                                              PropertyNameId = p.PropertyNameId,
                                                              PropertyTitle = p.PropertyTitle,

                                                          }).ToList();
            return updates;
        }
        #endregion

        #region متد بروزرسانی خصوصیات و ویژه گی ها

        public bool UpdatePropertyName(TBL_PropertyName propertyName)
        {
            try
            {
                _Context.TBLPropertyNames.Update(propertyName);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region متد ثبت خصوصیات و ویژه گی ها
        public int AddProprtyName(TBL_PropertyName tblPropertyName)
        {
            try
            {
                _Context.TBLPropertyNames.Add(tblPropertyName);
                _Context.SaveChanges();
                return tblPropertyName.PropertyNameId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #endregion

        #region کلیه متد های مربوط به جدول ثبت، ویرایش، حذف و مدیریت کالای کتاب

        #region متد نمایش کلیه اطلاعات کالای کتاب
        public List<TBL_Product> ShowallProduct()
        {
            return _Context.TBLProducts.Where(p => !p.IsDelete).ToList();
        }
        public TBL_Product FindProductBuyeid(int productid)
        {
            return _Context.TBLProducts.Find(productid);
        }
        public int FindCategoryForProduct(int product)
        {
            return _Context.TBLProducts.Where(p => p.Productid == product).Select(p => p.Categoryid).SingleOrDefault();
        }
        #endregion

        #region متد ثبت کلیه اطلاعات کالای کتاب
        public int AddProduct(TBL_Product product)
        {
            try
            {
                _Context.TBLProducts.Add(product);
                _Context.SaveChanges();
                return product.Productid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region متد بروزرسانی اطلاعات کالای کتاب
        public bool UpdateProduct(TBL_Product product)
        {
            try
            {
                _Context.TBLProducts.Update(product);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #endregion

    }
}
