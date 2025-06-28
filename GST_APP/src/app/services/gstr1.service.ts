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
    return this.httpService.post<any>(this.baseUrl + '/save-gstr1', data);
  }

  getAllGSTR1(page: number, pageSize: number) {
    return this.httpService.get<any>(
      `${this.baseUrl}/get-all-gstr1?page=${page}&pageSize=${pageSize}`
    );
  }

  submit(id: number) {
    return this.httpService.post<any>(`${this.baseUrl}/submit`, { id: id });
  }

  proceedToFile(id: number) {
    return this.httpService.post<any>(`${this.baseUrl}/proceed-to-file`, {
      id: id,
    });
  }

  generateOTP(panNo: string,gstnId: number) {
    return this.httpService.post<any>(`${this.baseUrl}/generate-evc-otp`, {panNo : panNo,id:gstnId});
  }

  fileGSTR1(id: number, data: any, otp: string, panNo: string) {
    return this.httpService.post<any>(`${this.baseUrl}/file-gstr1`, {
      id: id,
      Data : { gstin: data.gstin, ret_period: data.ret_period, chksum: data.chksum, newSumFlag: data.newSumFlag, sec_sum: data.sec_sum},
      OTP: otp,
      PAN : panNo
    });
  }

    generateSummary(id: number) {
    return this.httpService.post<any>(`${this.baseUrl}/generate-summary`, {
      id: id,
    });
  }
}
