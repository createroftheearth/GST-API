import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EcomaComponent } from './ecoma.component';

describe('EcomaComponent', () => {
  let component: EcomaComponent;
  let fixture: ComponentFixture<EcomaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EcomaComponent]
    });
    fixture = TestBed.createComponent(EcomaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
