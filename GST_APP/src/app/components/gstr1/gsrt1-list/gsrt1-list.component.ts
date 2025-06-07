import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ItmDetail  } from 'src/app/models/b2bInvoice.model';

@Component({
  selector: 'app-gsrt1-list',
  templateUrl: './gsrt1-list.component.html',
  styleUrls: ['./gsrt1-list.component.css'],
})
export class Gsrt1ListComponent implements OnInit {
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
  b2bData: any[] = [];
  hsnData: any[] = [];
  b2baData: any[] = []; 
  docIssueData: any[] = [];
   items: ItmDetail[] = []; 

  totalRecords = 0;
  page = 1;
  pageSize = 10;
  @ViewChild('popupTemplateGS') popupTemplateGS!: TemplateRef<any>;
  @ViewChild('popupTemplateEVC') popupTemplateEVC!: TemplateRef<any>;
  @ViewChild('popupTemplateB2BItem') popupTemplateB2BItem!: TemplateRef<any>;
  
  otp: string = '';
  isValidOTP = false;
  otpSent = false;
  isSubmit = false;
  invalidOtpMessage = '';
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
        // this.b2bData = parsedData.b2b.flatMap((b2bItem: { inv: any[]; }) =>
        //   b2bItem.inv.map(inv => ({
        //     inum: inv.inum,
        //     idt: inv.idt,
        //     val: inv.val,
        //     pos: inv.pos
        //   }))
        // );

            this.b2bData = parsedData.b2b.flatMap((entry: { inv: any; }) => entry.inv);

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


  openPopupEVC(id: number) {
    this.dialog.open(this.popupTemplateEVC, {
      data:{
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
    openPopupB2BItem(itms: ItmDetail [], event: Event) {
        this.data =  itms; 
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
      this.gstr1Service.generateOTP(this.EVCForm.value.PAN,gstnId).subscribe((data) => {
        if (data.isSuccess) {
          this.isSubmit = true;
          this.otpSent = true;
          // this.loadData();
        }
        this.snackBar.open(data.message, 'Close', {
          duration: 5000,
        });
      });
    }
  }

  onOtpChange(value: string): void {
    alert('aaa');
    //   if (+value && value.length === 6) {
    //     this.otp = value;
    //     this.isValidOTP = true;
    //    // this.verifyOtp();
    //   } else {
    //     this.otp = '';
    //     this.isValidOTP = false;
    //   }
  }

  //   toggleTable() {
  //   this.showTable = this.selectedOption === 'Show Table';
  // }
selectedTable: string = 'ALL';
   showTable(event: any) {
    this.selectedOptions = event.value; // Capture selected value
    console.log('Selected Option:', this.selectedOptions);
     this.selectedTable =  event.value;
  }

  closePopup() {
    this.dialog.closeAll();
  }
}




