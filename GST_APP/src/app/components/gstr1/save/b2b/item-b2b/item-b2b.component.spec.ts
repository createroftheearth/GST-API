import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemB2bComponent } from './item-b2b.component';

describe('ItemB2bComponent', () => {
  let component: ItemB2bComponent;
  let fixture: ComponentFixture<ItemB2bComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ItemB2bComponent]
    });
    fixture = TestBed.createComponent(ItemB2bComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
