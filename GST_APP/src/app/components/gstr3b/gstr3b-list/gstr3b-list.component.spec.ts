import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gstr3bListComponent } from './gstr3b-list.component';

describe('Gstr3bListComponent', () => {
  let component: Gstr3bListComponent;
  let fixture: ComponentFixture<Gstr3bListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Gstr3bListComponent]
    });
    fixture = TestBed.createComponent(Gstr3bListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
