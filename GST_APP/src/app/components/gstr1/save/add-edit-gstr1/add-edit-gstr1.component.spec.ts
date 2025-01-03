import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditGstr1Component } from './add-edit-gstr1.component';

describe('AddEditGstr1Component', () => {
  let component: AddEditGstr1Component;
  let fixture: ComponentFixture<AddEditGstr1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditGstr1Component]
    });
    fixture = TestBed.createComponent(AddEditGstr1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
