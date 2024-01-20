using FarhangbookStore.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IGroupBooksService
    {
        List<TBL_ProductGroupBooks> ShowAllGroupBooks();
        List<TBL_ProductGroupBooks> GetAllGroupBooksForMenu();
        int AddGroupBooks(TBL_ProductGroupBooks groupBook);
        bool UpdateGroupBooks(TBL_ProductGroupBooks groupBook);
        bool DeleteGroupBooks(TBL_ProductGroupBooks groupBook);
        bool ExistGroupBooks(string groupBookFaname, int groupBookid);
        //==============================================
        TBL_ProductGroupBooks FindGroupBooksById(int groupBookid);
    }
}
