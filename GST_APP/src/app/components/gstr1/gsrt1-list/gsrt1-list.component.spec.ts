import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gsrt1ListComponent } from './gsrt1-list.component';

describe('Gsrt1ListComponent', () => {
  let component: Gsrt1ListComponent;
  let fixture: ComponentFixture<Gsrt1ListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Gsrt1ListComponent]
    });
    fixture = TestBed.createComponent(Gsrt1ListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
