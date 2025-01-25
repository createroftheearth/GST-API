// src/app/models/gstr1.model.ts
export interface GSTR1 {
  gstin: string;
  fp: string;
  gt: number;
  cur_gt: number;
  hash?: string;
  version?: string;
  b2b?: B2B[];
  b2ba?: B2BA[];
  b2cl?: B2CL[];
  // Add other properties as needed
}

export interface B2B {
  ctin: string;
  inv: Invoice[];
}

export interface B2BA {
  ctin: string;
  inv: Invoice[];
}

export interface B2CL {
  pos: string;
  inv: Invoice[];
}

export interface Invoice {
  etin?: string;
  flag: string;
  inum: string;
  idt: string;
  val: number;
  itms: Item[];
  pos: string;
  // Add other properties as needed
}

export interface Item {
  num: number;
  itm_det: ItemDetails;
}

export interface ItemDetails {
  txval: number;
  rt: number;
  iamt: number;
  camt: number;
  samt: number;
  csamt: number;
}
