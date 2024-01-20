using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarhangbookStore.Areas.Administrator.Views.ViewComponents
{

	#region Admin_QuickAccessViewComponent
	public class Admin_QuickAccessViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Admin_QuickAccess");
		}
	}
	#endregion
}
