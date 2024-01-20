using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.Base
{
    public interface IEntityObject
    {

    }
    public abstract class FieldPublicInherits : IEntityObject
    {
        public string UserID { get; set; }
        public DateTime CreateDateTime { get; set; }

        //[ForeignKey("UserID")]
        //public virtual ApplicationUsers Users { get; set; }
    }
}
