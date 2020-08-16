import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostrarCuentasComponent } from './mostrar-cuentas.component';

describe('MostrarCuentasComponent', () => {
  let component: MostrarCuentasComponent;
  let fixture: ComponentFixture<MostrarCuentasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostrarCuentasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostrarCuentasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
