import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LOCAL_STORAGE_KEYS } from '../constants';
import { EncryptDecryptService } from './encrypt-decrypt.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  baseUrl = environment.appRoot + '/auth';

  constructor(private httpService: HttpClient, private encryptDecryptService : EncryptDecryptService) {}

  login(loginData: { username: string; password: string; isASPUser: boolean }) {
    loginData.isASPUser = true;
    return this.httpService.post(`${this.baseUrl}`, loginData);
  }

  generateGSTNToken(otp: string) {
    const encryptedOTP = this.encryptDecryptService.encryptUsingAES256(otp);
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
    return this.httpService.post(`${this.baseUrl}/${encryptedOTP}/request-token`, {});
  }
}
