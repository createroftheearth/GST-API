import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  getErrorMessage(
    controlName: string,
    fieldName: string,
    invGroup: AbstractControl
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
    if (control.hasError('invalidDate'))
      return `${fieldName} has an invalid date`;

    return '';
  }
}
