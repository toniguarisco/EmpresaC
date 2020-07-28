import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminModificarUsuarioComponent } from './admin-modificar-usuario.component';

describe('AdminModificarUsuarioComponent', () => {
  let component: AdminModificarUsuarioComponent;
  let fixture: ComponentFixture<AdminModificarUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminModificarUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminModificarUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
