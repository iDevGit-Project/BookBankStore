using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductPublisher
    {
        [Key]
        public int Publisherid { get; set; }

        [Display(Name = "انتشارات به فارسی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string PublisherFaTitle { get; set; }


        [Display(Name = "انتشارات به انگلیسی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string PublisherEnTitle { get; set; }

        public bool IsDelete { get; set; }

    }
}
