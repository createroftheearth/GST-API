
export interface B2BInvoice {
  inum: string;
  idt: string;
  val: number;
  pos: string;
  itms: ItmDetail[];
}

export interface ItmDetail {
  num: number;
  itm_det: {
    txval: number;
    rt: number;
    camt: number;
    samt: number;
  };
}
