import { ComponentFixture, TestBed } from '@angular/core/testing';

import { B2clComponent } from './b2cl.component';

describe('B2clComponent', () => {
  let component: B2clComponent;
  let fixture: ComponentFixture<B2clComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [B2clComponent]
    });
    fixture = TestBed.createComponent(B2clComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
