import * as React from 'react';
import './App.css';
import classNames from 'classnames';
import { TopbarLayout, FooterLayout } from './app-layouts';
import { BasePropsVM, BaseStateVM, GlobalEventConstants, NotificationMessageVM, NotifictionTypes, MenuItemVM } from '../shared';
import { Growl, GrowlMessage } from 'primereact/growl'
import { ScrollPanel } from 'primereact/components/scrollpanel/ScrollPanel';
import { AppMenuComponent } from './menu/AppMenuComponent';

interface AppComponentPropsVM extends BasePropsVM {

}

interface AppComponentStateVM extends BaseStateVM {
    isLoggedIn: boolean;
    username: string;
    staticMenuInactive: boolean;
    mobileMenuActive: boolean;
}

class AppComponent extends React.Component<AppComponentPropsVM, AppComponentStateVM> {

    private notifactionElementRef: Growl | null;
    private menuBarElementRef: HTMLDivElement | null;
    private layoutMenuScrollerElementRef: ScrollPanel | null;
    private isMenuClicked: boolean;

    public state: AppComponentStateVM = {
        isLoggedIn: true,
        username: "Anonymus",
        staticMenuInactive: false,
        mobileMenuActive: false
    };

    private get isDesktop(): boolean {
        return window.innerWidth > 1024;
    }

    public componentDidMount(): void {
        window.addEventListener(GlobalEventConstants.Notification, (event: CustomEvent) => { this.noficationHandler(event) });
    }

    /**
     * When nofication message pushed this will called
     * @param event CustomEvent
     */
    private noficationHandler = (event: CustomEvent): void => {

        let eventMessage: NotificationMessageVM = event.detail;

        let messageDeatils: GrowlMessage = {
            summary: eventMessage.title,
            detail: eventMessage.message,
            life: eventMessage.lifeTime,
            closable: true,
            sticky: eventMessage.isSticky,
            severity: eventMessage.severity.toString() as 'success' | 'info' | 'warn' | 'error'
        };

        if (this.notifactionElementRef) {
            this.notifactionElementRef.show(messageDeatils);
        }
    }

    /**
     * Trigger if click on the side bar
     * @param event Click Event
     */
    private onSidebarClick = (event): void => {
        this.isMenuClicked = true;
    }

    /**
     * Trigger if click on the wrapper
     * @param event Click Event
     */
    private onWrapperClick = (event) => {
        if (!this.isMenuClicked) {
            this.setState({
                mobileMenuActive: false
            });
        }

        this.isMenuClicked = false;
    }

    /**
     * Trigger if click on the hamburger button
     * @param event Click Event
     */
    private onToggleMenu = (event): void => {
        this.isMenuClicked = true;

        if (this.isDesktop) {
            this.setState({
                staticMenuInactive: !this.state.staticMenuInactive
            });
        }
        else {
            this.setState({
                mobileMenuActive: !this.state.mobileMenuActive
            });
        }

        event.preventDefault();
    }

    /**
     * Trigger if click on the side bar
     * @param menuItem Menu Item VM
     */
    private menuItemCommand = (menuItem: MenuItemVM): void => {
        if (menuItem.url) {
            window.location.href = '#/' + menuItem.url;
        }
    }

    public render() {

        let wrapperClass: string = classNames('layout-wrapper', {
            'layout-overlay': !this.state.isLoggedIn,
            'layout-static': this.state.isLoggedIn,
            'layout-static-sidebar-inactive': this.state.staticMenuInactive,
            // 'layout-overlay-sidebar-active': this.state.overlayMenuActive && this.state.layoutMode === 'overlay',
            'layout-mobile-sidebar-active': this.state.mobileMenuActive
        });

        let topBarJSX: JSX.Element | null = (
            this.state.isLoggedIn ? (<TopbarLayout onToggleMenu={this.onToggleMenu} username={this.state.username} />) : null
        );

        let menuBarJSX: JSX.Element | null = this.state.isLoggedIn ? (
            <div ref={(el) => this.menuBarElementRef = el} className="layout-sidebar layout-sidebar-dark" onClick={this.onSidebarClick}>

                <ScrollPanel ref={(el) => this.layoutMenuScrollerElementRef = el} style={{ height: '100%' }}>
                    <div className="layout-sidebar-scroll-content" >
                        <div className="layout-logo">
                            <img alt="Logo" src="favicon.ico" />
                        </div>
                        {/* <AppInlineProfile /> */}
                        <AppMenuComponent onMenuItemClick={this.menuItemCommand} />
                    </div>
                </ScrollPanel>
            </div>
        ) : null;

        return (
            <div className={wrapperClass} onClick={this.onWrapperClick}>

                {topBarJSX}

                {menuBarJSX}

                <Growl ref={(el) => { this.notifactionElementRef = el; }} style={{ marginTop: '75px' }} />

                <div className="layout-main min-height_App">

                </div>

                <FooterLayout />

                <div className="layout-mask"></div>
            </div>
        );
    }
}

export default AppComponent;
