import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoreDwTable } from './core-dw-table';

describe('CoreDwTable', () => {
  let component: CoreDwTable;
  let fixture: ComponentFixture<CoreDwTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CoreDwTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CoreDwTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
