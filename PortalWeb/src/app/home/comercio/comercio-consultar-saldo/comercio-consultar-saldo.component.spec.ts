import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComercioConsultarSaldoComponent } from './comercio-consultar-saldo.component';

describe('ComercioConsultarSaldoComponent', () => {
  let component: ComercioConsultarSaldoComponent;
  let fixture: ComponentFixture<ComercioConsultarSaldoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComercioConsultarSaldoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComercioConsultarSaldoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
