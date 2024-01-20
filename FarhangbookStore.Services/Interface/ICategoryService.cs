using FarhangbookStore.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface ICategoryService
    {
        List<TBL_ProductCategory> ShowAllCategory();

        int AddCategory(TBL_ProductCategory category);

        bool UpdateCategory(TBL_ProductCategory category);

        bool UpdateSubTwoCategory(TBL_ProductCategory category);

        bool UpdateSubThreeCategory(TBL_ProductCategory category);

        bool DeleteCategory(TBL_ProductCategory category);

        List<TBL_ProductCategory> showAllSubCategory(int categoryid);

        TBL_ProductCategory findcategorybuyeid(int categoryid);

        bool ExistCategory(string fatitle, string entitle, int cateid);
        List<TBL_ProductCategory> Showsubcategory();
        List<TBL_ProductCategory> GetAllCategoryForMenu();
    }
}
