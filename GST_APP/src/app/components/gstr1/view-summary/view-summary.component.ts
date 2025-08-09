import { Component } from '@angular/core';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { ItmDetail } from 'src/app/models/b2bInvoice.model';
import { ActivatedRoute } from '@angular/router';
type SectionTotals = {
  sec_nm: string;
  ttl_rec: number;
  ttl_val: number;
  ttl_tax: number;
  ttl_igst: number;
  ttl_cgst: number;
  ttl_sgst: number;
  ttl_cess: number;
};
@Component({
  selector: 'app-view-summary',
  templateUrl: './view-summary.component.html',
  styleUrls: ['./view-summary.component.css']
})
export class ViewSummaryComponent {
  public gstr1Data: any[] = [];
  b2bList: any[] = [];
  b2baList: any[] = [];
  b2clList: any[] = [];
  b2claList: any[] = [];
  expList: any[] = [];
  expaList: any[] = [];
  nilList: any[] = [];
  b2b: any[] = [];
  hsnData: any[] = [];
  b2baData: any[] = [];
  b2csList: any[] = [];
  docIssueData: any[] = [];
  cdnurList: any[] = [];
  cdnuraList: any[] = [];
  items: ItmDetail[] = [];
  sectionSummaries: any[] = [];
  sectionGroups: SectionTotals[] = [];
  totalRecords = 0;
  page = 1;
  pageSize = 10;
  b2bTotalAmt = 0;
  summaryId = 0;
  monthNames = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  constructor(
    private route: ActivatedRoute,
    private gstr1Service: GSTR1Service) {
    this.route.queryParams.subscribe(params => {
      this.summaryId = params['id'];
    });
  }

  ngOnInit(): void {
    this.loadData();
  }

  transformData(gstr1Data: any[]) {
    const transformedData = [];
    for (const data of gstr1Data) {
      const fpDatas = data.financialPeriod.split('-');
      data.financialPeriod = `${this.monthNames[+fpDatas[1] - 1]} ${fpDatas[0]
        }`;

      const parsedJSONData = JSON.parse(data.gstr1SaveRequest);
      data.grossTurnOver = parsedJSONData.gt;
      transformedData.push(data);
    }
    return transformedData;
  }

  loadData() {
    this.gstr1Service
      .getAllGSTR1(this.page, this.pageSize)
      .subscribe((response) => {
        // this.gstr1Data = this.transformData(response.gstr1Data);
        this.gstr1Data = response.gstr1Data;
        const selectedItem = this.gstr1Data.find(item => item.id === +this.summaryId);
        const parsedData = JSON.parse(selectedItem.gstr1SaveRequest);

        //GetSummary
        const getSummaryData = JSON.parse(this.gstr1Data[0].getSummaryResponse);
        debugger;
        this.sectionSummaries = getSummaryData.sec_sum || [];
        // Helper function to normalize section names
        const normalizeSection = (sec_nm: string): string => {
          const keys = Object.keys(sectionGroupsMap);
          const match = keys.find(prefix => sec_nm === prefix || sec_nm.startsWith(prefix));
          return match ? sectionGroupsMap[match] : sec_nm;
        };


        const grouped = new Map<string, SectionTotals>();

        this.sectionSummaries.forEach((sec: { sec_nm: string; ttl_rec: any; ttl_val: any; ttl_tax: any; ttl_igst: any; ttl_cgst: any; ttl_sgst: any; ttl_cess: any; }) => {
          const key = normalizeSection(sec.sec_nm);

          if (!grouped.has(key)) {
            grouped.set(key, {
              sec_nm: key,
              ttl_rec: 0,
              ttl_val: 0,
              ttl_tax: 0,
              ttl_igst: 0,
              ttl_cgst: 0,
              ttl_sgst: 0,
              ttl_cess: 0
            });
          }

          const current = grouped.get(key)!;
          current.ttl_rec += sec.ttl_rec || 0;
          current.ttl_val += sec.ttl_val || 0;
          current.ttl_tax += sec.ttl_tax || 0;
          current.ttl_igst += sec.ttl_igst || 0;
          current.ttl_cgst += sec.ttl_cgst || 0;
          current.ttl_sgst += sec.ttl_sgst || 0;
          current.ttl_cess += sec.ttl_cess || 0;
        });

        this.sectionGroups = Array.from(grouped.values());

        //


        // This is for B2B List
        this.b2bList = parsedData.b2b.flatMap((b2bItem: { inv: any[] }) =>
          b2bItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; camt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.camt + (det.camt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              pos: inv.pos,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,
            };
          })
        );
        this.b2bTotalAmt = this.getTotalValue();
        // 

        // This is for B2BA List
        this.b2baList = parsedData.b2ba.flatMap((b2baItem: { inv: any[] }) =>
          b2baItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; camt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.camt + (det.camt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              pos: inv.pos,
              inv_typ: inv.inv_typ,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,
            };
          })
        );
        //

        // This is for B2CL List
        this.b2clList = parsedData.b2ba.flatMap((b2clItem: { inv: any[] }) =>
          b2clItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; camt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.camt + (det.camt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              pos: inv.pos,
              inv_typ: inv.inv_typ,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,//TODO:Needs to be update
            };
          })
        );
        //

        // This is for B2CL List
        this.b2claList = parsedData.b2ba.flatMap((b2claItem: { inv: any[] }) =>
          b2claItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; camt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.camt + (det.camt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              pos: inv.pos,
              inv_typ: inv.inv_typ,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,//TODO:Needs to be update
            };
          })
        );
        //

        // This is for B2CS List
        this.b2csList = response.b2cs.map((item: { txval: any; iamt: any; csamt: any; }) => ({
          ...item,
          totalAmount: (item.txval || 0) + (item.iamt || 0) + (item.csamt || 0)
        }));

        //

        // This is for EXP List
        this.expList = parsedData.b2ba.flatMap((expItem: { inv: any[] }) =>
          expItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; csamt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.csamt + (det.csamt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              sbnum: inv.sbnum,
              sbdt: inv.sbdt,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,//TODO:Needs to be update
            };
          })
        );
        //

        // This is for EXPA List
        this.expaList = parsedData.b2ba.flatMap((expaItem: { inv: any[] }) =>
          expaItem.inv.map(inv => {
            const taxTotals = inv.itms.reduce(
              (sum: { iamt: number; csamt: number; samt: number }, itm: any) => {
                const det = itm.itm_det;
                return {
                  iamt: sum.iamt + (det.iamt || 0),
                  camt: sum.csamt + (det.csamt || 0),
                  samt: sum.samt + (det.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              itms: inv.itms,
              inum: inv.inum,
              idt: inv.idt,
              val: inv.val,
              sbnum: inv.sbnum,
              sbdt: inv.sbdt,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,//TODO:Needs to be update
            };
          })
        ) || [];
        //

        // This is for NIL
        this.nilList = parsedData.nil.flatMap((nilItem: { inv: any[] }) =>
          nilItem.inv.map(inv => {
            return {
              sply_ty: inv.sply_ty,
              nil_amt: inv.nil_amt,
              ngsup_amt: inv.ngsup_amt,
              expt_amt: inv.expt_amt
            };
          })
        ) || [];
        //

        this.hsnData = parsedData.hsn.hsn_b2b;
        //   this.b2baData = parsedData.b2ba.inv;

        // Extract required fields
        this.docIssueData = parsedData.doc_issue.doc_det.flatMap((doc: { docs: any[]; doc_num: any; }) =>
          doc.docs.map(d => ({
            doc_num: doc.doc_num,
            from: d.from,
            to: d.to,
            net_issue: d.net_issue,
            totnum: d.totnum
          }))
        );

        this.totalRecords = response.totalRecords;
        //
        // This is for CDNUR List
        this.cdnurList = parsedData.cdnur.map((cdnurItem: { itms: any[]; typ: any; ntty: any; nt_num: any; nt_dt: any; pos: any; val: any; diff_percent: any; }) => {
          const taxTotals = cdnurItem.itms.reduce(
            (sum: { iamt: number; csamt: number }, itm: any) => {
              const det = itm.itm_det;
              return {
                iamt: sum.iamt + (det.iamt || 0),
                csamt: sum.csamt + (det.csamt || 0)
              };
            },
            { iamt: 0, csamt: 0 }
          );

          return {
            typ: cdnurItem.typ,
            ntty: cdnurItem.ntty,
            nt_num: cdnurItem.nt_num,
            nt_dt: cdnurItem.nt_dt,
            pos: cdnurItem.pos,
            val: cdnurItem.val,
            diff_percent: cdnurItem.diff_percent,
            iamt: taxTotals.iamt,
            csamt: taxTotals.csamt,
            totalAmount: taxTotals.iamt + taxTotals.csamt
          };
        });

        this.b2bTotalAmt = this.getTotalValue();
        // 

        // This is for CDNURA List
        this.cdnuraList = parsedData.cdnura.map((cdnurItem: { itms: any[]; ont_num: any; ont_dt: any; typ: any; ntty: any; nt_num: any; nt_dt: any; pos: any; val: any; diff_percent: any; }) => {
          const taxTotals = cdnurItem.itms.reduce(
            (sum: { iamt: number; csamt: number }, itm: any) => {
              const det = itm.itm_det;
              return {
                iamt: sum.iamt + (det.iamt || 0),
                csamt: sum.csamt + (det.csamt || 0)
              };
            },
            { iamt: 0, csamt: 0 }
          );

          return {
            ont_num: cdnurItem.ont_num,
            ont_dt: cdnurItem.ont_dt,
            typ: cdnurItem.typ,
            ntty: cdnurItem.ntty,
            nt_num: cdnurItem.nt_num,
            nt_dt: cdnurItem.nt_dt,
            pos: cdnurItem.pos,
            val: cdnurItem.val,
            diff_percent: cdnurItem.diff_percent,
            iamt: taxTotals.iamt,
            csamt: taxTotals.csamt,
            totalAmount: taxTotals.iamt + taxTotals.csamt
          };
        });

        this.b2bTotalAmt = this.getTotalValue();
        // 

      });
  }

  getTotalValue(): number {
    return this.b2bList?.reduce((acc, curr) => acc + (Number(curr.val) || 0), 0);
  }

  sectionTitleMap: Record<string, string> = {
    AT: 'Advance Tax',
    ATA: 'Amended Advance Tax',
    B2B: '4A, 4B, 4C, 6B, 6C, SEZWOP, SEZWP - B2B Invoices',
    B2BA: '4A, 4B, 6C, SEZWOP, SEZWP - B2BA Invoices',
    B2CL: 'B2C (Large) Invoices',
    B2CLA: 'B2CLA',
    B2CS: 'B2CS',
    B2CSA: 'B2CSA',
    ECOM: 'ECOM, ECOM_DE, ECOM_REG, ECOM_SEZWOP, ECOM_SEZWP, ECOM_UNREG',
    ECOMA: 'ECOMA, ECOMA_DE, ECOMA_REG, ECOMA_SEZWOP, ECOMA_SEZWP, ECOMA_UNREG',
    HSN: 'HSN-wise summary of outward supplies',
    NIL: 'Nil rated, exempted and non GST outward supplies',
    TTL_LIAB: 'Tax Liability (Advance Received)',
    TXPD: 'TXPD, TXPDA',
    DOC_ISSUE: 'Documents Issued',
    CDNR: 'CDNR, CDNRA',
    CDNUR: 'CDNUR',
    CDNURA: 'CDNURA',
    EXP: 'EXP',
    EXPA: 'EXPA',
    SUPECOM: 'SUPECOM',
    // Add more mappings as needed
  };
}
const sectionGroupsMap: Record<string, string> = {
  B2BA: 'B2BA',
  B2B: 'B2B',
  B2CLA: 'B2CL',
  B2CL: 'B2CL',
  B2CSA: 'B2CSA',
  B2CS: 'B2CS',
  ATA: 'ATA',
  AT: 'AT',
  ECOMA: 'ECOMA',
  ECOM: 'ECOM',
  CDNURA: 'CDNURA',
  CDNUR: 'CDNUR',
  CDNR: 'CDNR',
  EXPA: 'EXPA',
  EXP: 'EXP',
  HSN: 'HSN',
  TXPD: 'TXPD'
  // Add more as needed
};


