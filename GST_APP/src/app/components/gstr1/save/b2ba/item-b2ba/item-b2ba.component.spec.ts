import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemB2baComponent } from './item-b2ba.component';

describe('ItemB2baComponent', () => {
  let component: ItemB2baComponent;
  let fixture: ComponentFixture<ItemB2baComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ItemB2baComponent]
    });
    fixture = TestBed.createComponent(ItemB2baComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
