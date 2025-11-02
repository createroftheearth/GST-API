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

  proceedToFile(id: number, gstnId: string | null, ret_period: string | null, isNil: string | null) {
    return this.httpService.post<any>(`${this.baseUrl}/proceed-to-file`, {
      id: id,
      gstin : gstnId,
      ret_period : ret_period,
      isnil : isNil
    });
  }

  generateOTP(panNo: string,id: number, gstnId: string | null, rp: string | null) {
    return this.httpService.post<any>(`${this.baseUrl}/generate-evc-otp`, {
      panNo : panNo,
      id: id,
      ret_period : rp,
      isnil : '',
      gstin: gstnId
    });
  }



  fileGSTR1(id: number, data: any, otp: string, panNo: string) {
    const payload = data != null ? { gstin: data.gstin, ret_period: data.ret_period, chksum: data.chksum, newSumFlag: data.newSumFlag, sec_sum: data.sec_sum} : {gstin: id, ret_period: '', chksum: '', newSumFlag: false, sec_sum: null, isnil: 'Y'};
    const cleanedPayload = removeNulls(payload);
    return this.httpService.post<any>(`${this.baseUrl}/file-gstr1`, {
    Data :payload,
      OTP: otp,
      PAN : panNo,
      id : id
    });
  }

    nilFileGSTR1(id: number, data: any, otp: string, panNo: string) {
    return this.httpService.post<any>(`${this.baseUrl}/nil-file-gstr1`, {
      Data : {isnil: 'Y', gstin: data.gstin, ret_period: data.ret_period, chksum: null, newSumFlag: null, sec_sum: null}, 
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
  function removeNulls(obj: any): any {
  return Object.fromEntries(
    Object.entries(obj)
      .filter(([_, v]) => v !== null && v !== undefined)
      .map(([k, v]) => [k, typeof v === 'object' && !Array.isArray(v) ? removeNulls(v) : v])
  );
}