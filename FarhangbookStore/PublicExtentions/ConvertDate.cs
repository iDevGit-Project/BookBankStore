using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.PublicExtentions
{
    public class ConvertDate
    {
        public DateTime ConvertShamsiToMiladi(string Date)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
            return persianDateTime.ToDateTime();
        }

        public string ConvertMiladiToShamsi(DateTime Date, string Format)
        {
            PersianDateTime persianDateTime = new PersianDateTime(Date);
            return persianDateTime.ToString(Format);
        }
    }
}
