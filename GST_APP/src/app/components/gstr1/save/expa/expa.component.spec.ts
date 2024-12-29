import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpaComponent } from './expa.component';

describe('ExpaComponent', () => {
  let component: ExpaComponent;
  let fixture: ComponentFixture<ExpaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExpaComponent]
    });
    fixture = TestBed.createComponent(ExpaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
