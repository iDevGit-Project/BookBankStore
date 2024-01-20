using FarhangbookStore.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IProductSizeBookService
    {
        List<TBL_ProductSizeBook> ShowAllSizeBook();
        List<TBL_ProductSizeBook> GetAllSizeBookForMenu();
        int AddSizeBook(TBL_ProductSizeBook sizebook);
        bool UpdateSizeBook(TBL_ProductSizeBook sizebook);
        bool DeleteSizeBook(TBL_ProductSizeBook sizebook);
        bool ExistSizeBook(string sizeBookname, string sizeBookRange, int sizebookid);
        //==============================================
        TBL_ProductSizeBook FindSizeBookById(int sizebookid);
    }
}
