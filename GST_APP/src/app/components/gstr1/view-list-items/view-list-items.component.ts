import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ItmDetail } from 'src/app/models/b2bInvoice.model';
import { Gstr1FileRequest } from 'src/app/models/gstr1FileRequest.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-list-items',
  templateUrl: './view-list-items.component.html',
  styleUrls: ['./view-list-items.component.css']
})
export class ViewListItemsComponent {
  public gstr1Data: any[] = [];
  b2bList: any[] = [];
  b2baList: any[] = [];
  b2clList: any[] = [];
  b2claList: any[] = [];
  expList: any[] = [];
  expaList: any[] = [];
  nilList: any[] = [];
  b2b: any[] = [];
  hsnb2bData: any[] = [];
  hsnb2cData: any[] = [];
  b2baData: any[] = [];
  b2csList: any[] = [];
  docIssueData: any[] = [];
  cdnurList: any[] = [];
  cdnuraList: any[] = [];
  items: ItmDetail[] = [];
  totalRecords = 0;
  page = 1;
  pageSize = 10;
  @ViewChild('popupTemplateGS') popupTemplateGS!: TemplateRef<any>;
  @ViewChild('popupTemplateB2BItem') popupTemplateB2BItem!: TemplateRef<any>;
  b2bTotalAmt = 0;
  cdnurTotalAmt = 0;
  cdnuraTotalAmt = 0;
  b2baTotalAmt = 0;
  b2clTotalAmt = 0;
  b2claTotalAmt = 0;
  b2csTotalAmt = 0;
  expaTotalAmt = 0;
  expTotalAmt = 0;
  hsnb2bTotalAmt = 0;
  txvalb2bTotalAmt = 0;
  iamtb2bTotalAmt = 0;
  camtb2bTotalAmt = 0;
  samtb2bTotalAmt = 0;
  hsnb2cTotalAmt = 0;
  txvalb2cTotalAmt = 0;
  iamtb2cTotalAmt = 0;
  camtb2cTotalAmt = 0;
  samtb2cTotalAmt = 0;
  itemId = 0;
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
  ddlOptions = ['ALL', 'B2B', 'B2BA', 'HSN', 'B2CL', 'B2CLA', 'B2CS', 'EXP', 'EXPA', 'HSN', 'NIL', 'DOC Issue', 'CDNUR', 'CDNURA'];
  displayedColumns: string[] = ['Document Number', 'From Invoice', 'To Invoice', 'Net Issue', 'Total Issued'];
  selectedOptions = 'ALL';
  constructor(
    private route: ActivatedRoute,
    private gstr1Service: GSTR1Service,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private router: Router) {
    this.route.queryParams.subscribe(params => {
      this.itemId = params['id'];
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
        const selectedItem = this.gstr1Data.find(item => item.id === +this.itemId);
        const parsedData = JSON.parse(selectedItem.gstr1SaveRequest);

        // This is for B2B List
        this.b2bList = parsedData?.b2b?.flatMap((b2bItem: { inv: any[] }) =>
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
        this.b2bTotalAmt = this.getTotalValue(this.b2bList);
        // 

        // This is for B2BA List
        this.b2baList = parsedData?.b2ba?.flatMap((b2baItem: { inv: any[] }) =>
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
        ) || [];
        this.b2baTotalAmt = this.getTotalValue(this.b2baList);
        //

        // This is for B2CL List
        this.b2clList = parsedData?.b2ba?.flatMap((b2clItem: { inv: any[] }) =>
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
        ) || [];
        this.b2clTotalAmt = this.getTotalValue(this.b2clList);
        //

        // This is for B2CL List
        this.b2claList = parsedData?.b2ba?.flatMap((b2claItem: { inv: any[] }) =>
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
        ) || [];
        this.b2claTotalAmt = this.getTotalValue(this.b2claList);
        //

        // This is for B2CS List
        this.b2csList = parsedData?.b2cs?.map((item: { txval: any; iamt: any; csamt: any; }) => ({
          ...item,
          totalAmount: (item.txval || 0) + (item.iamt || 0) + (item.csamt || 0)
        })) || [];
        this.b2csTotalAmt = this.getTotalValue(this.b2csList);
        //

        // This is for EXP List
        this.expList = parsedData?.b2ba?.flatMap((expItem: { inv: any[] }) =>
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
        ) || [];
        this.expTotalAmt = this.getTotalValue(this.expList);
        //

        // This is for EXPA List
        this.expaList = parsedData?.b2ba?.flatMap((expaItem: { inv: any[] }) =>
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
        this.expaTotalAmt = this.getTotalValue(this.expaList);
        //

        // This is for NIL
        console.log('parsedData.nil >>>', parsedData.nil);
         console.log('parsedData.nil >>>', parsedData);
        this.nilList = (parsedData?.nil?.inv || []).map((itm: { sply_ty: any; nil_amt: any; ngsup_amt: any; expt_amt: any; }) => ({
          sply_ty: itm.sply_ty,
          nil_amt: itm.nil_amt,
          ngsup_amt: itm.ngsup_amt,
          expt_amt: itm.expt_amt
        }));

        // This is for HSN B2B
        this.hsnb2bData = parsedData.hsn.hsn_b2b;
        this.hsnb2bTotalAmt = this.getTotalTrxValue(this.hsnb2bData);
        this.txvalb2bTotalAmt = this.hsnb2bData?.reduce((acc, curr) => acc + (Number(curr.txval) || 0), 0);
        this.iamtb2bTotalAmt = this.hsnb2bData?.reduce((acc, curr) => acc + (Number(curr.iamt) || 0), 0);
        this.camtb2bTotalAmt = this.hsnb2bData?.reduce((acc, curr) => acc + (Number(curr.camt) || 0), 0);
        this.samtb2bTotalAmt = this.hsnb2bData?.reduce((acc, curr) => acc + (Number(curr.samt) || 0), 0);
        //

        // This is for HSN B2C
        this.hsnb2cData = parsedData.hsn.hsn_b2c;
        this.hsnb2cTotalAmt = this.getTotalTrxValue(this.hsnb2cData);
        this.txvalb2cTotalAmt = this.hsnb2cData?.reduce((acc, curr) => acc + (Number(curr.txval) || 0), 0);
        this.iamtb2cTotalAmt = this.hsnb2cData?.reduce((acc, curr) => acc + (Number(curr.iamt) || 0), 0);
        this.camtb2cTotalAmt = this.hsnb2cData?.reduce((acc, curr) => acc + (Number(curr.camt) || 0), 0);
        this.samtb2cTotalAmt = this.hsnb2cData?.reduce((acc, curr) => acc + (Number(curr.samt) || 0), 0);
        //

        // Extract required fields
        this.docIssueData = parsedData?.doc_issue?.doc_det?.flatMap((doc: { docs: any[]; doc_num: any; }) =>
          doc.docs.map(d => ({
            doc_num: doc.doc_num,
            from: d.from,
            to: d.to,
            net_issue: d.net_issue,
            totnum: d.totnum
          }))
        ) || [];

        this.totalRecords = response.totalRecords;
        // This is for CDNUR List
        this.cdnurList = parsedData?.cdnur?.map((cdnurItem: { itms: any[]; typ: any; ntty: any; nt_num: any; nt_dt: any; pos: any; val: any; diff_percent: any; }) => {
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
        }) || [];
        this.cdnurTotalAmt = this.getTotalValue(this.cdnurList);
        // 

        // This is for CDNURA List
        this.cdnuraList = parsedData?.cdnura?.map((cdnurItem: { itms: any[]; ont_num: any; ont_dt: any; typ: any; ntty: any; nt_num: any; nt_dt: any; pos: any; val: any; diff_percent: any; }) => {
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
        }) || [];

        this.cdnuraTotalAmt = this.getTotalValue(this.cdnuraList);
        // 

      });
  }

  getTotalValue(itmList: any[]): number {
    return itmList?.reduce((acc, curr) => acc + (Number(curr?.val) || 0), 0);
  }

  getTotalTrxValue(itmList: any[]): number {
    return itmList?.reduce((acc, curr) => acc + (Number(curr.txval) || 0), 0);
  }

  selectedTable: string = 'ALL';
  showTable(event: any) {
    this.selectedOptions = event.value;
    console.log('Selected Option:', this.selectedOptions);
    this.selectedTable = event.value;
  }

  closePopup() {
    this.dialog.closeAll();
  }

  //   openPopupB2BItem() {
  //   this.dialog.open(this.popupTemplateB2BItem, {
  //     width: '500px',
  //     height: '230px',
  //     panelClass: 'custom-dialog-container'
  //   });
  // }
  public data: any[] = [];
  openPopupB2BItem(itms: ItmDetail[], event: Event) {
    this.data = itms;
    event.preventDefault();
    this.dialog.open(this.popupTemplateB2BItem, {
      width: '600px',

    });
  }


  closeDialog() {
    this.dialog.closeAll();
  }

}
