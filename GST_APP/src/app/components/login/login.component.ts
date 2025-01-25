import { Component, ViewEncapsulation } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { LOCAL_STORAGE_KEYS } from '../../constants';
import { JSONSafeStringify } from 'src/app/helpers/util';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;
  otp: string = '';
  isValidOTP = false;
  otpSent = false;
  invalidOtpMessage = '';

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    const gstTokenData = localStorage.getItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA);
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);

    if (gstTokenData && token) {
      this.router.navigate(['/dashboard']);
    }

    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(18),
        ]),
      ],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.sendOtp();
    }
  }

  sendOtp(): void {
    this.loginService.login(this.loginForm.value).subscribe((response: any) => {
      if (response.isSuccess && response.data?.token) {
        const responseData = JSONSafeStringify(response.data);
        if (responseData) {
          localStorage.setItem(
            LOCAL_STORAGE_KEYS.INTERNAL_AUTH_DATA,
            responseData
          );
        }
        localStorage.setItem(
          LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN,
          response.data.token
        );
        this.otpSent = true;
      } else {
        localStorage.removeItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_DATA);
        localStorage.removeItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
        this.loginForm.controls['password'].setErrors({
          usernameOrPasswordInvalid:
            response.data?.data?.error?.message || true,
        });
      }
    });
  }

  onOtpChange(value: string): void {
    if (+value && value.length === 6) {
      this.otp = value;
      this.isValidOTP = true;
      this.verifyOtp();
    } else {
      this.otp = '';
      this.isValidOTP = false;
    }
  }

  verifyOtp(): void {
    this.loginService.generateGSTNToken(this.otp).subscribe((response: any) => {
      if (response.isSuccess && response.data?.data) {
        const gstTokenData = JSONSafeStringify({
          'GSTIN-Token': response.data.data.auth_token,
          'GSTIN-Sek': response.data.data.sek,
        });

        const expiryTime = response.data.data.expiry;
        if (gstTokenData) {
          localStorage.setItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA, gstTokenData);
          const returnUrl =
            this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
          this.router.navigate([returnUrl]); // Redirect to the intended URL
        }
      } else {
        this.invalidOtpMessage = 'Invalid OTP entered';
        localStorage.removeItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA);
      }
    });
  }

  private getFormControl(formControlName: string) {
    let formControl = this.loginForm.get(formControlName);
    return formControl;
  }

  public getErrorMessage(formControlName: string) {
    let formControl = this.getFormControl(formControlName);
    if (!formControl?.touched || !formControl.errors || !formControl.invalid) {
      return;
    }
    switch (formControlName) {
      case 'username': {
        if (formControl.errors['required']) {
          return 'Username is mandatory.';
        }
        break;
      }
      case 'password': {
        if (formControl.errors['required']) {
          return 'Password is mandatory.';
        } else if (formControl.errors['usernameOrPasswordInvalid'] === true) {
          return 'Username or password invalid';
        } else if (formControl.errors['usernameOrPasswordInvalid']) {
          return formControl.errors['usernameOrPasswordInvalid'];
        }
        break;
      }
    }
  }
}
