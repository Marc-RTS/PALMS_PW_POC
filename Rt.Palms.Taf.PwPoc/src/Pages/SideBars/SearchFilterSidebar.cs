using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

internal class SearchFilterSidebar(IPage page)
{
    private readonly IPage _page = page;
    private ILocator SearchFilterHeader => _page.GetByTestId("search-sidebar-header");
}
