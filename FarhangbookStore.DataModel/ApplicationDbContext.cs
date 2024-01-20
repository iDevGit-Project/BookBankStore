using FarhangbookStore.DataModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        #region DbSets All Tables

        public DbSet<TBL_Product> TBLProducts { get; set; }
        public DbSet<TBL_ProductCategory> TBLProductCategories { get; set; }
        public DbSet<TBL_ProductGallery> TBLProductGalleries { get; set; }
        public DbSet<TBL_ProductReview> TBLProductReviews { get; set; }
        public DbSet<TBL_PropertyName> TBLPropertyNames { get; set; }
        public DbSet<TBL_PropertyName_Category> TBLPropertyNameCategories { get; set; }
        public DbSet<TBL_ProductPrice> TBLProductPrices { get; set; }
        public DbSet<TBL_PropertyValue> TBLPropertyValueies { get; set; }
        public DbSet<TBL_ProductReating> TBLProductReatings { get; set; }
        public DbSet<TBL_ProductFaviorate> TBLProductFaviorates { get; set; }
        public DbSet<TBL_ProductWriter> TBLProductWriters { get; set; }
        public DbSet<TBL_ProductPublisher> TBLProductPublishers { get; set; }
        public DbSet<TBL_ProductSizeBook> TBLProductSizeBooks { get; set; }
        public DbSet<TBL_ProductGroupBooks> TBLProductGroupBooks { get; set; }
        #endregion

        //نوشتن تابع جهت از بین بردن خطای مربوط به ارتباط یک جدول با خودش
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
