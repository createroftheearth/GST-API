import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemB2clComponent } from './item-b2cl.component';

describe('ItemB2clComponent', () => {
  let component: ItemB2clComponent;
  let fixture: ComponentFixture<ItemB2clComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ItemB2clComponent]
    });
    fixture = TestBed.createComponent(ItemB2clComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
