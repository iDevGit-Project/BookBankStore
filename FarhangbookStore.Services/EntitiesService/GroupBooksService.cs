using FarhangbookStore.DataModel;
using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Interface;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.EntitiesService
{
    public class GroupBooksService : IGroupBooksService
    {
        private readonly ApplicationDbContext _Context;
        public GroupBooksService(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public List<TBL_ProductGroupBooks> ShowAllGroupBooks()
        {
            return _Context.TBLProductGroupBooks.Where(g => !g.IsDelete).ToList();
        }
        public int AddGroupBooks(TBL_ProductGroupBooks groupBook)
        {
            try
            {
                _Context.TBLProductGroupBooks.Add(groupBook);
                _Context.SaveChanges();
                return groupBook.GroupBookid;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public bool UpdateGroupBooks(TBL_ProductGroupBooks groupBook)
        {
            try
            {
                _Context.TBLProductGroupBooks.Update(groupBook);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroupBooks(TBL_ProductGroupBooks groupBook)
        {
            try
            {
                groupBook.IsDelete = true;
                _Context.TBLProductGroupBooks.Update(groupBook);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistGroupBooks(string groupBookFaname, int groupBookid)
        {
            return _Context.TBLProductGroupBooks.Any(g => g.GroupBookTitle == groupBookFaname && g.GroupBookid != groupBookid && !g.IsDelete);
        }

        public TBL_ProductGroupBooks FindGroupBooksById(int groupBookid)
        {
            return _Context.TBLProductGroupBooks.Find(groupBookid);
        }

        public List<TBL_ProductGroupBooks> GetAllGroupBooksForMenu()
        {
            return _Context.TBLProductGroupBooks.Where(w => !w.IsDelete).ToList();
        }
    }
}
