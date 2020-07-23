import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminRecaudoComisionComponent } from './admin-recaudo-comision.component';

describe('AdminRecaudoComisionComponent', () => {
  let component: AdminRecaudoComisionComponent;
  let fixture: ComponentFixture<AdminRecaudoComisionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminRecaudoComisionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminRecaudoComisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
