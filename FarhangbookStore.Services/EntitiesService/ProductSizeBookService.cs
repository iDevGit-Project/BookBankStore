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
    public class ProductSizeBookService : IProductSizeBookService
    {
        private readonly ApplicationDbContext _Context;
        public ProductSizeBookService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public List<TBL_ProductSizeBook> ShowAllSizeBook()
        {
            return _Context.TBLProductSizeBooks.Where(w => !w.IsDelete).ToList();
        }
        public int AddSizeBook(TBL_ProductSizeBook sizebook)
        {
            try
            {
                _Context.TBLProductSizeBooks.Add(sizebook);
                _Context.SaveChanges();
                return sizebook.SizeBookid;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public bool UpdateSizeBook(TBL_ProductSizeBook sizebook)
        {
            try
            {
                _Context.TBLProductSizeBooks.Update(sizebook);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSizeBook(TBL_ProductSizeBook sizebook)
        {
            try
            {
                sizebook.IsDelete = true;
                _Context.TBLProductSizeBooks.Update(sizebook);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistSizeBook(string sizeBookname, string sizeBookRange, int sizebookid)
        {
            return _Context.TBLProductSizeBooks.Any(s => s.SizeBookName == sizeBookname && s.SizeBookRange == sizeBookRange && s.SizeBookid != sizebookid && !s.IsDelete);
        }

        public TBL_ProductSizeBook FindSizeBookById(int sizebookid)
        {
            return _Context.TBLProductSizeBooks.Find(sizebookid);

        }

        public List<TBL_ProductSizeBook> GetAllSizeBookForMenu()
        {
            return _Context.TBLProductSizeBooks.Where(w => !w.IsDelete).ToList();
        }


    }
}
