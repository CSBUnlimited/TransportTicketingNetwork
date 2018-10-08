
import * as React from 'react'
import classNames from 'classnames';
import { BaseStateVM, BasePropsVM, UserVM } from '../../shared';
import { AuthenticationService } from '../../shared/services/authentication.service';

interface AppMenuProfileStateVM extends BaseStateVM {
    expanded?: boolean;
}

interface AppMenuProfilePropsVM extends BasePropsVM {
    user: UserVM;
}

export default class AppMenuProfileComponent extends React.Component<AppMenuProfilePropsVM, AppMenuProfileStateVM> {

    public state: AppMenuProfileStateVM = {
        expanded: false
    }

    private authService = new AuthenticationService();

    constructor(props: AppMenuProfilePropsVM) {
        super(props);
    }

    private onClick = (event) => {
        this.setState({expanded: !this.state.expanded});
        event.preventDefault();
    }

    private logout = (e) => {
        e.preventDefault();
        this.authService.logout();
    }

    render() {

        let srcPath = 'assets/layout/images/';

        if (this.props.user.gender == 'Female') {
            srcPath += 'avatar_3.png';
        }
        else {
            srcPath += 'avatar_4.png';
        }

        return  (
            <div className="profile">
                <div>
                    <img src={srcPath} alt="" />
                </div>
                <a className="profile-link" onClick={this.onClick}>
                    <span className="username">{this.props.user.firstName + ' ' + this.props.user.lastName}</span>
                    <i className="pi pi-fw pi-cog"/>
                </a>
                <ul className={classNames({'profile-expanded': this.state.expanded})}>
                    <li><a><i className="pi pi-fw pi-user"/><span>Account</span></a></li>
                    {/* <li><a><i className="pi pi-fw pi-inbox"/><span>Notifications</span><span className="menuitem-badge">2</span></a></li> */}
                    <li onClick={this.logout}><a><i className="pi pi-fw pi-power-off"/><span>Logout</span></a></li>
                </ul>
            </div>
        );
    }
}
