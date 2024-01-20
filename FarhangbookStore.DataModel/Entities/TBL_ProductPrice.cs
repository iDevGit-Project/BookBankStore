using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductPrice
    {
        [Key]
        public int Productpriceid { get; set; }

        //قیمت اصلی محصول
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int mainprice { get; set; }

        // قیمت با تخفیف یا قیمت ویژه
        public int? sepcialprice { get; set; }

        //تعداد کالا
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int count { get; set; }

        //تعداد خرید کالا توسط کاربر
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public int MaxorderCount { get; set; }

        public int Productid { get; set; }

        //زمان ثبت کالا
        public DateTime Createdate { get; set; }

        //زمان پایان تخفیف
        public DateTime? EndDateDisCount { get; set; }

        #region relation

        [ForeignKey("Productid")]
        public TBL_Product TBLProducts { get; set; }

        #endregion
    }
}
