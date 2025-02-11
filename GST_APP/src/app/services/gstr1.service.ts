import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GSTR1Service {
  baseUrl = environment.appRoot + '/GSTR1ASP';

  constructor(private httpService: HttpClient) {}

  saveGstr1(data: any) {
    return this.httpService.post(this.baseUrl + '/savegstr1', data);
  }
}
