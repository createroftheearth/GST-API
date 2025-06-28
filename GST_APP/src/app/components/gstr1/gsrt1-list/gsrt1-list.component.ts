import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ItmDetail } from 'src/app/models/b2bInvoice.model';
import { Gstr1FileRequest } from 'src/app/models/gstr1FileRequest.model';

@Component({
  selector: 'app-gsrt1-list',
  templateUrl: './gsrt1-list.component.html',
  styleUrls: ['./gsrt1-list.component.css'],
})
export class Gsrt1ListComponent implements OnInit {

  //TO-DO: Add OTP for 5 digits only which supports alphanumeric characters, 
  ddlOptions = ['ALL', 'B2B', 'HSN', 'DOC Issue'];
  displayedColumns: string[] = ['Document Number', 'From Invoice', 'To Invoice', 'Net Issue', 'Total Issued'];
  selectedOptions = 'ALL';
  EVCForm: FormGroup;
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
  public gstr1Data: any[] = [];
  b2bList: any[] = [];
  b2baList: any[] = [];
  b2clList: any[] = [];
  b2claList: any[] = [];
  expList: any[] = [];
  expaList: any[] = [];
  b2b: any[] = [];
  hsnData: any[] = [];
  b2baData: any[] = [];
  b2csList: any[] = [];
  docIssueData: any[] = [];
  items: ItmDetail[] = [];

  totalRecords = 0;
  page = 1;
  pageSize = 10;
  @ViewChild('popupTemplateGS') popupTemplateGS!: TemplateRef<any>;
  @ViewChild('popupTemplateEVC') popupTemplateEVC!: TemplateRef<any>;
  @ViewChild('popupTemplateB2BItem') popupTemplateB2BItem!: TemplateRef<any>;
  @ViewChild('popupTemplatePAN') popupTemplatePAN!: TemplateRef<any>;


  otp: string = '';
  isValidOTP = false;
  otpSent = false;
  isSubmit = false;
  invalidOtpMessage = '';
  b2bTotalAmt = 0;
  constructor(
    private gstr1Service: GSTR1Service,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private fb: FormBuilder
  ) {
    this.EVCForm = this.fb.group({
      PAN: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
        ]),
      ],
    });
  }


  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.gstr1Service
      .getAllGSTR1(this.page, this.pageSize)
      .subscribe((response) => {
        this.gstr1Data = this.transformData(response.gstr1Data);
        const parsedData = JSON.parse(this.gstr1Data[0].gstr1SaveRequest);

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
        this.b2csList = parsedData.b2cs.flatMap((b2csItem: any) =>
          b2csItem.map((bcs: any) => {
            const taxTotals = bcs.reduce(
              (sum: { iamt: number; camt: number; samt: number }) => {
                return {
                  iamt: sum.iamt + (bcs.iamt || 0),
                  camt: sum.camt + (bcs.camt || 0),
                  samt: sum.samt + (bcs.samt || 0),
                };
              },
              { iamt: 0, camt: 0, samt: 0 }
            );

            return {
              inum: bcs.inum,
              idt: bcs.idt,
              val: bcs.val,
              pos: bcs.pos,
              inv_typ: bcs.inv_typ,
              totalAmount: taxTotals.iamt + taxTotals.camt + taxTotals.samt,//TODO:Needs to be update
            };
          })
        );
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
        );

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
      });
  }

  getTotalValue(): number {
    return this.b2bList?.reduce((acc, curr) => acc + (Number(curr.val) || 0), 0);
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

  onPageChange(pageNumber: number) {
    this.page = pageNumber;
    this.loadData();
  }

  onSaveGSTR1(id: number) {
    this.gstr1Service.submit(id).subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }

  onProceedToFile(id: number) {
    this.gstr1Service.proceedToFile(id).subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }


  onGenerateSummary(id: number) {
    this.gstr1Service.generateSummary(id).subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }

  openPopup() {
    // this.dialog.open(this.popupTemplate);
    this.dialog.open(this.popupTemplateGS, {
      width: '500px',
      height: '250px',
      panelClass: 'custom-dialog-container'
    });
  }


  closeDialog() {
    this.dialog.closeAll();
  }


  openPopupEVC(data: any, pan: string, gstnId: number) {
    this.dialog.open(this.popupTemplateEVC, {
      data: {
        data: data,
        pan: pan,
        gstnId: gstnId
      },
      width: '500px',
      height: '230px',
      panelClass: 'custom-dialog-container',
    });
  }

  openPopupPAN(id: number) {
    this.dialog.open(this.popupTemplatePAN, {
      data: {
        gstnId: id,
      },
      width: '500px',
      height: '230px',
      panelClass: 'custom-dialog-container',
    });
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


  public getErrorMessage(formControlName: string) {
    let formControl = this.getFormControl(formControlName);
    if (!formControl?.touched || !formControl.errors || !formControl.invalid) {
      return;
    }
    switch (formControlName) {
      case 'PAN': {
        if (formControl.errors['required']) {
          return 'Authorised PAN is mandatory.';
        }
        break;
      }
    }
  }

  private getFormControl(formControlName: string) {
    let formControl = this.EVCForm.get(formControlName);
    return formControl;
  }

  onSubmit(gstnId: number) {
    if (this.EVCForm.valid) {
      this.gstr1Service.generateOTP(this.EVCForm.value.PAN, gstnId).subscribe((data) => {
        let PANNo = this.EVCForm.value.PAN;
        if (data.isSuccess) {
          // const requestData: Gstr1FileRequest = {
          //   gstin: data.gstin,
          //   ret_period: data.ret_period,
          //   chksum: data.chksum,
          //   newSumFlag: true,
          //   sec_sum : data.sec_sum
          // };

          this.closePopup();
          this.openPopupEVC(data.data, PANNo, gstnId);
          //TO-DO: open a new popup for OTP and send data.data in otp dialog so you can use it when sending request to Visual Studio Server. 
        } else {
          PANNo = '';//TODO: PAN needs to be update
        }
        this.snackBar.open(data.message, 'Close', {
          duration: 5000,
        });
      });
    }
  }

  onOtpChange(otp: string, data: any, pan: string, gstnId: number): void {
    const alphanumericRegex = /^[a-zA-Z0-9]+$/;

    if (!alphanumericRegex.test(otp)) {
      this.invalidOtpMessage = "Only letters and numbers are allowed.";
      return;
    } else {
      this.invalidOtpMessage = '';
    }
    if (+otp && otp.length === 6) {
      this.gstr1Service.fileGSTR1(gstnId, data, otp, pan).subscribe((data) => {
        if (data.isSuccess) {
          this.closePopup();
        }
        this.snackBar.open(data.message, 'Close', {
          duration: 5000,
        });

      });
    } else {
      this.otp = '';
      this.isValidOTP = false;
    }
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
}




