import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GSTR3BService {
  // baseUrl = environment.appRoot + '/gstr3b';
  baseUrl = environment.appRoot + '/GSTR3ASP';

  constructor(private httpService: HttpClient) { }

  getGSTR3BDetails(gstin: string, ret_period: string): Observable<any> {
    return this.httpService.get<any>(
      `${this.baseUrl}/get-gstr3b?gstin=${gstin}&ret_period=${ret_period}`
    );
  }
  
    saveGstr3(data: any) {
    return this.httpService.post<any>(this.baseUrl + '/save-gstr3', data);
  }

}
