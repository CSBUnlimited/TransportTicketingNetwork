import ApiService from './api.service';
import { UserVM } from '../models';

export class AuthenticationService {

    private apiService: ApiService;

    constructor() {
        this.apiService = new ApiService();
    }

    public static get loggedInUser(): UserVM | null {
        let token: string = localStorage.getItem('authToken');

        if (!token) {
            return null;
        }

        let base64Url = token.split('.')[1];
        let base64 = base64Url.replace('-', '+').replace('_', '/');

        let tokenData = JSON.parse(window.atob(base64));

        let user: UserVM = {
            username: tokenData['unique_name'],
            firstName: tokenData['firstName'],
            lastName: tokenData['lastName'],
            gender: tokenData['gender']
        }

        return user;
    }

    public static get isLoggedIn(): boolean {
        let token: string = localStorage.getItem('authToken');
        return (token ? true : false);
    }

    public redirectIfNotLoggedIn() {
        if (!AuthenticationService.isLoggedIn) {
            window.location.href = '/';
        }
    }

    public logout() {
        this.apiService.get('Authorization/LogoutUserAsync');
        localStorage.removeItem('authToken');
        window.location.href = '/';
    }

    public login(token: string) {
        localStorage.setItem('authToken', token);
        window.location.href = '/';
    }
}