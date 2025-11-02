import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gstr9aComponent } from './gstr9a.component';

describe('Gstr9aComponent', () => {
  let component: Gstr9aComponent;
  let fixture: ComponentFixture<Gstr9aComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Gstr9aComponent]
    });
    fixture = TestBed.createComponent(Gstr9aComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
