import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupecoaComponent } from './supecoa.component';

describe('SupecoaComponent', () => {
  let component: SupecoaComponent;
  let fixture: ComponentFixture<SupecoaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupecoaComponent]
    });
    fixture = TestBed.createComponent(SupecoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
