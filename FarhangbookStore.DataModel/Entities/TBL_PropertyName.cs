using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_PropertyName
    {
        [Key]
        public int PropertyNameId { get; set; }

        // عنوان ویژگی
        [Display(Name = "عنوان خصوصیات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        [MinLength(2, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد")]
        [MaxLength(1024, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string PropertyTitle { get; set; }

        #region Relation
        public List<TBL_PropertyName_Category> TBLPropertyNameCategories { get; set; }
        public List<TBL_PropertyValue> TBLPropertyValues { get; set; }
        public List<TBL_ProductReating> TBLProductReatings { get; set; }

        #endregion
    }
}
