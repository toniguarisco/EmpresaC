import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IngresarCuentaComponent } from './ingresar-cuenta.component';

describe('IngresarCuentaComponent', () => {
  let component: IngresarCuentaComponent;
  let fixture: ComponentFixture<IngresarCuentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IngresarCuentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IngresarCuentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
