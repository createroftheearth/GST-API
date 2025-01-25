import { Component, Input, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-invoice-b2b',
  templateUrl: './invoice-b2b.component.html',
  styleUrls: ['./invoice-b2b.component.css'],
})
export class InvoiceB2bComponent {
  @Input() b2bGroup!: AbstractControl<any, any>;

  getFormArray(
    group: AbstractControl<any, any>,
    controlName: string
  ): FormArray {
    // if (!group?.get(controlName)) {
    //   group.patchValue({ controlName: this.fb.array([]) });
    // }
    return group.get(controlName) as FormArray;
  }

  get formGroup() {
    return this.b2bGroup as FormGroup;
  }

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService
  ) {}

  addInvoice() {
    const invoices = this.getFormArray(this.b2bGroup, 'inv');
    // Initialize the form group with all fields and validations
    invoices.push(
      this.fb.group({
        etin: ['', [Validators.pattern(/^[A-Z0-9]{15}$/)]], // Optional Ecom Tin
        flag: ['', [Validators.required]], // Taxpayer action
        inum: [
          '',
          [
            Validators.required,
            Validators.maxLength(16),
            Validators.pattern(
              /^(?=.{1,16}$)([/\\\-0]*[a-zA-Z0-9/\\\-]*[a-zA-Z1-9]+[a-zA-Z0-9/\\\-]*)$/
            ),
          ],
        ], // Invoice Number
        idt: ['', [Validators.required]], // Invoice Date
        val: [null, [Validators.min(0), Validators.max(9999999999999.99)]], // Invoice Value
        pos: ['', [Validators.pattern(/^(3[0-8]|[12][0-9]|0[1-9]|96|97)$/)]], // Place of Supply
        diff_percent: [null, [Validators.min(0), Validators.max(100)]], // Differential Percentage
        rchrg: [false], // Reverse Charge
        inv_typ: [''],
        irngendate: ['', [this.dateValidator]], // Optional, valid date
        irn: ['', [Validators.minLength(1)]], // Optional IRN, limited to 50 characters
        srctyp: ['', [Validators.minLength(1)]], // Optional Source Type
        itms: this.fb.array([]), // Invoice Items
      })
    );
  }

  ngOnInit(): void {
    // Any additional initialization logic can go here
  }

  // Custom date validator
  dateValidator(control: any): { [key: string]: boolean } | null {
    if (control.value && isNaN(Date.parse(control.value))) {
      return { invalidDate: true };
    }
    return null;
  }

  removeInvoice(index: number, b2bGroup: AbstractControl<any, any>) {
    const invoices = this.getFormArray(b2bGroup, 'inv');
    invoices.removeAt(index);
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    form: AbstractControl<any, any>
  ): string {
    return this.validationService.getErrorMessage(controlName, fieldName, form);
  }
}
