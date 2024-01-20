using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_PropertyValue
    {
        [Key]
        public int PropertyValueId { get; set; }


        [Display(Name = "مقدار خصوصیات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(10, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string PropertyValue { get; set; }

        public int PropertyNameId { get; set; }

        public int Productid { get; set; }

        #region Relation
        [ForeignKey("Productid")]
        public TBL_Product TBLProducts { get; set; }

        [ForeignKey("PropertyNameId")]
        public TBL_PropertyName TBLPropertyNames { get; set; }


        #endregion
    }
}
