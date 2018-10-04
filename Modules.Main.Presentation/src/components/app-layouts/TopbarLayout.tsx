import * as React from 'react';
import { BasePropsVM, Util } from '../../shared';
import { NotifictionTypes } from '../../shared/models/notification';

interface TopbarLayoutPropsVM extends BasePropsVM {
    username: string;
    onToggleMenu: (event) => void;
}

export const TopbarLayout = (props: TopbarLayoutPropsVM) => {

    return (
        <div className="layout-topbar clearfix">
            <a className="layout-menu-button" onClick={ props.onToggleMenu }>
                <span className="pi pi-bars" />
            </a>
            <div className="layout-topbar-icons">
                <a>
                    <span className="layout-topbar-item-text">Recharge</span>
                    <span className="layout-topbar-icon fa fa-money" title="Recharge"/>
                    {/* <span className="layout-topbar-badge">5</span> */}
                </a>
                <a>
                    <span className="layout-topbar-item-text">Settings</span>
                    <span className="layout-topbar-icon pi pi-cog" title="Settings"/>
                </a>
                <a>
                    <span className="layout-topbar-item-text">User</span>
                    <span className="layout-topbar-icon pi pi-user" title={props.username}/>
                </a>
            </div>
        </div>
    );
}