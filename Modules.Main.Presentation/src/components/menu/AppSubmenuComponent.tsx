import * as React from 'react';
import classNames from 'classnames';
import { MenuItemVM, BasePropsVM, BaseStateVM, Util } from '../../shared';

interface AppSubMenuPropsVM extends BasePropsVM {
    menuItems?: MenuItemVM[];
    onMenuItemClick?: (menuItem: MenuItemVM) => void;
    isRoot?: boolean,
    className?: string;
}

interface AppSubMenuStateVM extends BaseStateVM {
    activeIndex: number | null;
}

export class AppSubMenuComponent extends React.Component<AppSubMenuPropsVM, AppSubMenuStateVM> {

    public state: AppSubMenuStateVM = {
        activeIndex: null
    };

    private onMenuItemClick(event, menuItem: MenuItemVM, index: number): void {
        //avoid processing disabled items
        if (menuItem.isDisabled) {
            event.preventDefault();
            return;
        }

        //execute command
        if (menuItem.command) {
            menuItem.command(menuItem);
        }

        //prevent hash change
        if (menuItem.items || !menuItem.isOutsideURL) {
            event.preventDefault();
        }

        if (index === this.state.activeIndex && Util.isArrayHasElements(menuItem.items)) {
            this.setState({ activeIndex: null });
        }
        else if (index !== this.state.activeIndex) {
            this.setState({ activeIndex: index });
        }

        if (this.props.onMenuItemClick) {
            this.props.onMenuItemClick(menuItem);
        }
    }

    render() {
        let items: JSX.Element[] | null = this.props.menuItems ? this.props.menuItems.map((menuItem, index) => {

            let isActive: boolean = Boolean(this.state.activeIndex === index);
            let styleClass: string = classNames({ 'active-menuitem': isActive });
            let badgeJSX: JSX.Element | null = menuItem.badge ? (<span className="menuitem-badge">{menuItem.badge}</span>) : null;
            let submenuDownIconJSX: JSX.Element | null = menuItem.items ? (<i className="pi pi-fw pi-angle-down menuitem-toggle-icon"></i>) : null;

            return (
                <li className={styleClass} key={index}>
                    {Util.isArrayHasElements(menuItem.items) && this.props.isRoot === true && <div className='arrow'></div>}
                    <a href={menuItem.url} onClick={(e) => this.onMenuItemClick(e, menuItem, index)} target={menuItem.target}>
                        <i className={menuItem.icon}></i>
                        <span>{menuItem.label}</span>
                        {submenuDownIconJSX}
                        {badgeJSX}
                    </a>
                    <AppSubMenuComponent menuItems={menuItem.items} onMenuItemClick={this.props.onMenuItemClick} />
                </li>
            );
        }) : null;

        return items ? <ul className={this.props.className}>{items}</ul> : null;
    }
}