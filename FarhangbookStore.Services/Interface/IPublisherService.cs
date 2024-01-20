using FarhangbookStore.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Interface
{
    public interface IPublisherService
    {
        List<TBL_ProductPublisher> ShowAllPublisher();
        List<TBL_ProductPublisher> GetAllProductPublisherForMenu();
        int AddPublisher(TBL_ProductPublisher publisher);
        bool UpdatePublisher(TBL_ProductPublisher publisher);
        bool DeletePublisher(TBL_ProductPublisher publisher);
        bool ExistPublisher(string publisherFaname, string publisherEnname, int publisherid);
        //==============================================
        TBL_ProductPublisher FindPublisherById(int publisherid);
    }
}
