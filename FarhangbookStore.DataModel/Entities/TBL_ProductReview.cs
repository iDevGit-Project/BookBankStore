using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    //این جدول جهت ثبت توضیحات محصول می باشد
    public class TBL_ProductReview
    {
        [Key]
        public int Reviewid { get; set; }

        [Display(Name = "توضیحات محصول")]
        [MaxLength(50000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string reviewDescription { get; set; }

        [Display(Name = "عنوان مقاله")]
        [MaxLength(10000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string AticleTitle { get; set; }

        [Display(Name = "توضیحات مقاله")]
        public string ArticleDescription { get; set; }

        public int Productid { get; set; }


        #region Relation
        [ForeignKey("Productid")]
        public TBL_Product TBLProducts { get; set; }


        #endregion
    }
}
