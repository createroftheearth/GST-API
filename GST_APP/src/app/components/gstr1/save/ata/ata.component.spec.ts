import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtaComponent } from './ata.component';

describe('AtaComponent', () => {
  let component: AtaComponent;
  let fixture: ComponentFixture<AtaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AtaComponent]
    });
    fixture = TestBed.createComponent(AtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
