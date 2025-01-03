import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NilComponent } from './nil.component';

describe('NilComponent', () => {
  let component: NilComponent;
  let fixture: ComponentFixture<NilComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NilComponent]
    });
    fixture = TestBed.createComponent(NilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
