export interface Gstr1FileRequest {
  gstin: string;
  ret_period: string;
  chksum: string;
  newSumFlag?: boolean;
  sec_sum: SecSum[];
}

export interface SecSum {
  sec_nm: string;
  chksum: string;
  ttl_rec?: number;
  ttl_tax?: number;
  ttl_igst?: number;
  ttl_sgst?: number;
  ttl_cgst?: number;
  ttl_val?: number;
  ttl_cess?: number;
  act_tax?: number;
  act_igst?: number;
  act_sgst?: number;
  act_cgst?: number;
  act_val?: number;
  act_cess?: number;
}