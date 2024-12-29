import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocIssueComponent } from './doc-issue.component';

describe('DocIssueComponent', () => {
  let component: DocIssueComponent;
  let fixture: ComponentFixture<DocIssueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocIssueComponent]
    });
    fixture = TestBed.createComponent(DocIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
