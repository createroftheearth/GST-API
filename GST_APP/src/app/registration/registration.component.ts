import { Component, ElementRef, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from './registration.service';
import { map } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent {
  profilePictureSrc = '';
  cancelledChequePictureSrc = '';
  cancelledChequePictureName = '';
  pictureSelector = false;
  states = [
    { Text: 'Arunachal Pradesh', Value: 'AR' },
    { Text: 'Assam', Value: 'AS' },
    { Text: 'Bihar', Value: 'BR' },
    { Text: 'Chhattisgarh', Value: 'CG' },
    { Text: 'Goa', Value: 'GA' },
    { Text: 'Gujarat', Value: 'GJ' },
    { Text: 'Haryana', Value: 'HR' },
    { Text: 'Himachal Pradesh', Value: 'HP' },
    { Text: 'Jammu and Kashmir', Value: 'JK' },
    { Text: 'Jharkhand', Value: 'JH' },
    { Text: 'Karnataka', Value: 'KA' },
    { Text: 'Kerala', Value: 'KL' },
    { Text: 'Madhya Pradesh', Value: 'MP' },
    { Text: 'Maharashtra', Value: 'MH' },
    { Text: 'Manipur', Value: 'MN' },
    { Text: 'Meghalaya', Value: 'ML' },
    { Text: 'Mizoram', Value: 'MZ' },
    { Text: 'Nagaland', Value: 'NL' },
    { Text: 'Orissa', Value: 'OR' },
    { Text: 'Punjab', Value: 'PB' },
    { Text: 'Rajasthan', Value: 'RJ' },
    { Text: 'Sikkim', Value: 'SK' },
    { Text: 'Tamil Nadu', Value: 'TN' },
    { Text: 'Tripura', Value: 'TR' },
    { Text: 'Uttarakhand', Value: 'UK' },
    { Text: 'Uttar Pradesh', Value: 'UP' },
    { Text: 'West Bengal', Value: 'WB' },
    { Text: 'Tamil Nadu', Value: 'TN' },
    { Text: 'Tripura', Value: 'TR' },
    { Text: 'Andaman and Nicobar Islands', Value: 'AN' },
    { Text: 'Chandigarh', Value: 'CH' },
    { Text: 'Dadra and Nagar Haveli', Value: 'DH' },
    { Text: 'Daman and Diu', Value: 'DD' },
    { Text: 'Delhi', Value: 'DL' },
    { Text: 'Lakshadweep', Value: 'LD' },
    { Text: 'Pondicherry', Value: 'PY' },
  ];

  constructor(
    private formBuilder: FormBuilder,
    private registrationService: RegistrationService,
    private _snackBar: MatSnackBar
  ) {}
  contactDetailsFormGroup = this.formBuilder.group({
    FirstName: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(100)]),
    ],
    LastName: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(100)]),
    ],
    Email: [
      '',
      Validators.compose([
        Validators.required,
        Validators.maxLength(255),
        Validators.email,
      ]),
    ],
    PhoneNumber: [
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern('^[0-9]{10}$'),
      ]),
    ],
    ProfilePicture: ['', Validators.compose([Validators.required])],
  });

  organizationDetailsFormGroup = this.formBuilder.group({
    OrganizationName: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(100)]),
    ],
    Address: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(120)]),
    ],
    Address2: ['', Validators.compose([Validators.maxLength(120)])],
    Pincode: [
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern('^[1-9][0-9]{5}$'),
      ]),
    ],
    Place: ['', Validators.compose([Validators.maxLength(50)])],
    StateCode: ['', Validators.compose([Validators.required])],
    Organization_PAN: [
      '',
      Validators.compose([
        Validators.pattern('^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$'),
        Validators.required,
      ]),
    ],
    GSTNNo: [
      '',
      Validators.compose([
        Validators.pattern(
          '^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$'
        ),
        Validators.required,
      ]),
      this.validateGSTN.bind(this),
    ],
    GSTINUsername: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(50)]),
      this.validateGSTNUsername.bind(this),
    ],
    CancelledChequePhoto: ['', Validators.compose([Validators.required])],
  });

  accountForm = this.formBuilder.group({
    Username: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(50)]),
      this.validateUsername.bind(this),
    ],
    Password: [
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(18),
      ]),
    ],
    ConfirmPassword: [
      '',
      Validators.compose([
        Validators.required,
        this.validateConfirmPassword.bind(this),
      ]),
    ],
  });

  public getErrorMessage(formControlName: string) {
    let formControl = this.getFormControl(formControlName);
    if (!formControl?.touched || !formControl.errors || !formControl.invalid) {
      return;
    }
    switch (formControlName) {
      case 'FirstName': {
        if (formControl.errors['required']) {
          return 'First Name is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'First Name cannot exceed 100 characters.';
        }
        break;
      }
      case 'LastName': {
        if (formControl.errors['required']) {
          return 'Last Name is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Last Name cannot exceed 100 characters.';
        }
        break;
      }
      case 'Email': {
        if (formControl.errors['required']) {
          return 'Email is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Email cannot exceed 255 characters.';
        }
        if (formControl.errors['email']) {
          return 'Not a valid Email.';
        }
        if (formControl.errors['unique']) {
          return 'Email already exists.';
        }
        break;
      }
      case 'PhoneNumber': {
        if (formControl.errors['required']) {
          return 'Phone Number is mandatory.';
        }
        if (formControl.errors['pattern']) {
          return 'Not a valid Phone Number.';
        }
        if (formControl.errors['unique']) {
          return 'Phone Number already exists.';
        }
        break;
      }
      case 'OrganizationName': {
        if (formControl.errors['required']) {
          return 'Organization Name is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Organization Name cannot exceed 100 characters.';
        }
        break;
      }
      case 'Address': {
        if (formControl.errors['required']) {
          return 'Address is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Address cannot exceed 120 characters.';
        }
        break;
      }
      case 'Address2': {
        if (formControl.errors['maxlength']) {
          return 'Address 2 cannot exceed 120 characters.';
        }
        break;
      }
      case 'Pincode': {
        if (formControl.errors['required']) {
          return 'Pincode is mandatory.';
        }
        if (formControl.errors['pattern']) {
          return 'Not a valid Pincode.';
        }
        break;
      }
      case 'Place': {
        if (formControl.errors['maxlength']) {
          return 'Place cannot exceed 50 characters.';
        }
        break;
      }
      case 'StateCode': {
        if (formControl.errors['required']) {
          return 'State is mandatory.';
        }
        break;
      }
      case 'GSTNNo': {
        if (formControl.errors['required']) {
          return 'GSTIN No is mandatory.';
        }
        if (formControl.errors['pattern']) {
          return 'Not a valid GSTIN No.';
        }
        if (formControl.errors['unique']) {
          return 'GSTIN No already exists.';
        }
        break;
      }
      case 'Organization_PAN': {
        if (formControl.errors['required']) {
          return 'PAN is mandatory.';
        }
        if (formControl.errors['pattern']) {
          return 'Not a valid PAN';
        }
        break;
      }
      case 'GSTINUsername': {
        if (formControl.errors['required']) {
          return 'GSTIN Username is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'GSTIN Username cannot exceed 50 characters.';
        }
        if (formControl.errors['unique']) {
          return 'GSTIN Username already exists.';
        }
        break;
      }
      case 'Username': {
        if (formControl.errors['required']) {
          return 'Username is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Username cannot exceed 50 characters.';
        }
        if (formControl.errors['unique']) {
          return 'Username already exists.';
        }
        break;
      }
      case 'Password': {
        if (formControl.errors['required']) {
          return 'Password is mandatory.';
        }
        if (formControl.errors['maxlength']) {
          return 'Password cannot exceed 18 characters.';
        }
        if (formControl.errors['minlength']) {
          return 'Password should have atleast 6 characters.';
        }
        break;
      }
      case 'ConfirmPassword': {
        if (formControl.errors['required']) {
          return 'Confirm Password is mandatory.';
        }
        if (formControl.errors['confirm']) {
          return 'Passwords do not match.';
        }
        break;
      }
    }
    return;
  }

  public validatePicture(evt: any) {
    this.profilePictureSrc = '';
    var file = evt.target.files[0];
    if (!file) {
      this._snackBar.open('Please select an image');
    }
    var fileType = file['type'];
    var ValidImageTypes = ['image/jpeg', 'image/png'];
    if (!ValidImageTypes.includes(fileType)) {
      this._snackBar.open('Please select JPG/PNG image.');
      this.contactDetailsFormGroup.get('ProfilePicture')?.setValue('');
      return;
    }
    var maxSize = 4;
    if (maxSize < file.size / 1024 / 1024) {
      this._snackBar.open('Please select image less than 5 MB.');
      this.contactDetailsFormGroup.get('ProfilePicture')?.setValue('');
      return;
    }
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.profilePictureSrc = reader.result?.toString() || '';
    };
  }

  public validateCanceledChequePicture(evt: any) {
    this.cancelledChequePictureSrc = '';
    this.cancelledChequePictureName = '';
    var file = evt.target.files[0];
    if (!file) {
      this._snackBar.open('Please select an image');
    }
    var fileType = file['type'];
    var ValidImageTypes = ['image/jpeg', 'image/png'];
    if (!ValidImageTypes.includes(fileType)) {
      this._snackBar.open('Please select JPG/PNG image.');
      this.organizationDetailsFormGroup
        .get('CancelledChequePhoto')
        ?.setValue('');
      return;
    }
    var maxSize = 4;
    if (maxSize < file.size / 1024 / 1024) {
      this._snackBar.open('Please select image less than 5 MB.');
      this.organizationDetailsFormGroup
        .get('CancelledChequePhoto')
        ?.setValue('');
      return;
    }
    this.cancelledChequePictureName = file.name;
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.cancelledChequePictureSrc = reader.result?.toString() || '';
    };
  }

  private getFormControl(formControlName: string) {
    let formControl = this.contactDetailsFormGroup.get(formControlName);
    if (!formControl) {
      formControl = this.organizationDetailsFormGroup.get(formControlName);
    }
    if (!formControl) {
      formControl = this.accountForm.get(formControlName);
    }
    return formControl;
  }

  public getProfilePictureError() {
    const control = this.contactDetailsFormGroup.get('ProfilePicture');
    if (!control || !control.invalid) {
      return;
    }
    if (control.errors && control.errors['required']) {
      return 'Profile Picture is mandatory.';
    }
    return;
  }

  public getCancelledChequePictureError() {
    const control = this.organizationDetailsFormGroup.get(
      'CancelledChequePicture'
    );
    if (!control || !control.invalid) {
      return;
    }
    if (control.errors && control.errors['required']) {
      return 'Cancelled Cheque Picture is mandatory.';
    }
    return;
  }

  private validateConfirmPassword(control: AbstractControl) {
    const val = control.value;
    const passwordControl = this.accountForm?.get('Password');
    if (
      !val ||
      control.invalid ||
      !passwordControl?.value ||
      passwordControl.invalid
    ) {
      return null;
    }
    if (val !== passwordControl.value) {
      return { confirm: true };
    }
    return null;
  }

  private validateUsername(control: AbstractControl) {
    const val = control.value;
    if (!val || control.invalid) {
      return null;
    }
    return this.registrationService.checkUsernameExists(val).pipe(
      map((res: any) => {
        if (res.data) {
          return { unique: true };
        }
        return null;
      })
    );
  }

  private validateGSTN(control: AbstractControl) {
    const val = control.value;
    if (!val || control.invalid) {
      return null;
    }
    return this.registrationService.checkGSTNExists(val).pipe(
      map((res: any) => {
        if (res.data) {
          return { unique: true };
        }
        return null;
      })
    );
  }

  private validateGSTNUsername(control: AbstractControl) {
    const val = control.value;
    if (!val || control.invalid) {
      return null;
    }
    return this.registrationService.checkGSTNUsernameExists(val).pipe(
      map((res: any) => {
        if (res.data) {
          return { unique: true };
        }
        return null;
      })
    );
  }

  public register() {
    const value = {
      ...this.contactDetailsFormGroup.value,
      ...this.organizationDetailsFormGroup.value,
      ...this.accountForm.value,
    };
    value.CancelledChequePhoto = this.cancelledChequePictureSrc;
    value.ProfilePicture = this.profilePictureSrc;
    this.registrationService.register(value).subscribe((res: any) => {
      if (!res.isSuccess) {
        this._snackBar.open(res.message);
      } else {
        this._snackBar.open('Successfully Registered');
        window.location.reload();
      }
    });
  }
}
