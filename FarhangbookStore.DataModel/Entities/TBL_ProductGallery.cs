using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductGallery
    {
        [Key]
        public int galleryid { get; set; }

        //تصویر محصول
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
        public string ImageName { get; set; }

        public int Productid { get; set; }


        #region Relation

        [ForeignKey("Productid")]
        public TBL_Product TBLProducts { get; set; }

        #endregion
    }
}
