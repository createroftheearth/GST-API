import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gstr9cComponent } from './gstr9c.component';

describe('Gstr9cComponent', () => {
  let component: Gstr9cComponent;
  let fixture: ComponentFixture<Gstr9cComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Gstr9cComponent]
    });
    fixture = TestBed.createComponent(Gstr9cComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
