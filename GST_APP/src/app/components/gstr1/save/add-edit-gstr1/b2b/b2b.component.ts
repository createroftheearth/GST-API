import { Component, Input, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';

import { ctinValidator } from '../../../../../validators/ctin.validator';

@Component({
  selector: 'app-b2b',
  templateUrl: './b2b.component.html',
  styleUrls: ['./b2b.component.css'],
})
export class B2bComponent implements OnInit {
  @Input() parentForm!: FormGroup;

  get b2bArray(): FormArray {
    return this.parentForm.get('b2b') as FormArray;
  }

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    // Ensure the b2b form array is initialized
    if (!this.parentForm.get('b2b')) {
      this.parentForm.addControl('b2b', this.fb.array([]));
    }
  }

  // Helper to safely retrieve FormArray
  getFormArray(
    group: AbstractControl<any, any>,
    controlName: string
  ): FormArray {
    // if (!group?.get(controlName)) {
    //   group.patchValue({ controlName: this.fb.array([]) });
    // }
    return group.get(controlName) as FormArray;
  }

  addB2b(): void {
    this.b2bArray.push(
      this.fb.group({
        ctin: ['', [Validators.required, ctinValidator()]],
        inv: this.fb.array([]),
      })
    );
  }

  addInvoice(b2bGroup: AbstractControl<any, any>): void {
    const invoices = this.getFormArray(b2bGroup, 'inv');
    invoices.push(
      this.fb.group({
        inum: ['', []],
        idt: ['', []],
        val: [0, []],
        pos: ['', []],
        rchrg: [false, []],
        itms: this.fb.array([]),
      })
    );
  }

  addItem(invoiceGroup: AbstractControl<any, any>): void {
    const items = this.getFormArray(invoiceGroup, 'itms');
    items.push(
      this.fb.group({
        num: [0, []],
        itm_det: this.fb.group({
          txval: [0, []],
          rt: [0, []],
        }),
      })
    );
  }

  removeB2b(index: number): void {
    this.b2bArray.removeAt(index);
  }

  removeInvoice(index: number, b2bGroup: AbstractControl<any, any>) {
    const invoices = this.getFormArray(b2bGroup, 'inv');
    invoices.removeAt(index);
  }

  removeItem(index: number, invoiceGroup: AbstractControl<any, any>) {
    const items = this.getFormArray(invoiceGroup, 'itms');
    items.removeAt(index);
  }
}
