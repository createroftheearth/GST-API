import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtComponent } from './at.component';

describe('AtComponent', () => {
  let component: AtComponent;
  let fixture: ComponentFixture<AtComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AtComponent]
    });
    fixture = TestBed.createComponent(AtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
