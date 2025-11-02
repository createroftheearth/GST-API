import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NilReturnComponent } from './nil-return.component';

describe('NilReturnComponent', () => {
  let component: NilReturnComponent;
  let fixture: ComponentFixture<NilReturnComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NilReturnComponent]
    });
    fixture = TestBed.createComponent(NilReturnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
