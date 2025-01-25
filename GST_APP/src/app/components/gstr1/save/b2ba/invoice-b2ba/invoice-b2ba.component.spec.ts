import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceB2baComponent } from './invoice-b2ba.component';

describe('InvoiceB2baComponent', () => {
  let component: InvoiceB2baComponent;
  let fixture: ComponentFixture<InvoiceB2baComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvoiceB2baComponent]
    });
    fixture = TestBed.createComponent(InvoiceB2baComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
