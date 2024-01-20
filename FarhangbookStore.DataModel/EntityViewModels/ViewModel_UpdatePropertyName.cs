using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookStore.DataModel.EntityViewModels
{
	public class ViewModel_UpdatePropertyName
	{
		public int PropertyNameId { get; set; }

		// عنوان ویژگی
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد .")]
		[MinLength(5, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string PropertyTitle { get; set; }
		public int pncId { get; set; }
		public int Categoryid { get; set; }
	}
}
