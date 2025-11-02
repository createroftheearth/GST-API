import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import Ajv from 'ajv';
import addErrors from 'ajv-errors';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { gstinValidator } from 'src/app/validators/gstin.validator';
import { GSTR1Service } from 'src/app/services/gstr1.service';
import { GSTR3BService } from 'src/app/services/gstr3b.service';

@Component({
  selector: 'app-gstr3b',
  templateUrl: './gstr3b.component.html',
  styleUrls: ['./gstr3b.component.css']
})
export class Gstr3bComponent {
  gstr3Form!: FormGroup;
  getGSTR3Data: any[] = [];
  jsonGSTR3Data : any[] = [];
  jsonData: any = null;
  jsonString: string = '';
  hideUploadButton = false;
  jsonValidationErrors: string[] = [];

  jsonSchema = {};
  totalRecords = 0;
  page = 1;
  pageSize = 10;

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
    private snackBar: MatSnackBar,
    private router: Router,
    private fb: FormBuilder,
    private gstr1Service: GSTR1Service,
    private gstr3bService: GSTR3BService
  ) { }

  async ngOnInit() {
    this.gstr3Form = this.fb.group({
      gstin: ['', [Validators.required, gstinValidator()]],
      ret_period: ['', Validators.required]
    });
   // await this.loadJsonSchema();
  }

  onSubmit(): void {
    if (this.gstr3Form.valid) {
      this.getGSTR3BList();
    }
  }
 

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

  async loadJsonSchema() {
    try {
      const response = await fetch('assets/saveGSTR1Schema.json'); // Ensure schema.json is in assets folder
      this.jsonSchema = await response.json();
    } catch (error) {
      console.error('Error loading JSON schema:', error);
    }
  }

  onFileSelected(event: any, fileType: string) {
    const file = event.target.files[0];
    if (file) {
      this.hideUploadButton = true;
      const reader = new FileReader();
      reader.onload = (e: any) => {
        if (fileType === 'json') {
          try {
            const jsonData = JSON.parse(e.target.result);
            this.jsonData = jsonData;
            this.jsonString = JSON.stringify(jsonData, null, 2);
            if (this.jsonSchema && !this.validateJson(jsonData)) {
              this.snackBar.open('JSON validation failed.', 'Close', {
                duration: 5000,
              });
              this.hideUploadButton = false;
              return;
            }
            this.snackBar.open(
              'JSON file uploaded and validated successfully!',
              'Close',
              { duration: 3000 }
            );
          } catch (error) {
            console.log(error);
            this.snackBar.open('Invalid JSON file', 'Close', {
              duration: 3000,
            });
            this.hideUploadButton = false;
          }
        } else if (fileType === 'excel') {
          this.snackBar.open(
            'Excel file upload is not implemented yet.',
            'Close',
            { duration: 3000 }
          );
        }
      };
      reader.readAsText(file);
    }
  }

  triggerFileInput(inputId: string) {
    const fileInput = document.getElementById(inputId) as HTMLInputElement;
    if (fileInput) {
      fileInput.click();
    }
  }

  validateJson(jsonData: any): boolean {
    const ajv = new Ajv({ allErrors: true, strictNumbers: false });
    addErrors(ajv);
    const validate = ajv.compile(this.jsonSchema);

    if (!validate(jsonData)) {
      this.jsonValidationErrors =
        validate.errors!.map(
          (err) => `Field: ${err.instancePath || 'root'} - ${err.message}`
        ) || [];
      return false;
    }
    return true;
  }

  displayedColumns: string[] = ['id', 'gstin', 'fp', 'action'];
  dataSource = []; // Replace with actual data

  //<--***************************************** -->
    getGSTR3BList() {
    this.gstr3bService.getGSTR3BDetails(this.gstr3Form.value.gstin, this.gstr3Form.value.ret_period).subscribe({
      next: (response) => {
        if(response?.data != null){
          this.jsonGSTR3Data = response?.data;
        }
        let data: any = {
        gstin: response.data.gstin,
        fp: response.data.ret_period
      };
     this.getGSTR3Data = [data]
      },
      error: (err) => {
        console.error('API Error:', err);
      }
    });
  }

    onPageChange(pageNumber: number) {
    this.page = pageNumber;
  //   this.getGSTR3BList();
  }

    SaveGSTR3BResponse() {
    //      const gstin = this.jsonData.gstin;
   // const month = this.jsonData.fp.slice(0, 2);
  //  const year = this.jsonData.fp.slice(2, 6);
  //  const financialPeriod = `${year}-${month}-01`;

    const gstin = this.gstr3Form.value.gstin != "" ?  this.gstr3Form.value.gstin : this.jsonData.gstin;
    const month = this.gstr3Form.value.ret_period != "" && this.gstr3Form.value.ret_period != null ? this.gstr3Form.value.ret_period.slice(0, 2) : this.jsonData.fp.slice(0, 2);
    const year = this.gstr3Form.value.ret_period != "" &&  this.gstr3Form.value.ret_period != null ?this.gstr3Form.value.ret_period.slice(2, 6) : this.jsonData.fp.slice(2, 6);
    const financialPeriod = `${year}-${month}-01`;

    const model = {
      GetGstr3Response: JSON.stringify(this.jsonGSTR3Data.length > 0 ? this.jsonGSTR3Data : this.jsonData),
      financialPeriod: financialPeriod,
      gstinNo: gstin,
    };

    this.gstr3bService.saveGstr3(model).subscribe((data) => {
      if (data.isSuccess) {
          this.getGSTR3BList();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }
}
