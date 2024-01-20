using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    // منظور نوع سایز کتاب شامل: رحلی، وزیری و غیره می باشد
    public class TBL_ProductSizeBook
    {
        [Key]
        public int SizeBookid { get; set; }

        [Display(Name = "نام سایز کتاب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(512, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string SizeBookName { get; set; }


        [Display(Name = "نام اندازه سایز کتاب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(512, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string SizeBookRange { get; set; }

        public bool IsDelete { get; set; }
    }
}
