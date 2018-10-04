import * as React from 'react';
import { BasePropsVM, BaseStateVM, MenuItemVM, UserLevel } from '../../shared';
import { AppSubMenuComponent } from './AppSubmenuComponent';

interface AppMenuPropsVM extends BasePropsVM {
    onMenuItemClick?: (menuItem: MenuItemVM) => void;
}

interface AppMenuStateVM extends BaseStateVM {
    menuItems: MenuItemVM[];
}

export class AppMenuComponent extends React.Component<AppMenuPropsVM, AppMenuStateVM> {

    public state: AppMenuStateVM = {
        menuItems: [
            { label: 'Dashboard', icon: 'pi pi-fw pi-home', showFor: [UserLevel.TransportManager], url: '' },
            {
                label: 'Menu Modes', icon: 'pi pi-fw pi-cog', showFor: [UserLevel.TransportManager],
                items: [
                    { label: 'Static Menu', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager], url: 'static' },
                    { label: 'Overlay Menu', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager],  url: 'overlay' }
                ]
            },
            {
                label: 'Menu Colors', icon: 'pi pi-fw pi-align-left', showFor: [UserLevel.TransportManager],
                items: [
                    { label: 'Dark', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager] },
                    { label: 'Light', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager] }
                ]
            },
            {
                label: 'Components', icon: 'pi pi-fw pi-globe', badge: '9', showFor: [UserLevel.TransportManager],
                items: [
                    { label: 'Sample Page', icon: 'pi pi-fw pi-star-o', showFor: [UserLevel.TransportManager] },
                    { label: 'Forms', icon: 'pi pi-fw pi-calendar', showFor: [UserLevel.TransportManager] },
                    { label: 'Data', icon: 'pi pi-fw pi-align-justify', showFor: [UserLevel.TransportManager] },
                    { label: 'Panels', icon: 'pi pi-fw pi-th-large', showFor: [UserLevel.TransportManager] },
                    { label: 'Overlays', icon: 'pi pi-fw pi-clone', showFor: [UserLevel.TransportManager] },
                    { label: 'Menus', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager] },
                    { label: 'Messages', icon: 'pi pi-fw pi-info-circle', showFor: [UserLevel.TransportManager] },
                    { label: 'Charts', icon: 'pi pi-fw pi-clock', showFor: [UserLevel.TransportManager] },
                    { label: 'Misc', icon: 'pi pi-fw pi-filter', showFor: [UserLevel.TransportManager] }
                ]
            }
        ]
    } 

    render() {
        return (
            <div className="menu">
                <AppSubMenuComponent menuItems={this.state.menuItems} className="layout-main-menu" onMenuItemClick={this.props.onMenuItemClick} isRoot={true} />
            </div>
        );
    }
}