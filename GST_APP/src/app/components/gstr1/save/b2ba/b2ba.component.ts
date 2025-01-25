import { Component, Input, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';

import { ctinValidator } from '../../../../validators/ctin.validator';
import { ValidationService } from 'src/app/services/validation.service';
@Component({
  selector: 'app-b2ba',
  templateUrl: './b2ba.component.html',
  styleUrls: ['./b2ba.component.css'],
})
export class B2baComponent {
  @Input() parentForm!: FormGroup;

  get b2baArray(): FormArray {
    return this.parentForm.get('b2ba') as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    // Ensure the b2ba form array is initialized
    if (!this.parentForm.get('b2ba')) {
      this.parentForm.addControl('b2ba', this.fb.array([]));
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

  addB2b() {
    this.b2baArray.push(
      this.fb.group({
        ctin: ['', [Validators.required, ctinValidator()]],
        inv: this.fb.array([]),
      })
    );
  }

  removeB2b(index: number): void {
    this.b2baArray.removeAt(index);
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    form: AbstractControl<any, any>
  ): string {
    return this.validationService.getErrorMessage(controlName, fieldName, form);
  }
}
