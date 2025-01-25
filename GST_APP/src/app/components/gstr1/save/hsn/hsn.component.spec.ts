import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HsnComponent } from './hsn.component';

describe('HsnComponent', () => {
  let component: HsnComponent;
  let fixture: ComponentFixture<HsnComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HsnComponent]
    });
    fixture = TestBed.createComponent(HsnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
