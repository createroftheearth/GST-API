import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

@Component({
  selector: 'app-at',
  templateUrl: './at.component.html',
  styleUrls: ['./at.component.css'],
})
export class AtComponent {
  @Input() parentForm!: FormGroup; // Reference to parent form
  b2bArray!: FormArray;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.b2bArray = this.fb.array([]);
    this.parentForm.setControl('b2b', this.b2bArray);
  }

  addB2b(): void {
    const b2bGroup = this.fb.group({
      ctin: ['', []],
      inv: this.fb.array([]),
    });
    this.b2bArray.push(b2bGroup);
  }

  addInvoice(b2bGroup: FormGroup): void {
    const invoices = b2bGroup.get('inv') as FormArray;
    invoices.push(
      this.fb.group({
        inum: ['', []],
        idt: ['', []],
        val: [0, []],
        pos: ['', []],
        rchrg: [false, []],
        itms: this.fb.array([]),
      })
    );
  }

  addItem(invoiceGroup: FormGroup): void {
    const items = invoiceGroup.get('itms') as FormArray;
    items.push(
      this.fb.group({
        num: [0, []],
        itm_det: this.fb.group({
          txval: [0, []],
          rt: [0, []],
        }),
      })
    );
  }
}
