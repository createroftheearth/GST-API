import { Component, Input, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';

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

  constructor(private fb: FormBuilder) {}

  addInvoice() {
    const invoices = this.getFormArray(this.b2bGroup, 'inv');
    // Initialize the form group with all fields and validations
    invoices.push(
      this.fb.group({
        etin: ['', [Validators.pattern(/^[A-Z0-9]{15}$/)]], // Optional Ecom Tin
        flag: ['', [Validators.required]], // Taxpayer action
        inum: ['', [Validators.required, Validators.maxLength(16)]], // Invoice Number
        idt: ['', [Validators.required]], // Invoice Date
        val: [null, [Validators.required, Validators.min(0)]], // Invoice Value
        pos: ['', [Validators.required]], // Place of Supply
        diff_percent: [null, [Validators.min(0), Validators.max(100)]], // Differential Percentage
        rchrg: [false, Validators.required], // Reverse Charge
        inv_typ: [
          '',
          [
            Validators.required,
            Validators.pattern(/^(R|DE|SEWP|SEWOP|CBW)$/), // Enum: Regular, Deemed Export, etc.
          ],
        ],
        irngendate: ['', [this.dateValidator]], // Optional, valid date
        irn: ['', [Validators.maxLength(50)]], // Optional IRN, limited to 50 characters
        srctyp: ['', [Validators.maxLength(50)]], // Optional Source Type
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
    invGroup: AbstractControl<any, any>
  ): string {
    const control = invGroup.get(controlName);
    if (!control?.errors) return '';

    if (control.hasError('required')) return `${fieldName} is required`;
    if (control.hasError('min'))
      return `${fieldName} must be at least ${control.errors['min'].min}`;
    if (control.hasError('max'))
      return `${fieldName} must not exceed ${control.errors['max'].max}`;
    if (control.hasError('decimal'))
      return `${fieldName} must have up to 2 decimal places`;
    if (control.hasError('pattern')) return `${fieldName} is invalid`;
    if (control.hasError('invalidDate')) return `${fieldName} has invalid date`;

    return '';
  }
}
