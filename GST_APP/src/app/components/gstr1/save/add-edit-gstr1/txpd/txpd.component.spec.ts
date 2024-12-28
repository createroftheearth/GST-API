import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxpdComponent } from './txpd.component';

describe('TxpdComponent', () => {
  let component: TxpdComponent;
  let fixture: ComponentFixture<TxpdComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TxpdComponent]
    });
    fixture = TestBed.createComponent(TxpdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
