using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Pages.Common;
using Rt.Palms.Taf.PwPoc.src.Pages.Poppers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class SearchCustomerProfilePage(IPage page)
{
    private readonly SearchContainer _searchContainer = new(page);
    public ILocator GetChkboxPalmsOnly => _searchContainer.GetChkboxPalmsOnly;
    public ILocator GetBtnCreateCustomerProfile => _searchContainer.GetBtnCreateCustomerProfile;
}
