import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ItmDetail } from 'src/app/models/b2bInvoice.model';
import { Gstr1FileRequest } from 'src/app/models/gstr1FileRequest.model';
import { Router } from '@angular/router';

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
  selector: 'app-gsrt1-list',
  templateUrl: './gsrt1-list.component.html',
  styleUrls: ['./gsrt1-list.component.css'],
})
export class Gsrt1ListComponent implements OnInit {

  //TO-DO: Add OTP for 5 digits only which supports alphanumeric characters, 
  ddlOptions = ['ALL', 'B2B', 'B2BA', 'HSN', 'B2CL', 'B2CLA', 'B2CS', 'EXP', 'EXPA', 'HSN', 'NIL', 'DOC Issue', 'CDNUR', 'CDNURA'];
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
    private fb: FormBuilder,
    private router: Router
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


  transformData(gstr1Data: any[]) {
    const transformedData = [];
    for (const data of gstr1Data) {
      const fpDatas = data.financialPeriod.split('-');
      data.financialPeriod = `${this.monthNames[+fpDatas[1] - 1]} ${fpDatas[0]
        }`;

      const parsedJSONData = JSON.parse(data.gstr1SaveRequest);
      data.grossTurnOver = parsedJSONData.gt;
      const isGetSummaryRes = data?.getSummaryResponse !== undefined && data.getSummaryResponse !== null ? true : false;
      data.getSummaryResponse = isGetSummaryRes;
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
      disableClose: true
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
      disableClose: true
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
    if (otp.length == 6) {
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

viewSummary(id: string): void {
  this.router.navigate(['/gstr1/viewSummary'], { queryParams: { id } });
}

openItemList(id: string): void {
  this.router.navigate(['/gstr1/viewItemList'], { queryParams: { id } });
}

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



