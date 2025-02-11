import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadGstr1Component } from './upload-gstr1.component';

describe('UploadGstr1Component', () => {
  let component: UploadGstr1Component;
  let fixture: ComponentFixture<UploadGstr1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UploadGstr1Component]
    });
    fixture = TestBed.createComponent(UploadGstr1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
