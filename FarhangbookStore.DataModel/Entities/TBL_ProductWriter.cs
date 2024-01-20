using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductWriter
    {
        [Key]
        public int Writerid { get; set; }

        [Display(Name = "نام نویسنده به فارسی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(512, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string WriterFaTitle { get; set; }

        public bool IsDelete { get; set; }
    }
}
