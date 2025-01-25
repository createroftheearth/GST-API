import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function gstinValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null; // Don't validate if the control is empty
    }

    const patterns = [
      /^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$/,
    ];

    const isValid = patterns.some((pattern) => pattern.test(value));
    return isValid ? null : { invalidCtin: true };
  };
}
