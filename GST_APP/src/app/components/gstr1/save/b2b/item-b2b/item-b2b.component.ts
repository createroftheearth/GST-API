import { Component, Input } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-item-b2b',
  templateUrl: './item-b2b.component.html',
  styleUrls: ['./item-b2b.component.css'],
})
export class ItemB2bComponent {
  @Input() invGroup!: AbstractControl<any, any>;

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
    return this.invGroup as FormGroup;
  }

  constructor(private fb: FormBuilder) {}

  removeItem(index: number, invoiceGroup: AbstractControl<any, any>) {
    const items = this.getFormArray(invoiceGroup, 'itms');
    items.removeAt(index);
  }

  addItem(invoiceGroup: AbstractControl<any, any>) {
    const items = this.getFormArray(invoiceGroup, 'itms');
    items.push(
      this.fb.group({
        num: [
          (items.length || 0) + 1,
          [Validators.required, Validators.min(1)],
        ],
        itm_det: this.fb.group({
          txval: [null, [Validators.required, Validators.min(0)]],
          rt: [
            null,
            [Validators.required, Validators.min(0), Validators.max(999.99)],
          ],
          iamt: [null, [Validators.min(0)]],
          camt: [null, [Validators.min(0)]],
          samt: [null, [Validators.min(0)]],
          csamt: [null, [Validators.min(0)]],
        }),
      })
    );
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    itmGroup: AbstractControl<any, any>
  ): string {
    const control = itmGroup.get(controlName);
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
}
