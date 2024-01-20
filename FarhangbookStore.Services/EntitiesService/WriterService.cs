using FarhangbookStore.DataModel;
using FarhangbookStore.DataModel.Entities;
using FarhangbookStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.EntitiesService
{
    public class WriterService : IWriterService
    {
        private readonly ApplicationDbContext _Context;
        public WriterService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public int AddWriter(TBL_ProductWriter writer)
        {
            try
            {
                _Context.TBLProductWriters.Add(writer);
                _Context.SaveChanges();
                return writer.Writerid;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeleteWriter(TBL_ProductWriter writer)
        {
            try
            {
                writer.IsDelete = true;
                _Context.TBLProductWriters.Update(writer);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateWriter(TBL_ProductWriter writer)
        {
            try
            {
                _Context.TBLProductWriters.Update(writer);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ExistWriter(string fawritetitle, int writerid)
        {
            return _Context.TBLProductWriters.Any(w => w.WriterFaTitle == fawritetitle && w.Writerid != writerid && !w.IsDelete);
        }

        public TBL_ProductWriter FindWriterById(int writerid)
        {
            return _Context.TBLProductWriters.Find(writerid);
        }

        public List<TBL_ProductWriter> GetAllWriterForMenu()    
        {
            return _Context.TBLProductWriters.Where(w => !w.IsDelete).ToList();
        }

        public List<TBL_ProductWriter> ShowAllWriter()
        {
            return _Context.TBLProductWriters.Where(w => !w.IsDelete).ToList();
        }
    }
}
