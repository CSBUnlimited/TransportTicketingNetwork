import axios from 'axios';
import { BaseResponse } from '../models';

export default class ApiService {

    private readonly baseUrl = "http://localhost:5556/api/";

    constructor() {
        
    }

    _setTokenData(authToken) {
        localStorage.setItem('authToken', JSON.stringify(authToken));
    }

    public get authToken(): string {
        return localStorage.getItem('authToken')
    }

    get headers() {
        let headers = {
            'Content-Type': 'application/json'
        }

        let authToken = this.authToken;

        if (authToken) {
            headers['Authorization'] = `Bearer ${authToken}`;
        }

        return headers;
    }

    public get<Response = {}>(url): Promise<Response> {
        
        return new Promise<Response>((resolve, reject) => {
            
            axios.get(this.baseUrl + url, { headers: this.headers }).then(response => {
                resolve(response.data as any);
            }).catch(err => {
                let response: BaseResponse = JSON.parse(err.request.response) as BaseResponse;
                
                response.status = err.request.status;
                response.isSuccess = false;
                resolve(response as any);
            });
        });
    }

    public post<Response = {}, Request = {}>(url: string, request: Request): Promise<Response> {

        return new Promise<Response>((resolve, reject) => {

            axios.post(this.baseUrl + url, request, { headers: this.headers }).then(response => {
                resolve(response.data as any);
            }).catch(err => {
                let response: BaseResponse = JSON.parse(err.request.response) as BaseResponse;
                
                response.status = err.request.status;
                response.isSuccess = false;

                resolve(response as any);
            });
        });
    }

    put(url, request) {

        return new Promise((resolve, reject) => {

            axios.put(this.baseUrl + url, request, { headers: this.headers }).then(response => {
                resolve(response.data as any);
            }).catch(err => {
                let response: BaseResponse = JSON.parse(err.request.response) as BaseResponse;
                
                response.status = err.request.status;
                response.isSuccess = false;

                resolve(response as any);
            });
        });
    }
}