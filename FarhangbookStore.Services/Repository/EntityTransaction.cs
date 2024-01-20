using FarhangbookStore.DataModel;
using FarhangbookStore.Services.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.Services.Repository
{
    public class EntityTransaction : IEntityTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EntityTransaction(ApplicationDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            //همه دستورات با موفقیت انجام شده است
            _transaction.Commit();
        }

        public void RollBack()
        {
            //وقتی خطایی رخ داد
            _transaction.Rollback();
        }

        public void Dispose()
        {
            //متد خالی کردن حافظه
            _transaction.Dispose();
        }
    }
}
