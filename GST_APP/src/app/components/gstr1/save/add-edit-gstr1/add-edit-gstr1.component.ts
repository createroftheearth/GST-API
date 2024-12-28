import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

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
      gstin: [
        '',
        [
          Validators.required,
          Validators.pattern(
            '[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Zz1-9A-Ja-j]{1}[0-9a-zA-Z]{1}'
          ),
        ],
      ],
      fp: ['', Validators.required],
      gt: [0, [Validators.required, Validators.min(0)]],
      cur_gt: [0, [Validators.required, Validators.min(0)]],
      b2b: this.fb.array([]),
      b2ba: this.fb.array([]),
      b2cl: this.fb.array([]),
    });
  }

  onSubmit(): void {
    if (this.gstr1Form.valid) {
      console.log(this.gstr1Form.value);
    }
  }
}
