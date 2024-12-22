import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  baseUrl = environment.appRoot + '/registration';

  constructor(private httpService: HttpClient) {}

  checkUsernameExists(userName: string) {
    return this.httpService.get(
      `${this.baseUrl}/username-exists?username=${userName}`
    );
  }

  checkGSTNExists(gstn: string) {
    return this.httpService.get(`${this.baseUrl}/gstn-exists?GSTIN=${gstn}`);
  }

  checkGSTNUsernameExists(gstnUsername: string) {
    return this.httpService.get(
      `${this.baseUrl}/gstn-username-exists?gstnUsername=${gstnUsername}`
    );
  }

  register(data: any) {
    return this.httpService.post(`${this.baseUrl}`, data);
  }
}
