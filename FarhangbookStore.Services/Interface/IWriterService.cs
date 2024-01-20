using FarhangbookStore.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IWriterService
    {
        List<TBL_ProductWriter> ShowAllWriter();
        List<TBL_ProductWriter> GetAllWriterForMenu();
        int AddWriter(TBL_ProductWriter writer);
        bool UpdateWriter(TBL_ProductWriter writer);
        bool DeleteWriter(TBL_ProductWriter writer);
        bool ExistWriter(string fawritetitle, int writid);
        //==============================================
        TBL_ProductWriter FindWriterById(int writerid);
    }
}
