import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PublicRegistrationService {
  baseUrl = environment.appRoot + '/registration';

  constructor(private httpService: HttpClient) {}

  checkUsernameExists(userName: string) {
    return this.httpService.get(
      `${this.baseUrl}/username-exists?username=${userName}`
    );
  }

  register(data: any) {
    return this.httpService.post(`${this.baseUrl}/public`, data);
  }
}
