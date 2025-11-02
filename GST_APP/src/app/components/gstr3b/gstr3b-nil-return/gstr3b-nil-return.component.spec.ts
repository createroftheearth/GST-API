import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gstr3bNilReturnComponent } from './gstr3b-nil-return.component';

describe('Gstr3bNilReturnComponent', () => {
  let component: Gstr3bNilReturnComponent;
  let fixture: ComponentFixture<Gstr3bNilReturnComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Gstr3bNilReturnComponent]
    });
    fixture = TestBed.createComponent(Gstr3bNilReturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
