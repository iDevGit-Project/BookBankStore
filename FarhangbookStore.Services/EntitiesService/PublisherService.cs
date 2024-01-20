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
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _Context;
        public PublisherService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public int AddPublisher(TBL_ProductPublisher publisher)
        {
            try
            {
                _Context.TBLProductPublishers.Add(publisher);
                _Context.SaveChanges();
                return publisher.Publisherid;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool UpdatePublisher(TBL_ProductPublisher publisher)
        {
            try
            {
                _Context.TBLProductPublishers.Update(publisher);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePublisher(TBL_ProductPublisher publisher)
        {
            try
            {
                publisher.IsDelete = true;
                _Context.TBLProductPublishers.Update(publisher);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ExistPublisher(string publisherFaname, string publisherEnname, int publisherid)
        {
            return _Context.TBLProductPublishers.Any(p => p.PublisherFaTitle== publisherFaname && p.PublisherEnTitle== publisherEnname && p.Publisherid != publisherid && !p.IsDelete);
        }

        public TBL_ProductPublisher FindPublisherById(int publisherid)
        {
            return _Context.TBLProductPublishers.Find(publisherid);
        }

        public List<TBL_ProductPublisher> GetAllProductPublisherForMenu()
        {
            return _Context.TBLProductPublishers.Where(w => !w.IsDelete).ToList();

        }

        public List<TBL_ProductPublisher> ShowAllPublisher()
        {
            return _Context.TBLProductPublishers.Where(w => !w.IsDelete).ToList();
        }

    }
}
