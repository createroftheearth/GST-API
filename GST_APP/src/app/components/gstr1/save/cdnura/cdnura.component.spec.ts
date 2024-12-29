import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdnuraComponent } from './cdnura.component';

describe('CdnuraComponent', () => {
  let component: CdnuraComponent;
  let fixture: ComponentFixture<CdnuraComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CdnuraComponent]
    });
    fixture = TestBed.createComponent(CdnuraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
