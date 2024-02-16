using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages.Poppers;

internal class SaveOrClearChangesPopper(IPage page)
{
    private readonly IPage _page = page;
    private ILocator SaveOrCancelChangesHeader => _page.Locator(".MuiDialogTitle-root");
    private ILocator SaveOrCancelChangesContent => _page.Locator(".MuiDialogContent-root");
    private ILocator BtnCancel => _page.Locator(".MuiDialogActions-root").GetByText("Cancel");
    private ILocator BtnClearChanges => _page.Locator(".MuiDialogActions-root").GetByText("Clear changes");
    private ILocator BtnSaveChanges => _page.Locator(".MuiDialogActions-root").GetByText("Save changes");
    public ILocator GetSaveOrCancelChangesHeader => SaveOrCancelChangesHeader;
    public ILocator GetSaveOrCancelChangesContent => SaveOrCancelChangesContent;
    public ILocator GetBtnCancel => BtnCancel;
    public ILocator GetBtnSaveChanges => BtnSaveChanges;
    public ILocator GetBtnClearChanges => BtnClearChanges;

    public async Task ClickButtonCancel()
    {
        await GetBtnCancel.ClickAsync();
    }

    public async Task ClickButtonClearChanges()
    {
        await GetBtnClearChanges.ClickAsync();
    }

    public async Task ClickButtonSaveChanges()
    {
        await GetBtnSaveChanges.ClickAsync();
    }
}
