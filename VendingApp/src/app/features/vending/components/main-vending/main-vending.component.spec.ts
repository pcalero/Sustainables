import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainVendingComponent } from './main-vending.component';

describe('MainVendingComponent', () => {
  let component: MainVendingComponent;
  let fixture: ComponentFixture<MainVendingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainVendingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainVendingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
