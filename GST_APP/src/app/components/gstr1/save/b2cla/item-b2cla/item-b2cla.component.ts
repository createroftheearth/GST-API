import { Component, Input } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-item-b2cla',
  templateUrl: './item-b2cla.component.html',
  styleUrls: ['./item-b2cla.component.css'],
})
export class ItemB2claComponent {
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

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService
  ) {}

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
          csamt: [null, [Validators.min(0)]],
        }),
      })
    );
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    form: AbstractControl<any, any>
  ): string {
    return this.validationService.getErrorMessage(controlName, fieldName, form);
  }

  getItemDetailGroup(itemGroup: AbstractControl<any, any>): FormGroup {
    return itemGroup.get('itm_det') as FormGroup;
  }
}
