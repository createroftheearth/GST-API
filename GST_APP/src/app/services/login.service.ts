import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LOCAL_STORAGE_KEYS } from '../constants';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  baseUrl = environment.appRoot + '/auth';

  constructor(private httpService: HttpClient) {}

  login(loginData: { username: string; password: string; isASPUser: boolean }) {
    loginData.isASPUser = true;
    return this.httpService.post(`${this.baseUrl}`, loginData);
  }

  generateGSTNToken(otp: string) {
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
    return this.httpService.post(`${this.baseUrl}/${otp}/request-token`, {});
  }
}