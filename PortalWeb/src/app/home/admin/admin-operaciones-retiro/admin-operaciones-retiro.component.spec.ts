import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminOperacionesRetiroComponent } from './admin-operaciones-retiro.component';

describe('AdminOperacionesRetiroComponent', () => {
  let component: AdminOperacionesRetiroComponent;
  let fixture: ComponentFixture<AdminOperacionesRetiroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminOperacionesRetiroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminOperacionesRetiroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
