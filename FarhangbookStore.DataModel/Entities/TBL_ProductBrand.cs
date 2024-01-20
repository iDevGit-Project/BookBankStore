using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductBrand
    {
        [Key]
        public int brandid { get; set; }

        // عنوان برند کتاب
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(5, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string brandname { get; set; }

        #region relation

        public List<TBL_Product> TBLProducts { get; set; }

        #endregion
    }
}
