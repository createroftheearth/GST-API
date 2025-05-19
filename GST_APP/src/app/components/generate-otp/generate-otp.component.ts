import { Component } from '@angular/core';
import { EncryptDecryptService } from 'src/app/services/encrypt-decrypt.service';

@Component({
  selector: 'app-generate-otp',
  templateUrl: './generate-otp.component.html',
  styleUrls: ['./generate-otp.component.css'],
})
export class GenerateOtpComponent {
  /**
   *
   */
  constructor(private service: EncryptDecryptService) {}

  generateOtp() {
    this.encryptedOtp = this.service.encryptUsingAES256(this.otp);
  }

  public otp: string = '';
  public encryptedOtp: string = '';
}
