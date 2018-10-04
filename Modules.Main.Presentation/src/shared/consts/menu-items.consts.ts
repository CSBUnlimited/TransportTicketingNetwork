import { MenuItemVM, UserLevel } from "../models";


export const getMenuItemsConsts = (changeURLCommand: (menuItem: MenuItemVM) => void): MenuItemVM[] => {
    return [
        { label: 'Dashboard', icon: 'pi pi-fw pi-home', showFor: [UserLevel.TransportManager] },
        {
            label: 'Menu Modes', icon: 'pi pi-fw pi-cog', showFor: [UserLevel.TransportManager],
            items: [
                { label: 'Static Menu', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager] },
                { label: 'Overlay Menu', icon: 'pi pi-fw pi-bars', showFor: [UserLevel.TransportManager] }
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
    ];
} 
