using FarhangbookStore.DataModel;
using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.EntitiesService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _Context;
        public CategoryService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public int AddCategory(TBL_ProductCategory category)
        {
            try
            {
                _Context.TBLProductCategories.Add(category);
                _Context.SaveChanges();
                return category.Categoryid;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteCategory(TBL_ProductCategory category)
        {
            try
            {
                category.IsDelete = true;
                _Context.TBLProductCategories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TBL_ProductCategory findcategorybuyeid(int categoryid)
        {
            return _Context.TBLProductCategories.Find(categoryid);
        }

        public List<TBL_ProductCategory> ShowAllCategory()
        {
            return _Context.TBLProductCategories.Where(c => !c.IsDelete && c.SubCategory == null).ToList();
        }

        public List<TBL_ProductCategory> showAllSubCategory(int categoryid)
        {
            return _Context.TBLProductCategories.Where(c => !c.IsDelete && c.SubCategory == categoryid).ToList();
        }

		public List<TBL_ProductCategory> showAllSubThreeCategory(int categoryid)
		{
			return _Context.TBLProductCategories.Where(c => !c.IsDelete && c.SubCategory == categoryid).ToList();
		}

		public bool UpdateCategory(TBL_ProductCategory category)
        {
            try
            {
                _Context.TBLProductCategories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSubTwoCategory(TBL_ProductCategory category)
        {
            try
            {
                _Context.TBLProductCategories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSubThreeCategory(TBL_ProductCategory category)
        {
            try
            {
                _Context.TBLProductCategories.Update(category);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ExistCategory(string fatitle, string entitle, int cateid)
        {
            return _Context.TBLProductCategories.Any(c => c.CategoryFaTitle == fatitle && c.CategoryEnTitle == entitle && c.Categoryid != cateid && !c.IsDelete);
        }

        // متد مربوط به نمایش زیردسته ها جهت ثبت ویژه گی ها برای هر کدام از زیردسته ها
        public List<TBL_ProductCategory> Showsubcategory()
        {
            return _Context.TBLProductCategories.Where(c => c.SubCategory != null).ToList();
        }

        public List<TBL_ProductCategory> GetAllCategoryForMenu()
        {
            return _Context.TBLProductCategories.Where(c => !c.IsDelete).ToList();
        }

        public List<TBL_ProductCategory> showAllSubThreeCategory()
        {
            return _Context.TBLProductCategories.Where(c => c.SubCategory != null).ToList();
        }
    }
}
