import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdnraComponent } from './cdnra.component';

describe('CdnraComponent', () => {
  let component: CdnraComponent;
  let fixture: ComponentFixture<CdnraComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CdnraComponent]
    });
    fixture = TestBed.createComponent(CdnraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
