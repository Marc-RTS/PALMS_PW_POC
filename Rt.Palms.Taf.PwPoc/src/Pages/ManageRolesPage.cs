using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class ManageRolesPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator ManageRolesPageHeader => _page.GetByTestId("manage-roles-page-header-title");
}
