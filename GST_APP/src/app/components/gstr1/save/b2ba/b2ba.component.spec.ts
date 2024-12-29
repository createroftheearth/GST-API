import { ComponentFixture, TestBed } from '@angular/core/testing';

import { B2baComponent } from './b2ba.component';

describe('B2baComponent', () => {
  let component: B2baComponent;
  let fixture: ComponentFixture<B2baComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [B2baComponent]
    });
    fixture = TestBed.createComponent(B2baComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
