using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class ManageUserRolesPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator ManageUserRolesPageHeader => _page.GetByTestId("manage-user-roles-page-header-title");
    public ILocator GetManageUserRolesPageHeader => ManageUserRolesPageHeader;
}
