using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuGet.Client.ManagedCodeConventions;

namespace FarhangbookStore.DataModel.Entities
{
    public class TBL_ProductReating
    {
        [Key]
        public int Reatingid { get; set; }

        public int Productid { get; set; }

        //public int userid { get; set; }

        public int PropertyNameId { get; set; }


        public byte Value { get; set; }


        #region Relation

        [ForeignKey(nameof(Productid))]
        public TBL_Product TBLProducts { get; set; }

        //[ForeignKey(nameof(userid))]
        //public user user { get; set; }

        [ForeignKey(nameof(PropertyNameId))]
        public TBL_PropertyName TBLPropertyNames { get; set; }
        #endregion
    }
}
