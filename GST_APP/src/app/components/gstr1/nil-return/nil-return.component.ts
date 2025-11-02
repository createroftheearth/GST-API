import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { gstinValidator } from 'src/app/validators/gstin.validator';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-nil-return',
  templateUrl: './nil-return.component.html',
  styleUrls: ['./nil-return.component.css']
})
export class NilReturnComponent {
  gstr3Form!: FormGroup;
  EVCForm: FormGroup;
  @ViewChild('popupTemplateEVC') popupTemplateEVC!: TemplateRef<any>;
  @ViewChild('popupTemplatePAN') popupTemplatePAN!: TemplateRef<any>;
  otp: string = '';
  isValidOTP = false;
  otpSent = false;
  isSubmit = false;
  invalidOtpMessage = '';

  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private fb: FormBuilder,
    private gstr1Service: GSTR1Service,
    private dialog: MatDialog
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

  async ngOnInit() {
    this.gstr3Form = this.fb.group({
      gstin: ['', [Validators.required, gstinValidator()]],
      ret_period: ['', Validators.required],
      isNil: [true]
    });
  }

  onSubmit(): void {
    if (this.gstr3Form.valid) {
      this.gstr1Service.proceedToFile(0, this.gstr3Form.value.gstin, this.gstr3Form.value.ret_period, "Y").subscribe((data) => {
        let PANNo = this.gstr3Form.value.PAN;
        if (data.isSuccess) {
          this.openPopupPAN(this.gstr3Form.value.gstin);
          //   this.openPopupEVC(PANNo, this.gstr3Form.value.gstin);
        }else if(data.message == "RET00003 :: Return Form already ready to be filed"){
          this.openPopupPAN(this.gstr3Form.value.gstin);
        } else {
          PANNo = '';
        }
        this.snackBar.open(data.message, 'Close', {
          duration: 5000,
        });
      });
    }
  }
  // onSubmit(): void {
  //   if (this.gstr3Form.valid) {
  //     this.gstr1Service.generateOTP(this.gstr3Form.value.PAN, this.gstr3Form.value.gstnId).subscribe((data) => {
  //       let PANNo = this.gstr3Form.value.PAN;
  //       if (data.isSuccess) {
  //         this.openPopupEVC(PANNo, this.gstr3Form.value.gstnId);
  //       } else {
  //         PANNo = '';
  //       }
  //       this.snackBar.open(data.message, 'Close', {
  //         duration: 5000,
  //       });
  //     });
  //   }
  // }

  getErrorMessage(controlName: string, fieldName: string): string {
    const control = this.gstr3Form.get(controlName);
    if (!control?.errors) return '';

    if (control.hasError('required')) return `${fieldName} is required`;
    if (control.hasError('min'))
      return `${fieldName} must be at least ${control.errors['min'].min}`;
    if (control.hasError('max'))
      return `${fieldName} must not exceed ${control.errors['max'].max}`;
    if (control.hasError('decimal'))
      return `${fieldName} must have up to 2 decimal places`;
    if (control.hasError('pattern')) return `${fieldName} is invalid`;

    return '';
  }

  onReset(): void {
    this.gstr3Form.reset({
      gstin: '',
      ret_period: '',
      PAN: '',
      isNil: true
    });
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
      this.gstr1Service.fileGSTR1(0,data, otp, pan).subscribe((data) => {
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

  closePopup() {
    this.dialog.closeAll();
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

  openPopupEVC(data: any, pan: string, gstnId: number) {
    this.dialog.open(this.popupTemplateEVC, {
      data: {
        pan: pan,
        gstnId: gstnId,
        data: data
      },
      width: '500px',
      height: '230px',
      panelClass: 'custom-dialog-container',
      disableClose: true
    });
  }

  closeDialog() {
    this.dialog.closeAll();
  }

  onSubmitPAN(gstnId: number) {
    if (this.EVCForm.valid) {
      this.gstr1Service.generateOTP(this.EVCForm.value.PAN, 0, this.gstr3Form.value.gstin, this.gstr3Form.value.ret_period).subscribe((data) => {
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
}
