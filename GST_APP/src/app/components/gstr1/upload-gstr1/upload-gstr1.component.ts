import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import Ajv from 'ajv';
import addErrors from 'ajv-errors';
import { GSTR1Service } from 'src/app/services/gstr1.service';

@Component({
  selector: 'app-upload-gstr1',
  templateUrl: './upload-gstr1.component.html',
  styleUrls: ['./upload-gstr1.component.css'],
})
export class UploadGstr1Component implements OnInit {
  jsonData: any = null;
  jsonString: string = '';
  hideUploadButton = false;
  jsonValidationErrors: string[] = [];

  jsonSchema = {};

  constructor(
    private snackBar: MatSnackBar,
    private gstr1Service: GSTR1Service
  ) {}
  async ngOnInit() {
    await this.loadJsonSchema();
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

  saveData() {
    const gstin = this.jsonData.gstin;
    const month = this.jsonData.fp.slice(0, 2);
    const year = this.jsonData.fp.slice(2, 6);
    const financialPeriod = `${year}-${month}-01`;

    const model = {
      requestBody: JSON.stringify(this.jsonData),
      financialPeriod: financialPeriod,
      gstinNo: gstin,
    };
    this.gstr1Service.saveGstr1(model).subscribe(
      (data) => {
        this.snackBar.open(
          'Data Saved in DB, Please use submit button to save',
          'Close',
          { duration: 3000 }
        );
      },
      (err) => {
        this.snackBar.open('Error occured while trying to save', 'Close', {
          duration: 3000,
        });
      }
    );
  }
}
