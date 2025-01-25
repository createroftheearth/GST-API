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
  selector: 'app-b2cl',
  templateUrl: './b2cl.component.html',
  styleUrls: ['./b2cl.component.css'],
})
export class B2clComponent {
  @Input() parentForm!: FormGroup;
  states = STATES;

  get b2clArray(): FormArray {
    return this.parentForm.get('b2cl') as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService
  ) {}

  ngOnInit(): void {
    // Ensure the b2cl form array is initialized
    if (!this.parentForm.get('b2cl')) {
      this.parentForm.addControl('b2cl', this.fb.array([]));
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

  addB2cl() {
    this.b2clArray.push(
      this.fb.group({
        pos: ['', [Validators.required]],
        inv: this.fb.array([]),
      })
    );
  }

  removeB2cl(index: number): void {
    this.b2clArray.removeAt(index);
  }

  getErrorMessage(
    controlName: string,
    fieldName: string,
    form: AbstractControl<any, any>
  ): string {
    return this.validationService.getErrorMessage(controlName, fieldName, form);
  }
}
