import { Component, Input, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { STATES } from 'src/app/constants';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-b2cla',
  templateUrl: './b2cla.component.html',
  styleUrls: ['./b2cla.component.css'],
})
export class B2claComponent {
  @Input() parentForm!: FormGroup;
  states = STATES;

  get b2claArray(): FormArray {
    return this.parentForm.get('b2cla') as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    // Ensure the b2cla form array is initialized
    if (!this.parentForm.get('b2cla')) {
      this.parentForm.addControl('b2cla', this.fb.array([]));
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

  addB2cla() {
    this.b2claArray.push(
      this.fb.group({
        pos: ['', [Validators.required]],
        inv: this.fb.array([]),
      })
    );
  }

  removeB2cla(index: number): void {
    this.b2claArray.removeAt(index);
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    form: AbstractControl<any, any>
  ): string {
    return this.validationService.getErrorMessage(controlName, fieldName, form);
  }
}
