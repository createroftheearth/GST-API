import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdnurComponent } from './cdnur.component';

describe('CdnurComponent', () => {
  let component: CdnurComponent;
  let fixture: ComponentFixture<CdnurComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CdnurComponent]
    });
    fixture = TestBed.createComponent(CdnurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
