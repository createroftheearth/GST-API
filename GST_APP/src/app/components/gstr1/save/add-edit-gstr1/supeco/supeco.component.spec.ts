import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupecoComponent } from './supeco.component';

describe('SupecoComponent', () => {
  let component: SupecoComponent;
  let fixture: ComponentFixture<SupecoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SupecoComponent]
    });
    fixture = TestBed.createComponent(SupecoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
