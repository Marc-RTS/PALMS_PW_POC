using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class ManageRolePermissionPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator ManageRolePermissionPageHeader => _page.GetByTestId("manage-role-permissions-page-header-title");
    private ILocator DropdownDomain => _page.GetByTestId("manage-role-permissions-domain-autocomplete");
    private ILocator DropdownPage => _page.GetByTestId("manage-role-permissions-page-autocomplete");
    private ILocator DropdownAttributeType => _page.GetByTestId("manage-role-permissions-attribute-type-autocomplete");
    private ILocator DropdownAttributeName => _page.GetByTestId("manage-role-permissions-attribute-name-autocomplete");
    private ILocator DropdownPalmsRoles => _page.GetByTestId("manage-role-permissions-roles-autocomplete");
    private ILocator RowAuditGlobalAdministrator => _page.GetByTestId("manage-role-permissions-Audit-row-Global administrator-avatar");
    private ILocator RowAuditRegionalAdministrator => _page.GetByTestId("manage-role-permissions-Audit-row-Regional administrator-avatar");
    private ILocator RowAuditSuspended => _page.GetByTestId("manage-role-permissions-Audit-row-Suspended-avatar");
    private ILocator RowAuditArranger => _page.GetByTestId("manage-role-permissions-Audit-row-Arranger-avatar");
    private ILocator RowAuditOfficer => _page.GetByTestId("manage-role-permissions-Audit-row-Officer-avatar");
    private ILocator BtnCancelChanges => _page.GetByTestId("manage-role-permissions-cancel-changes-button");
    private ILocator BtnSaveChanges => _page.GetByTestId("manage-role-permissions-save-changes-button");
    private ILocator BtnReset => _page.GetByTestId("manage-role-permissions-reset-button");

    public ILocator GetRowAuditRegionalAdministrator => RowAuditRegionalAdministrator;
    public ILocator GetManageRolePermissionPageHeader => ManageRolePermissionPageHeader;
    public ILocator GetDropdownDomain => DropdownDomain;
    public ILocator GetDropdownPage => DropdownPage;
    public ILocator GetDropdownAttributeType => DropdownAttributeType;
    public ILocator GetDropdownAttributeName => DropdownAttributeName;
    public ILocator GetDropdownPalmsRoles => DropdownPalmsRoles;
    public ILocator GetBtnCancelChanges => BtnCancelChanges;
    public ILocator GetBtnSaveChanges => BtnSaveChanges;
    public ILocator GetBtnReset => BtnReset;

    public async Task FilterDomain(string domain)
    {
        await GetDropdownDomain.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = $"{domain}" }).ClickAsync();
    }
    public async Task FilterPage(string page)
    {
        await GetDropdownPage.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = $"{page}" }).ClickAsync();
    }
    public async Task FilterAttributeType(string attributeType)
    {
        await GetDropdownAttributeType.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = $"{attributeType}" }).ClickAsync();
    }
    public async Task FilterAttributeName(string attributeName)
    {
        await GetDropdownAttributeName.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = $"{attributeName}" }).ClickAsync();
    }
    public async Task FilterPalmsRole(string palmsRole)
    {
        await GetDropdownPalmsRoles.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = $"{palmsRole}" }).ClickAsync();
    }

    public async Task ClickAuditRowRegionalAdministrator()
    {
        await GetRowAuditRegionalAdministrator.ClickAsync();
    }


    public async Task ClickReset()
    {
        await GetBtnReset.ClickAsync();
    }
    public async Task ClickSaveChanges()
    {
        await GetBtnSaveChanges.ClickAsync();
    }


    public async Task SelectAuditRowPermission(string role, string permission)
    {
        await SelectRowPermission("Audit", role, permission);
    }
    /**
     * 
     * @Params 
     * attributeName: Audit
     * role : Global administrator | Regional administrator |Suspended| Arranger | Officer
     * permission: Enabled | No Access
     * **/
    public async Task SelectRowPermission(string attributeName,string role, string permission)
    {
        await _page.GetByTestId($"manage-role-permissions-{attributeName}-row-{role}-avatar").ClickAsync();
        await _page.GetByTestId("manage-role-permsissions-data-grid").GetByRole(AriaRole.Listitem).Locator("div").Nth(1).ClickAsync();
        await _page.GetByText($"{permission}").ClickAsync();
    }

}
