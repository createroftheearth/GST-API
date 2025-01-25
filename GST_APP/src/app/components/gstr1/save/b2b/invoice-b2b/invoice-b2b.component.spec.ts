import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceB2bComponent } from './invoice-b2b.component';

describe('InvoiceB2bComponent', () => {
  let component: InvoiceB2bComponent;
  let fixture: ComponentFixture<InvoiceB2bComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvoiceB2bComponent]
    });
    fixture = TestBed.createComponent(InvoiceB2bComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
