import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { gstinValidator } from 'src/app/validators/gstin.validator';

@Component({
  selector: 'app-add-edit-gstr1',
  templateUrl: './add-edit-gstr1.component.html',
  styleUrls: ['./add-edit-gstr1.component.css'],
})
export class AddEditGstr1Component {
  gstr1Form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.gstr1Form = this.fb.group({
      gstin: ['', [Validators.required, gstinValidator()]],
      fp: ['', Validators.required],
      gt: ['', [Validators.required, Validators.min(0)]],
      cur_gt: ['', [Validators.required, Validators.min(0)]],
      b2b: this.fb.array([]),
      b2ba: this.fb.array([]),
      b2cl: this.fb.array([]),
      b2cla: this.fb.array([]),
    });
  }

  onSubmit(): void {
    if (this.gstr1Form.valid) {
      console.log(this.gstr1Form.value);
    }
  }

  getErrorMessage(controlName: string, fieldName: string): string {
    const control = this.gstr1Form.get(controlName);
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
