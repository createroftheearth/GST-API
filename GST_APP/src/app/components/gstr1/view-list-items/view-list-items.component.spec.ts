import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewListItemsComponent } from './view-list-items.component';

describe('ViewListItemsComponent', () => {
  let component: ViewListItemsComponent;
  let fixture: ComponentFixture<ViewListItemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewListItemsComponent]
    });
    fixture = TestBed.createComponent(ViewListItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
