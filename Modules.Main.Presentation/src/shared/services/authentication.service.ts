import ApiService from './api.service';

export class AuthenticationService {
    
    private apiService: ApiService;
    
    constructor() {
        this.apiService = new ApiService();
        this.tokenData = this.apiService.tokenData;
    }

    public get isLoggedIn() {
        return (this.tokenData ? true : false);
    }

    



    public redirectIfNotLoggedIn() {
        if (!this.isLoggedIn) {
            window.location.href = '/';
        }

    }



    public logout() {
        localStorage.removeItem('tokenData');
        window.location.href = '/';
    }

}