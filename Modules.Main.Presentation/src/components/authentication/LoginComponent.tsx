import * as React from 'react'
import { AuthenticationService } from '../../shared/services/authentication.service';
import ApiService from '../../shared/services/api.service';
import { Util, NotifictionTypes } from '../../shared';

export default class LoginComponent extends React.Component<any, any> {

    private authSerive = new AuthenticationService();
    private apiSrvice = new ApiService();
    
    public state = {
        username: '',
        password: ''
    }

    // componentDidMount() {
    //     if (this.authSerive.isLoggedIn) {
    //         this.setState({
    //             isLoggedIn: true
    //         })

    //     }

    // }



    public onChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        });
    }



    onSubmit = async (e) => {
        e.preventDefault();
        const loginRequest = {
            loginViewModel: {
                username: this.state.username,
                password: window.btoa(this.state.password)
            }
        }

        let response: any = await this.apiSrvice.post('Authorization/LoginUserAsync', loginRequest);

        console.log(response);
        if (response.isSuccess) {
            this.authSerive.login(response.authenticationToken);
        }
        else {
            Util.pushNotificationMessages({
                title: response.message,
                message: response.messageDetails,
                severity: NotifictionTypes.Error
            })
        }
    }

    private signup = () => {
        window.location.href = '#/signup';
    }



    render() {
        return (

            <div className="container">
                <div className="row">
                    <div className="col-md-offset-2 col-md-8 m-auto">

                        <h1 className="display-4 text-center">Sign In</h1>

                        <p className="lead text-center">Login to Transport Ticketing Network</p>

                        <form onSubmit={this.onSubmit}>

                            <div className="form-group">

                                <input type="username" className="form-control form-control-lg"
                                    placeholder="Username" name="username"
                                    value={this.state.username}
                                    onChange={this.onChange} />

                            </div>

                            <div className="form-group">
                                <input type="password" className="form-control form-control-lg"
                                    placeholder="Password" name="password"
                                    value={this.state.password}
                                    onChange={this.onChange} />
                            </div>

                            <button type="submit" className="btn btn-primary btn-block" >Login</button>
                            <button type="button" className="btn btn-default btn-block" onClick={this.signup}>Sign Up</button>
                        </form>
                    </div>
                </div>
            </div>
        )

    }
}
