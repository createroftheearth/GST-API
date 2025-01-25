import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceB2clComponent } from './invoice-b2cl.component';

describe('InvoiceB2clComponent', () => {
  let component: InvoiceB2clComponent;
  let fixture: ComponentFixture<InvoiceB2clComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvoiceB2clComponent],
    });
    fixture = TestBed.createComponent(InvoiceB2clComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
