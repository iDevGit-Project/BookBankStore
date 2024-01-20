using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductFaviorate
    {
        [Key]
        public int Faviorateid { get; set; }

        //public int userid { get; set; }
        public int Productid { get; set; }


        #region Relation

        [ForeignKey(nameof(Productid))]
        public TBL_Product TBLProducts { get; set; }


        //[ForeignKey(nameof(userid))]
        //public user user { get; set; }

        #endregion
    }
}
