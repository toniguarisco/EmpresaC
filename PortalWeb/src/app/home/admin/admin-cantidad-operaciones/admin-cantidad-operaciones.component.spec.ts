import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCantidadOperacionesComponent } from './admin-cantidad-operaciones.component';

describe('AdminCantidadOperacionesComponent', () => {
  let component: AdminCantidadOperacionesComponent;
  let fixture: ComponentFixture<AdminCantidadOperacionesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCantidadOperacionesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCantidadOperacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
